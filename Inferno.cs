/*  Datorium Chromium Based Browser Development.
 * 
 *  Name of the project: Inferno Browser.
 * 
 *  Team members count: 10 members.
 * 
 *  ========= _TEAM LEAD_ =========
 *  
 *      Aleksey Karelin (@Wolferado)
 *  
 *  ========= _DEVELOPERS_ =========
 * 
 *      Daria Dolbe (@Glorwen)
 *      IKSAKS (@IKSAKS)
 *      Mark26B (@Mark26)
 *      MrCiny (@nicky)
 *      MateoPs (@osioss)
 *      TheRealPancakeman (@the_real_pancakeman)
 *  
 *  ========= _DESIGNERS_ =========
 *  
 *      AlexandrJR (@.alex)
 *      Daria Dolbe (@Glorwen)
 *      Mark26B (@Mark26)
 *      MateoPs (@osioss)
 *      Strykeros (@Strykeros)
 *      ProfesorGarfieldII (@Arvils)
 *  
 *  ========= _C# TUTOR AND SUPPORT_ =========
 *  
 *      Elchin Jafarov (@datorium)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Example.Handlers;
using CefSharp.WinForms;
using System.IO;
using InfernoBrowser.Properties;
using System.Linq.Expressions;

namespace InfernoBrowser
{
    public partial class Inferno : Form
    {
        private ChromiumWebBrowser browser;
        DownloadHandler downHandler = new DownloadHandler();
        ExtensionsWindow extwin = new ExtensionsWindow();
        CustomMenuHandler mainMenuHandler = new CustomMenuHandler();
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\source\repos\InfernoBrowser\Resources\";
        string[] domains = { ".com", ".uk", ".de", ".ru", ".org", ".net", ".in", ".ir", ".br", ".au", ".eu" };
        private bool incognitoMode = false;
        string pageTitle = "Main Page";

        Timer backBtnTimer = new Timer();
        Timer forwardBtnTimer = new Timer();
        Timer reloadBtnTimer = new Timer();
        Timer goBtnTimer = new Timer();
        Timer historyBtnTimer = new Timer();
        Timer closeTabBtnTimer = new Timer();

        private int backBtnCounter = 1;
        private int forwardBtnCounter = 1;
        private int reloadBtnCounter = 1;
        private int goBtnCounter = 1;
        private int historyBtnCounter = 1;
        private int closeTabBtnCounter = 1;

        public Inferno()
        {
            InitializeComponent();
            InitializeBrowser();
            InitializeForm();
            InitializeExtensionsWindow();

            InitializeForwardBtnTimer();
            InitializeBackwardBtnTimer();
            InitializeReloadBtnTimer();
            InitializeGoBtnTimer();
            InitializeCloseTabBtnTimer();
            InitializeHistoryBtnTimer();
        }

        private void InitializeForm()
        {
            BrowserTabs.Height = ClientRectangle.Height - 25;
            isOpen = true;
        }

        private void InitializeHandlers()
        {
            browser.DownloadHandler = downHandler; //Enabling Download feature through links. (SRC: DownloadHandler.cs)
            browser.MenuHandler = mainMenuHandler; //Enables custom context menu. Right click on the browser to see it. (SRC: CustomMenuHandler.cs)
        }

        private void InitializeBrowser()
        {
            Cef.Initialize(new CefSettings());

            AddBrowser();
            BrowserTabs.TabPages[0].Controls.Add(browser);

            //Creating "History.html" file
            if (!File.Exists(docPath + "History.html"))
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "History.html")))
                {
                    outputFile.WriteLine("<!DOCTYPE html><html><head><title>History</title><link rel='stylesheet' href='History_Style.css'><link href='https://fonts.googleapis.com/css2?family=Aladin&display=swap' rel='stylesheet'></head><body><h1 style='text-align: center'>Browser History</h1><ul><hr/><div class='historyList'></div></div></body></html>");
                }
            }
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
            selectedBrowser.Back();
            Navigate(toolStripAddressBar.Text);
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
            selectedBrowser.Back();
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
            selectedBrowser.Forward();
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
            selectedBrowser.Reload();
        }

        //Method to close all tabs and open 1 new tab (Close And Open or C.A.O.). Solved by @IKSAKS.
        private void toolStripButtonCloseAndOpen_Click(object sender, EventArgs e)
        {
            int tabCount = BrowserTabs.TabPages.Count - 1;

            for (int i = 0; i < tabCount; i++)
            {
                BrowserTabs.TabPages.Remove(BrowserTabs.SelectedTab);
            }
            AddBrowserTab();
            BrowserTabs.SelectTab(0);
        }

        private void toolStripAddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(toolStripAddressBar.Text);
                e.SuppressKeyPress = true; //Feature to disable "beep" sound when hitting "Enter". Solved by @nicky.
            }
        }

        //Method to close the selected tab with the warning. Solved by @IKSAKS.
        private void toolStripButtonCloseTab_Click(object sender, EventArgs e)
        {
            int tabCount = BrowserTabs.TabPages.Count - 1;
            if (tabCount > 1)
            {
                BrowserTabs.TabPages.Remove(BrowserTabs.SelectedTab);
            }
            else
            {
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Are you sure you want to close this browser?", title, buttons);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        //Method designed to enable and disable "Incognito Mode". Suggested and developed by @Wolferado.
        private void toolStripButtonIncognito_Click(object sender, EventArgs e)
        {
            if (incognitoMode == false)
            {
                incognitoMode = true;
                toolStripButtonIncognito.Image = Resources.Incognito_On;
                Inferno.ActiveForm.Text = "InfernoBrowser (Incognito Mode)";
            }
            else
            {
                incognitoMode = false;
                toolStripButtonIncognito.Image = Resources.Incognito_Off;
                Inferno.ActiveForm.Text = "InfernoBrowser";
            }
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                selectedBrowser.Parent.Text = e.Title;
                pageTitle = selectedBrowser.Parent.Text;
            }));

            AddToHistory(toolStripAddressBar.Text, pageTitle);
        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            //Added try & catch statement to prevent causing an error when exiting browser with 2 or more tabs. (SRC: InfernoBrowser_FormClosing method)
            try
            {
                var selectedBrowser = (ChromiumWebBrowser)sender;
                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripAddressBar.Text = e.Address;
                }));
            }
            catch
            {

            }
        }

        private void Navigate(string address)
        {
            try
            {
                var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];

                //IF statement which defines if Address Bar contains a domain. Suggested and developed by @Arvils.
                if (domains.Any(toolStripAddressBar.Text.Contains))
                {
                    selectedBrowser.Load(toolStripAddressBar.Text);
                }
                else
                {
                    selectedBrowser.Load("https://duckduckgo.com/?q=" + toolStripAddressBar.Text);
                }
            }
            catch
            {

            }
        }

        private void AddBrowser()
        {
            //Getting resources folder path, so it would open Main Page at any PC. Developed by @Wolferado.
            var mainPagePath = docPath + "Inferno_Main_Page.html";

            browser = new ChromiumWebBrowser(mainPagePath);
            browser.Dock = DockStyle.Fill;
            browser.AddressChanged += Browser_AddressChanged;
            browser.TitleChanged += Browser_TitleChanged;

            InitializeHandlers();
        }

        private void AddBrowserTab()
        {
            var newTabPage = new TabPage();
            newTabPage.Text = "New Tab";
            BrowserTabs.TabPages.Insert(BrowserTabs.TabPages.Count - 1, newTabPage);
            AddBrowser();
            newTabPage.Controls.Add(browser);
        }

        private void BrowserTabs_Click(object sender, EventArgs e)
        {
            if (BrowserTabs.SelectedTab == BrowserTabs.TabPages[BrowserTabs.TabPages.Count - 1])
            {
                AddBrowserTab();
                BrowserTabs.SelectedTab = BrowserTabs.TabPages[BrowserTabs.TabPages.Count - 2];
            }

            //Feature to display in Address Bar on which page you are currently on. Solved by @nicky.
            if (BrowserTabs.SelectedTab != BrowserTabs.TabPages[BrowserTabs.TabPages.Count - 1])
            {
                var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];

                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripAddressBar.Text = selectedBrowser.Address;
                }));
            }
        }

        //Method to display a warning when exiting a browser with 2 or more tabs. Solved by @Wolferado.
        private void Inferno_FormClosing(object sender, FormClosingEventArgs e)
        {
            int tabCount = BrowserTabs.TabPages.Count - 1;
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            if (tabCount > 1)
            {
                DialogResult result = MessageBox.Show("You are about to close " + tabCount + " tabs. Are you sure you want to continue?", title, buttons);

                if (result == DialogResult.Yes)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        //Method for enabling and disabling buttons animations.
        private void EnableOrDisableButtonsAnimations(object sender, EventArgs e)
        {
            if(animationCheck.Checked == true)
            {
                toolStripButtonBack.MouseEnter += StartBackwardBtnTimer;
                toolStripButtonForward.MouseEnter += StartForwardBtnTimer;
                toolStripButtonReload.MouseEnter += StartReloadBtnTimer;
                toolStripButtonBrowse.MouseEnter += StartGoBtnTimer;
                toolStripButtonCloseTab.MouseEnter += StartCloseTabBtnTimer;
                toolStripButtonHistory.MouseEnter += StartHistoryBtnTimer;

                backBtnTimer.Start();
                forwardBtnTimer.Start();
                reloadBtnTimer.Start();
                goBtnTimer.Start();
                closeTabBtnTimer.Start();
                historyBtnTimer.Start();
            }
            else
            {
                toolStripButtonBack.MouseEnter -= StartBackwardBtnTimer;
                toolStripButtonForward.MouseEnter -= StartForwardBtnTimer;
                toolStripButtonReload.MouseEnter -= StartReloadBtnTimer;
                toolStripButtonBrowse.MouseEnter -= StartGoBtnTimer;
                toolStripButtonCloseTab.MouseEnter -= StartCloseTabBtnTimer;
                toolStripButtonHistory.MouseEnter -= StartHistoryBtnTimer;
            }
        }

        //Methods to register visited links in the "History.html". Solved by @Glorwen.
        private void toolStripButtonHistory_Click(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "History.html"), true))
            {
                outputFile.WriteLine("</ul></body></html>");
            }
            Navigate(docPath + "History.html");

            //render the html page that was made
            string historyHtmlPage = File.ReadAllText(docPath + "History.html");
            historyHtmlPage = historyHtmlPage.Replace("</ul></body></html>", "");
            File.WriteAllText(docPath + "History.html", historyHtmlPage);
            toolStripAddressBar.Text = "History";
            LoadCustomHTML(historyHtmlPage);
        }

        private void LoadCustomHTML(string htmlContent)
        {
            /*var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
            selectedBrowser.LoadHtml(htmlContent);*/
            
            var selectedTabPage = (TabPage)BrowserTabs.SelectedTab;
            var selectedBrowser = (ChromiumWebBrowser)selectedTabPage.Controls[0];
            selectedBrowser.LoadHtml(htmlContent);
        }

        private void AddToHistory(string url, string pageTitle)
        {
            if (incognitoMode == false)
            {
                if (toolStripAddressBar.Text.Contains(docPath))
                {
                    return;
                }
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "History.html"), true))
                {
                    outputFile.WriteLine($"<li>{DateTime.Now}<a href={url}>{pageTitle}</a></li>");
                }
            }
            else if (incognitoMode == true)
            {

            }
        }

        //Methods and variables for Extensions to work. Developed by @Strykeros.
        public bool isOpen { get; set; }

        private void InitializeExtensionsWindow()
        {
            extwin.InitializeExtWin();
            extwin.Height = 250;
            extwin.Width = 250;
        }

        private void ExtensionsPicBox_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                extwin.Show();
                animationCheck.Visible = true;
            }
            else
            {
                extwin.Hide();
                animationCheck.Visible = false;
            }
            isOpen = !isOpen;
        }

        private void Inferno_LocationChanged(object sender, EventArgs e)
        {
            ChangeExtWinLoc();
        }

        private void ChangeExtWinLoc()
        {
            extwin.Top = this.Top + 60;
            extwin.Left = this.Left + (this.Width - 160);

            //Changing checkbox's location when size of the form is changed
            animationCheck.Location = new Point(toolStrip1.Width - 190, toolStrip1.Top + 8);
            animationCheck.BringToFront();
            //Hiding checkbox when it bounds with toolstrip's buttons
            if (animationCheck.Bounds.IntersectsWith(toolStripButtonIncognito.Bounds))
            {
                animationCheck.Hide();
            }
            else if(animationCheck.Bounds.IntersectsWith(toolStripButtonCloseAndOpen.Bounds))
            {
                animationCheck.Hide();
            }
            else
            {
                animationCheck.Show();
            }
            //Hiding extension's picture box when it boudns with toolstrip's buttons
            if (extensiosPicBox.Bounds.IntersectsWith(toolStripButtonIncognito.Bounds))
            {
                extensiosPicBox.Hide();
            }
            else
            {
                extensiosPicBox.Show();
            }
        }

        private void ChangeExtButtonLoc(object sender, EventArgs e)
        {
            extensiosPicBox.Left = toolStrip1.Width - 42;
            ChangeExtWinLoc();
        }

        //Timers for buttons animations. Icons by @Arvils. Code prototype by @Strykeros. Polished by @Wolferado.
        private void InitializeForwardBtnTimer()
        {
            forwardBtnTimer.Interval = 40;
            forwardBtnTimer.Tick += ForwardBtnTimer_Tick;
        }

        private void StartForwardBtnTimer(object sender, EventArgs e) 
        {
            forwardBtnTimer.Start();
        }

        private void InitializeBackwardBtnTimer()
        {
            backBtnTimer.Interval = 40;
            backBtnTimer.Tick += BackwardBtnTimer_Tick;
        }

        private void StartBackwardBtnTimer(object sender, EventArgs e)
        {
            backBtnTimer.Start();
        }

        private void InitializeReloadBtnTimer()
        {
            reloadBtnTimer.Interval = 70;
            reloadBtnTimer.Tick += ReloadBtnTimer_Tick;
        }

        private void StartReloadBtnTimer(object sender, EventArgs e)
        {
            reloadBtnTimer.Start();
        }

        private void InitializeGoBtnTimer()
        {
            goBtnTimer.Interval = 50;
            goBtnTimer.Tick += GoBtnTimer_Tick;
        }

        private void StartGoBtnTimer(object sender, EventArgs e)
        {
            goBtnTimer.Start();
        }

        private void InitializeHistoryBtnTimer()
        {
            historyBtnTimer.Interval = 70;
            historyBtnTimer.Tick += HistoryBtnTimer_Tick;
        }

        private void StartHistoryBtnTimer(object sender, EventArgs e)
        {
            historyBtnTimer.Start();
        }

        private void InitializeCloseTabBtnTimer()
        {
            closeTabBtnTimer.Interval = 60;
            closeTabBtnTimer.Tick += CloseTabBtnTimer_Tick;
        }

        private void StartCloseTabBtnTimer(object sender, EventArgs e)
        {
            closeTabBtnTimer.Start();
        }

        private void ForwardBtnTimer_Tick(object sender, EventArgs e)
        {
            toolStripButtonForward.Image = (Image)Resources.ResourceManager.GetObject("navbtn_forwards_" + forwardBtnCounter);
            forwardBtnCounter++;
            if(forwardBtnCounter == 16)
            {
                forwardBtnTimer.Stop();
                forwardBtnCounter = 1;
                toolStripButtonForward.Image = (Image)Resources.ResourceManager.GetObject("navbtn_forwards_" + forwardBtnCounter);
            }
        }

        private void BackwardBtnTimer_Tick(object sender, EventArgs e)
        {
            toolStripButtonBack.Image = (Image)Resources.ResourceManager.GetObject("navbtn_backwards_" + backBtnCounter);
            backBtnCounter++;
            if (backBtnCounter == 16)
            {
                backBtnTimer.Stop();
                backBtnCounter = 1;
                toolStripButtonBack.Image = (Image)Resources.ResourceManager.GetObject("navbtn_backwards_" + backBtnCounter);
            }
        }

        private void ReloadBtnTimer_Tick(object sender, EventArgs e)
        {
            toolStripButtonReload.Image = (Image)Resources.ResourceManager.GetObject("navbtn_reload_" + reloadBtnCounter);
            reloadBtnCounter++;
            if (reloadBtnCounter == 11)
            {
                reloadBtnTimer.Stop();
                reloadBtnCounter = 1;
                toolStripButtonReload.Image = (Image)Resources.ResourceManager.GetObject("navbtn_reload_" + reloadBtnCounter);
            }
        }

        private void GoBtnTimer_Tick(object sender, EventArgs e)
        {
            toolStripButtonBrowse.Image = (Image)Resources.ResourceManager.GetObject("navbtn_go_" + goBtnCounter);
            goBtnCounter++;
            if (goBtnCounter == 12)
            {
                goBtnTimer.Stop();
                goBtnCounter = 1;
                toolStripButtonBrowse.Image = (Image)Resources.ResourceManager.GetObject("navbtn_go_" + goBtnCounter);
            }
        }

        private void HistoryBtnTimer_Tick(object sender, EventArgs e)
        {
            toolStripButtonHistory.Image = (Image)Resources.ResourceManager.GetObject("navbtn_history_" + historyBtnCounter);
            historyBtnCounter++;
            if (historyBtnCounter == 9)
            {
                historyBtnTimer.Stop();
                historyBtnCounter = 1;
                toolStripButtonHistory.Image = (Image)Resources.ResourceManager.GetObject("navbtn_history_" + historyBtnCounter);
            }
        }

        private void CloseTabBtnTimer_Tick(object sender, EventArgs e)
        {
            toolStripButtonCloseTab.Image = (Image)Resources.ResourceManager.GetObject("navbtn_delete_" + closeTabBtnCounter);
            closeTabBtnCounter++;
            if (closeTabBtnCounter == 9)
            {
                closeTabBtnTimer.Stop();
                closeTabBtnCounter = 1;
                toolStripButtonCloseTab.Image = (Image)Resources.ResourceManager.GetObject("navbtn_delete_" + closeTabBtnCounter);
            }
        }
    }
}
