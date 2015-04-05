namespace WSIC
{
    partial class WSICForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WSICForm));
            this.nmrtToolStrip = new System.Windows.Forms.ToolStrip();
            this.WindowsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.infoListBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.nmrtStatusStrip = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.POTabControl = new System.Windows.Forms.TabControl();
            this.ResourceTabPage = new System.Windows.Forms.TabPage();
            this.windowsDataGridView = new System.Windows.Forms.DataGridView();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.nmrtToolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.POTabControl.SuspendLayout();
            this.ResourceTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nmrtToolStrip
            // 
            this.nmrtToolStrip.AutoSize = false;
            this.nmrtToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.nmrtToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WindowsToolStripButton,
            this.toolStripSplitButton1,
            this.helpToolStripButton});
            this.nmrtToolStrip.Location = new System.Drawing.Point(0, 0);
            this.nmrtToolStrip.Name = "nmrtToolStrip";
            this.nmrtToolStrip.Size = new System.Drawing.Size(886, 69);
            this.nmrtToolStrip.TabIndex = 1;
            this.nmrtToolStrip.Text = "Nmrt工具栏";
            // 
            // WindowsToolStripButton
            // 
            this.WindowsToolStripButton.AutoSize = false;
            this.WindowsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.WindowsToolStripButton.Image = global::NMRT.Properties.Resources._003;
            this.WindowsToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.WindowsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WindowsToolStripButton.Name = "WindowsToolStripButton";
            this.WindowsToolStripButton.Size = new System.Drawing.Size(60, 43);
            this.WindowsToolStripButton.Text = "Windows";
            this.WindowsToolStripButton.Click += new System.EventHandler(this.nmonRunToolStripButton_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(6, 69);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.AutoSize = false;
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = global::NMRT.Properties.Resources.shell32_24;
            this.helpToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(60, 43);
            this.helpToolStripButton.Text = "Help";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // nmrtStatusStrip
            // 
            this.nmrtStatusStrip.Location = new System.Drawing.Point(0, 588);
            this.nmrtStatusStrip.Name = "nmrtStatusStrip";
            this.nmrtStatusStrip.Size = new System.Drawing.Size(886, 22);
            this.nmrtStatusStrip.TabIndex = 2;
            this.nmrtStatusStrip.Text = "Nmrt状态栏";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 69);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            this.splitContainer1.Panel1.Controls.Add(this.POTabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.logTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(886, 519);
            this.splitContainer1.SplitterDistance = 443;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 443);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // POTabControl
            // 
            this.POTabControl.Controls.Add(this.ResourceTabPage);
            this.POTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POTabControl.Location = new System.Drawing.Point(0, 0);
            this.POTabControl.Name = "POTabControl";
            this.POTabControl.SelectedIndex = 0;
            this.POTabControl.Size = new System.Drawing.Size(886, 443);
            this.POTabControl.TabIndex = 2;
            // 
            // ResourceTabPage
            // 
            this.ResourceTabPage.Controls.Add(this.windowsDataGridView);
            this.ResourceTabPage.Location = new System.Drawing.Point(4, 22);
            this.ResourceTabPage.Name = "ResourceTabPage";
            this.ResourceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResourceTabPage.Size = new System.Drawing.Size(878, 417);
            this.ResourceTabPage.TabIndex = 0;
            this.ResourceTabPage.Text = "系统";
            this.ResourceTabPage.UseVisualStyleBackColor = true;
            // 
            // windowsDataGridView
            // 
            this.windowsDataGridView.AllowUserToAddRows = false;
            this.windowsDataGridView.AllowUserToDeleteRows = false;
            this.windowsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.windowsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.windowsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.windowsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.windowsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.windowsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsDataGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.windowsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.windowsDataGridView.Name = "windowsDataGridView";
            this.windowsDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.windowsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.windowsDataGridView.RowTemplate.Height = 23;
            this.windowsDataGridView.Size = new System.Drawing.Size(872, 411);
            this.windowsDataGridView.TabIndex = 0;
            // 
            // logTextBox
            // 
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Location = new System.Drawing.Point(0, 0);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(886, 72);
            this.logTextBox.TabIndex = 1;
            // 
            // NmrtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 610);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.nmrtStatusStrip);
            this.Controls.Add(this.nmrtToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NmrtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WSIC";
            this.nmrtToolStrip.ResumeLayout(false);
            this.nmrtToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.POTabControl.ResumeLayout(false);
            this.ResourceTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.windowsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip nmrtToolStrip;
        private System.Windows.Forms.StatusStrip nmrtStatusStrip;
        private System.Windows.Forms.ToolStripButton WindowsToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl POTabControl;
        private System.Windows.Forms.TabPage ResourceTabPage;
        private System.Windows.Forms.DataGridView windowsDataGridView;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
    }
}