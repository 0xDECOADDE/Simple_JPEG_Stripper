namespace Simple_JPEG_Stripper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GBOX_AppDesc = new System.Windows.Forms.GroupBox();
            this.CBOX_KeepICC = new System.Windows.Forms.CheckBox();
            this.LAB_AppDesc = new System.Windows.Forms.Label();
            this.GBOX_Browse = new System.Windows.Forms.GroupBox();
            this.BTN_Browse = new System.Windows.Forms.Button();
            this.RB_Recursion = new System.Windows.Forms.RadioButton();
            this.RB_NoRecursion = new System.Windows.Forms.RadioButton();
            this.GBOX_FileTree = new System.Windows.Forms.GroupBox();
            this.GBOX_Process = new System.Windows.Forms.GroupBox();
            this.TBOX_Progress = new System.Windows.Forms.TextBox();
            this.BTN_Quit = new System.Windows.Forms.Button();
            this.BTN_Process = new System.Windows.Forms.Button();
            this.TBOX_Prefix = new System.Windows.Forms.TextBox();
            this.LAB_Prefix = new System.Windows.Forms.Label();
            this.MainTreeView = new Simple_JPEG_Stripper.TriStateTreeView();
            this.GBOX_AppDesc.SuspendLayout();
            this.GBOX_Browse.SuspendLayout();
            this.GBOX_FileTree.SuspendLayout();
            this.GBOX_Process.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBOX_AppDesc
            // 
            this.GBOX_AppDesc.Controls.Add(this.CBOX_KeepICC);
            this.GBOX_AppDesc.Controls.Add(this.LAB_AppDesc);
            resources.ApplyResources(this.GBOX_AppDesc, "GBOX_AppDesc");
            this.GBOX_AppDesc.Name = "GBOX_AppDesc";
            this.GBOX_AppDesc.TabStop = false;
            // 
            // CBOX_KeepICC
            // 
            resources.ApplyResources(this.CBOX_KeepICC, "CBOX_KeepICC");
            this.CBOX_KeepICC.Checked = true;
            this.CBOX_KeepICC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBOX_KeepICC.Name = "CBOX_KeepICC";
            this.CBOX_KeepICC.UseVisualStyleBackColor = true;
            // 
            // LAB_AppDesc
            // 
            resources.ApplyResources(this.LAB_AppDesc, "LAB_AppDesc");
            this.LAB_AppDesc.Name = "LAB_AppDesc";
            // 
            // GBOX_Browse
            // 
            this.GBOX_Browse.Controls.Add(this.BTN_Browse);
            this.GBOX_Browse.Controls.Add(this.RB_Recursion);
            this.GBOX_Browse.Controls.Add(this.RB_NoRecursion);
            resources.ApplyResources(this.GBOX_Browse, "GBOX_Browse");
            this.GBOX_Browse.Name = "GBOX_Browse";
            this.GBOX_Browse.TabStop = false;
            // 
            // BTN_Browse
            // 
            resources.ApplyResources(this.BTN_Browse, "BTN_Browse");
            this.BTN_Browse.Name = "BTN_Browse";
            this.BTN_Browse.UseVisualStyleBackColor = true;
            this.BTN_Browse.Click += new System.EventHandler(this.BTN_Browse_Click);
            // 
            // RB_Recursion
            // 
            resources.ApplyResources(this.RB_Recursion, "RB_Recursion");
            this.RB_Recursion.Name = "RB_Recursion";
            this.RB_Recursion.UseVisualStyleBackColor = true;
            // 
            // RB_NoRecursion
            // 
            resources.ApplyResources(this.RB_NoRecursion, "RB_NoRecursion");
            this.RB_NoRecursion.Checked = true;
            this.RB_NoRecursion.Name = "RB_NoRecursion";
            this.RB_NoRecursion.TabStop = true;
            this.RB_NoRecursion.UseVisualStyleBackColor = true;
            // 
            // GBOX_FileTree
            // 
            this.GBOX_FileTree.Controls.Add(this.MainTreeView);
            resources.ApplyResources(this.GBOX_FileTree, "GBOX_FileTree");
            this.GBOX_FileTree.Name = "GBOX_FileTree";
            this.GBOX_FileTree.TabStop = false;
            // 
            // GBOX_Process
            // 
            this.GBOX_Process.Controls.Add(this.TBOX_Progress);
            this.GBOX_Process.Controls.Add(this.BTN_Quit);
            this.GBOX_Process.Controls.Add(this.BTN_Process);
            this.GBOX_Process.Controls.Add(this.TBOX_Prefix);
            this.GBOX_Process.Controls.Add(this.LAB_Prefix);
            resources.ApplyResources(this.GBOX_Process, "GBOX_Process");
            this.GBOX_Process.Name = "GBOX_Process";
            this.GBOX_Process.TabStop = false;
            // 
            // TBOX_Progress
            // 
            this.TBOX_Progress.BackColor = System.Drawing.Color.Red;
            this.TBOX_Progress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TBOX_Progress, "TBOX_Progress");
            this.TBOX_Progress.Name = "TBOX_Progress";
            // 
            // BTN_Quit
            // 
            resources.ApplyResources(this.BTN_Quit, "BTN_Quit");
            this.BTN_Quit.Name = "BTN_Quit";
            this.BTN_Quit.UseVisualStyleBackColor = true;
            this.BTN_Quit.Click += new System.EventHandler(this.BTN_Quit_Click);
            // 
            // BTN_Process
            // 
            resources.ApplyResources(this.BTN_Process, "BTN_Process");
            this.BTN_Process.Name = "BTN_Process";
            this.BTN_Process.UseVisualStyleBackColor = true;
            this.BTN_Process.Click += new System.EventHandler(this.BTN_Process_Click);
            // 
            // TBOX_Prefix
            // 
            resources.ApplyResources(this.TBOX_Prefix, "TBOX_Prefix");
            this.TBOX_Prefix.Name = "TBOX_Prefix";
            // 
            // LAB_Prefix
            // 
            resources.ApplyResources(this.LAB_Prefix, "LAB_Prefix");
            this.LAB_Prefix.Name = "LAB_Prefix";
            // 
            // MainTreeView
            // 
            this.MainTreeView.CheckBoxes = true;
            resources.ApplyResources(this.MainTreeView, "MainTreeView");
            this.MainTreeView.Name = "MainTreeView";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GBOX_Process);
            this.Controls.Add(this.GBOX_FileTree);
            this.Controls.Add(this.GBOX_Browse);
            this.Controls.Add(this.GBOX_AppDesc);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.GBOX_AppDesc.ResumeLayout(false);
            this.GBOX_AppDesc.PerformLayout();
            this.GBOX_Browse.ResumeLayout(false);
            this.GBOX_Browse.PerformLayout();
            this.GBOX_FileTree.ResumeLayout(false);
            this.GBOX_Process.ResumeLayout(false);
            this.GBOX_Process.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBOX_AppDesc;
        private System.Windows.Forms.Label LAB_AppDesc;
        private System.Windows.Forms.CheckBox CBOX_KeepICC;
        private System.Windows.Forms.GroupBox GBOX_Browse;
        private System.Windows.Forms.Button BTN_Browse;
        private System.Windows.Forms.RadioButton RB_Recursion;
        private System.Windows.Forms.RadioButton RB_NoRecursion;
        private System.Windows.Forms.GroupBox GBOX_FileTree;
        private TriStateTreeView MainTreeView;
        private System.Windows.Forms.GroupBox GBOX_Process;
        private System.Windows.Forms.TextBox TBOX_Progress;
        private System.Windows.Forms.Button BTN_Quit;
        private System.Windows.Forms.Button BTN_Process;
        private System.Windows.Forms.TextBox TBOX_Prefix;
        private System.Windows.Forms.Label LAB_Prefix;

    }
}

