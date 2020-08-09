﻿/*  Datorium Chromium Based Browser Development.
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

namespace InfernoBrowser
{
    public partial class Inferno : Form
    {
        private ChromiumWebBrowser browser;
        DownloadHandler downHandler = new DownloadHandler();
        ExtensionsWindow extwin = new ExtensionsWindow();
        CustomMenuHandler mainMenuHandler = new CustomMenuHandler();
        string docPath = @"C:\Users\Public\Documents\";
        public Inferno()
        {
            InitializeComponent();
            InitializeBrowser();
            InitializeForm();
            InitializeExtensionswindow();
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

        private void InitializeExtensionswindow()
        {
            extwin.InitializeExtWin();
            extwin.Height = 250;
            extwin.Width = 250;
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            Navigate(toolStripAddressBar.Text);
            AddToHistory(toolStripAddressBar.Text);
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            browser.Back();
            AddToHistory(toolStripAddressBar.Text);
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
            AddToHistory(toolStripAddressBar.Text);
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

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                selectedBrowser.Parent.Text = e.Title;
            }));
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            browser.Reload();
        }

        private void toolStripAddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(toolStripAddressBar.Text);
                e.SuppressKeyPress = true; //Feature to disable "beep" sound when hitting "Enter". Solved by @nicky.
                AddToHistory(toolStripAddressBar.Text);
            }
        }

        private void Navigate(string address)
        {
            try
            {
                var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
                selectedBrowser.Load(address);
            }
            catch
            {

            }
        }

        private void toolStripButtonAddTab_Click(object sender, EventArgs e)
        {
            AddBrowserTab();
            BrowserTabs.SelectedTab = BrowserTabs.TabPages[BrowserTabs.TabPages.Count - 2];
        }

        private void AddBrowser()
        {
            browser = new ChromiumWebBrowser("https://datorium.eu");
            browser.Dock = DockStyle.Fill;
            browser.AddressChanged += Browser_AddressChanged;
            browser.TitleChanged += Browser_TitleChanged;
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

        public bool isOpen { get; set; }
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
            extwin.Top = this.Top + 55;
            extwin.Left = this.Left + 440;
        }
        
        //Methods to register visited links in the history.html. Solved by @Glorwen.
        
        private void toolStripButtonHistory_Click(object sender, EventArgs e)
        {
            AddBrowserTab();
            toolStripAddressBar.Text = "History";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "History.html"), true))
            {
                outputFile.WriteLine("</ul></body></html>");
            }
            Navigate(docPath + "History.html");
            
            //Render the html page that was made
            string historyHtmlPage = File.ReadAllText(docPath + "History.html");
            LoadCustomHTML(historyHtmlPage);
            historyHtmlPage = historyHtmlPage.Replace("</ul></body></html>", "");
            File.WriteAllText(docPath + "History.html", historyHtmlPage);

        }

        private void LoadCustomHTML(string htmlContent)
        {
            var selectedTabPage = (TabPage)BrowserTabs.SelectedTab;
            var selectedBrowser = (ChromiumWebBrowser)selectedTabPage.Controls[0];
            selectedBrowser.LoadHtml(htmlContent);
        }

        private void AddToHistory(string url)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "History.html"), true))
            {
                outputFile.WriteLine($"<li>{DateTime.Now} {url}</li>");
            }

        }
    }
}
