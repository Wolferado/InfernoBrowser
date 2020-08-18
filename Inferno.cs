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

namespace InfernoBrowser
{
    public partial class Inferno : Form
    {
        private ChromiumWebBrowser browser;
        DownloadHandler downHandler = new DownloadHandler();
        ExtensionsWindow extwin = new ExtensionsWindow();
        CustomMenuHandler mainMenuHandler = new CustomMenuHandler();
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\source\repos\InfernoBrowser\Resources\";
        string[] domains = { ".com", ".uk", ".de", ".ru", ".org", ".net", ".in", ".ir", ".br", ".au" };
        public Inferno()
        {
            InitializeComponent();
            InitializeBrowser();
            InitializeForm();
            InitializeExtensionsWindow();
        }

        private void InitializeForm()
        {
            BrowserTabs.Height = ClientRectangle.Height - 25;
            isOpen = true;
        }

        private void InitializeHandlers()
        {
            browser.DownloadHandler = downHandler; //Enabling Download feature through links. (check DownloadHandler.cs)
            browser.MenuHandler = mainMenuHandler; //Enables custom context menu. Right click on the browser to see it. (check CustomMenuHandler.cs)
        }

        private void InitializeBrowser()
        {
            Cef.Initialize(new CefSettings());

            AddBrowser();
            BrowserTabs.TabPages[0].Controls.Add(browser);

            if (!File.Exists(docPath + "History.html"))
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "History.html")))
                {
                    outputFile.WriteLine("<!DOCTYPE html><head><title>History</title></head><body><h1>Browser History</h1><ul></body></html>");
                }
            }
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
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

        //Method to close all tabs and open 1 new tab. Solved by @IKSAKS
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

        private void toolStripButtonAddTab_Click(object sender, EventArgs e)
        {
            AddBrowserTab();
            BrowserTabs.SelectedTab = BrowserTabs.TabPages[BrowserTabs.TabPages.Count - 2];
        }

        //Method to close the selected tab. Solved by @IKSAKS.
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
            AddToHistory(toolStripAddressBar.Text);
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                selectedBrowser.Parent.Text = e.Title;
            }));
        }

        private void Navigate(string address)
        {
            try
            {
                var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];

                if (domains.Any(toolStripAddressBar.Text.Contains)) //IF statement which defines if Address Bar contains domain. Suggested and developed by @Arvils.
                {
                    selectedBrowser.Load(toolStripAddressBar.Text);
                }
                else
                {
                    selectedBrowser.Load("https://www.google.com/search?q=" + toolStripAddressBar.Text + "&rlz=1C1CHBD_lvLV844LV844&oq=" + toolStripAddressBar.Text + "&aqs=chrome..69i57j0l5.12767j1j7&sourceid=chrome&ie=UTF-8");
                }
            }
            catch
            {

            }
        }

        private void AddBrowser()
        {
            var mainPagePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\source\repos\InfernoBrowser\Resources\Inferno_Main_Page.html";

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

        //Methods to register visited links in the history.html. Solved by @Glorwen.
        private void toolStripButtonHistory_Click(object sender, EventArgs e)
        {
            toolStripAddressBar.Text = "History";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "History.html"), true))
            {
                outputFile.WriteLine("</ul></body></html>");
            }
            Navigate(docPath + "History.html");

            //render the html page that was made
            string historyHtmlPage = File.ReadAllText(docPath + "History.html");
            LoadCustomHTML(historyHtmlPage);
            historyHtmlPage = historyHtmlPage.Replace("</ul></body></html>", "");
            File.WriteAllText(docPath + "History.html", historyHtmlPage);
        }

        private void LoadCustomHTML(string htmlContent)
        {
            /*var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
            selectedBrowser.LoadHtml(htmlContent);*/
            var selectedTabPage = (TabPage)BrowserTabs.SelectedTab;
            var selectedBrowser = (ChromiumWebBrowser)selectedTabPage.Controls[0];
            selectedBrowser.LoadHtml(htmlContent);
        }

        private void AddToHistory(string url)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "History.html"), true))
            {
                outputFile.WriteLine($"<li>{DateTime.Now} <a href={url}>{url}</a></li>");
            }
        }

        //Methods and variables for Extensions to work. Solved by @Strykeros.
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
            }
            else
            {
                extwin.Hide();
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
        }

        private void ChangeExtButtonLoc(object sender, EventArgs e)
        {
            extensiosPicBox.Left = toolStrip1.Width - 42;
            ChangeExtWinLoc();
        }
    }
}
