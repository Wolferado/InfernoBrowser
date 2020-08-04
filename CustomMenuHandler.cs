using System;
using CefSharp;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Deployment.Application;
using System.ComponentModel;
using System.IO;
using Syroot.Windows.IO;


public class CustomMenuHandler : IContextMenuHandler
{
    public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
    {
        // Remove any existent option using the Clear method of the model
        //
        //model.Clear();

        Console.WriteLine("Context menu opened !");

        // You can add a separator in case that there are more items on the list
        if (model.Count > 0)
        {
            model.AddSeparator();
        }

        model.AddItem((CefMenuCommand)26501, "Show DevTools");
        model.AddItem((CefMenuCommand)26502, "Close DevTools");

        model.AddSeparator();

        model.AddItem((CefMenuCommand)113, "Copy");

        model.AddItem((CefMenuCommand)26504, "Save image");

        model.AddSeparator();

        model.AddItem((CefMenuCommand)26503, "Display alert message");
    }

    public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
    {

        if (commandId == (CefMenuCommand)26501)
        {
            browser.GetHost().ShowDevTools();
            return true;
        }

        if (commandId == (CefMenuCommand)26502)
        {
            browser.GetHost().CloseDevTools();
            return true;
        }

        if (commandId == (CefMenuCommand)26503)
        {
            MessageBox.Show("An example alert message ?");
            return true;
        }

        if (commandId == (CefMenuCommand)113) // Copy
        {

            if (parameters.LinkUrl.Length > 0)
            {
                Clipboard.SetText(parameters.LinkUrl);
            }
            if (parameters.MediaType == ContextMenuMediaType.Image)
            {
                Clipboard.SetText(parameters.SourceUrl);
            }
        }

        if (commandId == (CefMenuCommand)26504) //Save Image
        {
            if (parameters.LinkUrl.Length > 0)
            {

                Clipboard.SetText(parameters.LinkUrl);

            }
            if (parameters.MediaType == ContextMenuMediaType.Image)
            {
                Download(parameters.SourceUrl);
            }
        }


        // Return false should ignore the selected option of the user !
        return false;
    }

    public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
    {

    }

    public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
    {
        return false;
    }


    //Here you can make different commands

    public void Download(string url)
    {
        string filePath = new KnownFolder(KnownFolderType.Downloads).Path + @"\";
        Console.WriteLine("Downloads folder path: " + filePath);
        string fileAndPath = filePath + Path.GetFileName(url);
        using (WebClient client = new WebClient())
        {
            try
            {
                Uri uri = new Uri(url);
                //method that will say in console when the download is odne
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(Extract);
                // uri is the remote url where filed needs to be downloaded, and fileAndPath is the location where file to be saved
                client.DownloadFileAsync(uri, fileAndPath);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public void Extract(object sender, AsyncCompletedEventArgs e)
    {
        Console.WriteLine("File has been downloaded.");
    }
}