namespace InfernoBrowser
{
    partial class Inferno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inferno));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripAddressBar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHistory = new System.Windows.Forms.ToolStripButton();
            this.BrowserTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.extensiosPicBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.BrowserTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extensiosPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBack,
            this.toolStripButtonForward,
            this.toolStripButtonReload,
            this.toolStripAddressBar,
            this.toolStripButton4,
            this.toolStripButtonAddTab,
            this.toolStripButtonHistory});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBack.Image")));
            this.toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Size = new System.Drawing.Size(36, 22);
            this.toolStripButtonBack.Text = "Back";
            this.toolStripButtonBack.Click += new System.EventHandler(this.toolStripButtonBack_Click);
            // 
            // toolStripButtonForward
            // 
            this.toolStripButtonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonForward.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonForward.Image")));
            this.toolStripButtonForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonForward.Name = "toolStripButtonForward";
            this.toolStripButtonForward.Size = new System.Drawing.Size(54, 22);
            this.toolStripButtonForward.Text = "Forward";
            this.toolStripButtonForward.Click += new System.EventHandler(this.toolStripButtonForward_Click);
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonReload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReload.Image")));
            this.toolStripButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Size = new System.Drawing.Size(50, 22);
            this.toolStripButtonReload.Text = "Refresh";
            this.toolStripButtonReload.Click += new System.EventHandler(this.toolStripButtonReload_Click);
            // 
            // toolStripAddressBar
            // 
            this.toolStripAddressBar.Font = new System.Drawing.Font("Segoe UI", 9.163636F);
            this.toolStripAddressBar.Name = "toolStripAddressBar";
            this.toolStripAddressBar.Size = new System.Drawing.Size(300, 25);
            this.toolStripAddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripAddressBar_KeyDown);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(26, 22);
            this.toolStripButton4.Text = "Go";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButtonGo_Click);
            // 
            // toolStripButtonAddTab
            // 
            this.toolStripButtonAddTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddTab.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddTab.Image")));
            this.toolStripButtonAddTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddTab.Name = "toolStripButtonAddTab";
            this.toolStripButtonAddTab.Size = new System.Drawing.Size(54, 22);
            this.toolStripButtonAddTab.Text = "Add Tab";
            this.toolStripButtonAddTab.Click += new System.EventHandler(this.toolStripButtonAddTab_Click);
            // 
            // toolStripButtonHistory
            // 
            this.toolStripButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonHistory.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHistory.Image")));
            this.toolStripButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHistory.Name = "toolStripButtonHistory";
            this.toolStripButtonHistory.RightToLeftAutoMirrorImage = true;
            this.toolStripButtonHistory.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonHistory.Text = "History";
            this.toolStripButtonHistory.Click += new System.EventHandler(this.toolStripButtonHistory_Click);
            // 
            // BrowserTabs
            // 
            this.BrowserTabs.Controls.Add(this.tabPage1);
            this.BrowserTabs.Controls.Add(this.tabPage2);
            this.BrowserTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserTabs.Location = new System.Drawing.Point(0, 25);
            this.BrowserTabs.Name = "BrowserTabs";
            this.BrowserTabs.SelectedIndex = 0;
            this.BrowserTabs.Size = new System.Drawing.Size(800, 425);
            this.BrowserTabs.TabIndex = 1;
            this.BrowserTabs.Click += new System.EventHandler(this.BrowserTabs_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Tab";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.927273F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "+";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // extensiosPicBox
            // 
            this.extensiosPicBox.BackColor = System.Drawing.Color.Transparent;
            this.extensiosPicBox.Image = ((System.Drawing.Image)(resources.GetObject("extensiosPicBox.Image")));
            this.extensiosPicBox.Location = new System.Drawing.Point(539, 0);
            this.extensiosPicBox.Name = "extensiosPicBox";
            this.extensiosPicBox.Size = new System.Drawing.Size(30, 25);
            this.extensiosPicBox.TabIndex = 2;
            this.extensiosPicBox.TabStop = false;
            this.extensiosPicBox.Click += new System.EventHandler(this.ExtensionsPicBox_Click);
            // 
            // Inferno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 483);
            this.Controls.Add(this.BrowserTabs);
            this.Controls.Add(this.extensiosPicBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Inferno";
            this.Text = "InfernoBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inferno_FormClosing);
            this.LocationChanged += new System.EventHandler(this.Inferno_LocationChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BrowserTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.extensiosPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripButton toolStripButtonForward;
        private System.Windows.Forms.ToolStripTextBox toolStripAddressBar;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
        private System.Windows.Forms.TabControl BrowserTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddTab;
        private System.Windows.Forms.PictureBox extensiosPicBox;
        private System.Windows.Forms.ToolStripButton toolStripButtonHistory;
    }
}

