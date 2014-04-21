using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Resources;
using System.Reflection;

namespace Simple_JPEG_Stripper
{
    public partial class MainForm : Form
    {
        private ResourceManager LocRM = Simple_JPEG_Stripper.Properties.Resources.ResourceManager;
        private bool isWorking = false;
        private string JPG_path = "";
        private TreeNode mtn;
        private Thread active;

        private delegate void d_update_treeview(TreeNode tn);
        private delegate void d_thread_done();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Search for JPEG files in the selected path, and add them to the TreeView.
        /// </summary>
        private void browse_folder()
        {
            string dir = JPG_path;
            TreeNode t, tn = new TreeNode(LocRM.GetString("strTreeNodeRoot"));
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] jpgs;
            //Search recursively
            if (RB_Recursion.Checked) jpgs = di.GetFiles("*.jpg", SearchOption.AllDirectories);
            //Or not
            else jpgs = di.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
            foreach (FileInfo fi in jpgs)
            {
                t = tn;
                string path = fi.FullName.Replace(dir, ""); //Strip the path 
                string[] steps = path.Split('\\');          //but keep the hierarchy
                for (int i = 1; i < steps.Length; i++)
                {
                    if (t.Nodes.ContainsKey(steps[i]) == false) //Add a node foreach new directory
                    {
                        TreeNode ntn = new TreeNode(steps[i]);
                        ntn.Name = steps[i];
                        if (i == steps.Length - 1) ntn.Tag = fi.FullName;
                        ntn.Checked = true;
                        t.Nodes.Add(ntn);
                    }
                    t = t.Nodes[steps[i]];
                }
            }
            this.Invoke(new d_update_treeview(update_treeview), tn);
        }

        /// <summary>
        /// Add the file tree created by seerching for JPEG files
        /// </summary>
        private void update_treeview(TreeNode tn)
        {
            isWorking = false;
            MainTreeView.Nodes.Clear();
            MainTreeView.Nodes.Add(tn);
            mtn = tn;
            mtn.Checked = true;
            MainTreeView.ExpandAll();

            TBOX_Prefix.Enabled = true;
            BTN_Process.Enabled = true;
        }

        /// <summary>
        /// Propagates checks down to the child nodes.
        /// </summary>
        private void checked_node(TreeNode tn)
        {
            foreach (TreeNode t in tn.Nodes)
            {
                if (t.Checked && t.Tag != null)
                {
                    remove_app((string)t.Tag);
                }
                else checked_node(t);
            }
        }

        private void thread_node()
        {
            checked_node(mtn);
            this.Invoke(new d_thread_done(thread_done));
        }

        /// <summary>
        /// This callback notify the user that the cleaning is done.
        /// </summary>
        private void thread_done()
        {
            isWorking = false;
            TBOX_Progress.Text = LocRM.GetString("strProcessDone");
            TBOX_Progress.BackColor = System.Drawing.Color.Lime;
            MainTreeView.Enabled = true;
        }

        /// <summary>
        /// Strip JPEG Application Segments (0xffe0 to 0xffef) as well as the comment section (0xfffe).
        /// APP2 (0xffe2) is only stipped if the user does not want to keep ICC profile.
        /// </summary>
        private void remove_app(string file)
        {
            FileInfo fi = new FileInfo(file);
            FileStream fsi = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            FileStream fso = new FileStream(fi.DirectoryName + "\\" + TBOX_Prefix.Text + fi.Name, FileMode.Create, FileAccess.Write, FileShare.Read);
            BinaryReader br = new BinaryReader(fsi);
            BinaryWriter bw = new BinaryWriter(fso);

            ushort head = br.ReadUInt16();
            if (head != 0xd8ff) return;
            bw.Write(head);

            //Reads input file but only writes essential data.
            while (fsi.Position < fsi.Length)
            {
                ushort bmarker = br.ReadUInt16();
                ushort bsize = br.ReadUInt16();
                ushort marker = (ushort)(bmarker >> 8 | bmarker << 8);
                ushort size = (ushort)(bsize >> 8 | bsize << 8);
                
                //Strip Application Segments and comments
                if (((marker >= 0xffe0 && marker <= 0xffef) || marker == 0xfffe)
                    //Preserve ICC profile on user behalf
                    && (CBOX_KeepICC.Checked == false || marker != 0xffe2))
                {
                    fsi.Seek(size - 2, SeekOrigin.Current);
                }
                else if (marker == 0xffda) //Start of Scan
                {
                    bw.Write(bmarker);
                    bw.Write(bsize);
                    long block = fsi.Length - fsi.Position;
                    while (block > int.MaxValue)
                    {
                        block -= int.MaxValue;
                        bw.Write(br.ReadBytes(int.MaxValue));
                    }
                    bw.Write(br.ReadBytes((int)block));
                }
                else //Preserve other markers
                {
                    bw.Write(bmarker);
                    bw.Write(bsize);
                    bw.Write(br.ReadBytes(size - 2));
                }
            }
            bw.Close();
            br.Close();
            fso.Close();
            fsi.Close();
        }

        /// <summary>
        /// Open a file browser, then search for JPEG files.
        /// </summary>
        private void BTN_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            if (fd.SelectedPath.Length > 0)
            {
                //A multithread
                JPG_path = fd.SelectedPath;
                active = new Thread(new ThreadStart(browse_folder));
                MainTreeView.Enabled = true;
                MainTreeView.Nodes.Clear();
                MainTreeView.Nodes.Add(LocRM.GetString("strSearchInProgress"));
                isWorking = true;
                active.Start();
            }
        }

        /// <summary>
        /// Run the process of cleaning
        /// </summary>
        private void BTN_Process_Click(object sender, EventArgs e)
        {
            MainTreeView.Enabled = false;
            TBOX_Progress.Visible = true;
            active = new Thread(new ThreadStart(thread_node));
            isWorking = true;
            active.Start();
        }

        private void BTN_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Warn users trying to quit the application when cleaning in progress.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isWorking)
            {
                DialogResult dr = MessageBox.Show(LocRM.GetString("strOnQuitWarning"), LocRM.GetString("strWarning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr.Equals(DialogResult.No)) e.Cancel = true;
                active.Abort();
            }
        }
    }
}
