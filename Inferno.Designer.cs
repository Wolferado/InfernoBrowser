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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripAddressBar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonBrowse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCloseTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCloseAndOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonIncognito = new System.Windows.Forms.ToolStripButton();
            this.BrowserTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.extensiosPicBox = new System.Windows.Forms.PictureBox();
            this.animationCheck = new System.Windows.Forms.CheckBox();
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
            this.toolStripSeparator1,
            this.toolStripButtonReload,
            this.toolStripAddressBar,
            this.toolStripButtonBrowse,
            this.toolStripSeparator2,
            this.toolStripButtonCloseTab,
            this.toolStripSeparator3,
            this.toolStripButtonHistory,
            this.toolStripSeparator5,
            this.toolStripButtonCloseAndOpen,
            this.toolStripSeparator4,
            this.toolStripButtonIncognito});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBack.Image = global::InfernoBrowser.Properties.Resources.navbtn_backwards_1;
            resources.ApplyResources(this.toolStripButtonBack, "toolStripButtonBack");
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Click += new System.EventHandler(this.toolStripButtonBack_Click);
            this.toolStripButtonBack.MouseEnter += new System.EventHandler(this.StartBackwardBtnTimer);
            // 
            // toolStripButtonForward
            // 
            this.toolStripButtonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonForward.Image = global::InfernoBrowser.Properties.Resources.navbtn_forwards_1;
            resources.ApplyResources(this.toolStripButtonForward, "toolStripButtonForward");
            this.toolStripButtonForward.Name = "toolStripButtonForward";
            this.toolStripButtonForward.Click += new System.EventHandler(this.toolStripButtonForward_Click);
            this.toolStripButtonForward.MouseEnter += new System.EventHandler(this.StartForwardBtnTimer);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReload.Image = global::InfernoBrowser.Properties.Resources.navbtn_reload_1;
            resources.ApplyResources(this.toolStripButtonReload, "toolStripButtonReload");
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Click += new System.EventHandler(this.toolStripButtonReload_Click);
            this.toolStripButtonReload.MouseEnter += new System.EventHandler(this.StartReloadBtnTimer);
            // 
            // toolStripAddressBar
            // 
            this.toolStripAddressBar.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripAddressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.toolStripAddressBar, "toolStripAddressBar");
            this.toolStripAddressBar.Name = "toolStripAddressBar";
            this.toolStripAddressBar.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.toolStripAddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripAddressBar_KeyDown);
            // 
            // toolStripButtonBrowse
            // 
            this.toolStripButtonBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBrowse.Image = global::InfernoBrowser.Properties.Resources.navbtn_go_1;
            resources.ApplyResources(this.toolStripButtonBrowse, "toolStripButtonBrowse");
            this.toolStripButtonBrowse.Name = "toolStripButtonBrowse";
            this.toolStripButtonBrowse.Click += new System.EventHandler(this.toolStripButtonGo_Click);
            this.toolStripButtonBrowse.MouseEnter += new System.EventHandler(this.StartGoBtnTimer);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButtonCloseTab
            // 
            this.toolStripButtonCloseTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCloseTab.Image = global::InfernoBrowser.Properties.Resources.navbtn_delete_1;
            resources.ApplyResources(this.toolStripButtonCloseTab, "toolStripButtonCloseTab");
            this.toolStripButtonCloseTab.Name = "toolStripButtonCloseTab";
            this.toolStripButtonCloseTab.Click += new System.EventHandler(this.toolStripButtonCloseTab_Click);
            this.toolStripButtonCloseTab.MouseEnter += new System.EventHandler(this.StartCloseTabBtnTimer);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButtonHistory
            // 
            this.toolStripButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHistory.Image = global::InfernoBrowser.Properties.Resources.navbtn_history_1;
            resources.ApplyResources(this.toolStripButtonHistory, "toolStripButtonHistory");
            this.toolStripButtonHistory.Name = "toolStripButtonHistory";
            this.toolStripButtonHistory.Click += new System.EventHandler(this.toolStripButtonHistory_Click);
            this.toolStripButtonHistory.MouseEnter += new System.EventHandler(this.StartHistoryBtnTimer);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripButtonCloseAndOpen
            // 
            this.toolStripButtonCloseAndOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonCloseAndOpen, "toolStripButtonCloseAndOpen");
            this.toolStripButtonCloseAndOpen.Name = "toolStripButtonCloseAndOpen";
            this.toolStripButtonCloseAndOpen.Click += new System.EventHandler(this.toolStripButtonCloseAndOpen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripButtonIncognito
            // 
            this.toolStripButtonIncognito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncognito.Image = global::InfernoBrowser.Properties.Resources.Incognito_Off;
            resources.ApplyResources(this.toolStripButtonIncognito, "toolStripButtonIncognito");
            this.toolStripButtonIncognito.Name = "toolStripButtonIncognito";
            this.toolStripButtonIncognito.Click += new System.EventHandler(this.toolStripButtonIncognito_Click);
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
            // animationCheck
            // 
            resources.ApplyResources(this.animationCheck, "animationCheck");
            this.animationCheck.Checked = true;
            this.animationCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.animationCheck.Name = "animationCheck";
            this.animationCheck.UseVisualStyleBackColor = true;
            this.animationCheck.CheckedChanged += new System.EventHandler(this.EnableOrDisableButtonsAnimations);
            // 
            // Inferno
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.animationCheck);
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
        private System.Windows.Forms.ToolStripButton toolStripButtonBrowse;
        private System.Windows.Forms.PictureBox extensiosPicBox;
        private System.Windows.Forms.ToolStripButton toolStripButtonHistory;
        private System.Windows.Forms.ToolStripButton toolStripButtonCloseAndOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonCloseTab;
        private System.Windows.Forms.ToolStripButton toolStripButtonIncognito;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckBox animationCheck;
    }
}

