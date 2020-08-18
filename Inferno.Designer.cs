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
            this.toolStripButtonCloseTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBookmark = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCloseAndOpen = new System.Windows.Forms.ToolStripButton();
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
            this.toolStripButtonCloseTab,
            this.toolStripButtonBookmark,
            this.toolStripButtonHistory,
            this.toolStripButtonCloseAndOpen});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonBack, "toolStripButtonBack");
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Click += new System.EventHandler(this.toolStripButtonBack_Click);
            // 
            // toolStripButtonForward
            // 
            this.toolStripButtonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonForward, "toolStripButtonForward");
            this.toolStripButtonForward.Name = "toolStripButtonForward";
            this.toolStripButtonForward.Click += new System.EventHandler(this.toolStripButtonForward_Click);
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonReload, "toolStripButtonReload");
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Click += new System.EventHandler(this.toolStripButtonReload_Click);
            // 
            // toolStripAddressBar
            // 
            this.toolStripAddressBar.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripAddressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripAddressBar.Name = "toolStripAddressBar";
            this.toolStripAddressBar.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            resources.ApplyResources(this.toolStripAddressBar, "toolStripAddressBar");
            this.toolStripAddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripAddressBar_KeyDown);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButtonGo_Click);
            // 
            // toolStripButtonCloseTab
            // 
            this.toolStripButtonCloseTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonCloseTab, "toolStripButtonCloseTab");
            this.toolStripButtonCloseTab.Name = "toolStripButtonCloseTab";
            this.toolStripButtonCloseTab.Click += new System.EventHandler(this.toolStripButtonCloseTab_Click);
            // 
            // toolStripButtonBookmark
            // 
            this.toolStripButtonBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonBookmark, "toolStripButtonBookmark");
            this.toolStripButtonBookmark.Name = "toolStripButtonBookmark";
            // 
            // toolStripButtonHistory
            // 
            this.toolStripButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonHistory, "toolStripButtonHistory");
            this.toolStripButtonHistory.Name = "toolStripButtonHistory";
            this.toolStripButtonHistory.Click += new System.EventHandler(this.toolStripButtonHistory_Click);
            // 
            // toolStripButtonCloseAndOpen
            // 
            this.toolStripButtonCloseAndOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonCloseAndOpen, "toolStripButtonCloseAndOpen");
            this.toolStripButtonCloseAndOpen.Name = "toolStripButtonCloseAndOpen";
            this.toolStripButtonCloseAndOpen.Click += new System.EventHandler(this.toolStripButtonCloseAndOpen_Click);
            // 
            // BrowserTabs
            // 
            this.BrowserTabs.Controls.Add(this.tabPage1);
            this.BrowserTabs.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.BrowserTabs, "BrowserTabs");
            this.BrowserTabs.Name = "BrowserTabs";
            this.BrowserTabs.SelectedIndex = 0;
            this.BrowserTabs.Click += new System.EventHandler(this.BrowserTabs_Click);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // extensiosPicBox
            // 
            this.extensiosPicBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.extensiosPicBox, "extensiosPicBox");
            this.extensiosPicBox.Name = "extensiosPicBox";
            this.extensiosPicBox.TabStop = false;
            this.extensiosPicBox.Click += new System.EventHandler(this.ExtensionsPicBox_Click);
            // 
            // Inferno
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.extensiosPicBox);
            this.Controls.Add(this.BrowserTabs);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Inferno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inferno_FormClosing);
            this.LocationChanged += new System.EventHandler(this.Inferno_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.ChangeExtButtonLoc);
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
        private System.Windows.Forms.PictureBox extensiosPicBox;
        private System.Windows.Forms.ToolStripButton toolStripButtonHistory;
        private System.Windows.Forms.ToolStripButton toolStripButtonCloseAndOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonBookmark;
        private System.Windows.Forms.ToolStripButton toolStripButtonCloseTab;
    }
}

