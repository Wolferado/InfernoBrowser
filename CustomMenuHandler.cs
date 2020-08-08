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
using System.Diagnostics;
using System.CodeDom.Compiler;

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

        model.AddItem((CefMenuCommand)26501, "Show DevTools"); //Default commands
        model.AddItem((CefMenuCommand)26502, "Close DevTools"); //Default commands

        model.AddSeparator();

        model.AddItem((CefMenuCommand)26506, "Copy Image");
        model.AddItem((CefMenuCommand)26504, "Save image");
        model.AddItem((CefMenuCommand)26505, "Save image as");
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

        if (commandId == (CefMenuCommand)26506) // Copy Image
        {

            //if (parameters.LinkUrl.Length > 0)   (this is for copying a link, ignore this)
            //{

            //    Clipboard.SetText(parameters.LinkUrl);

            //}
            Clipboard.SetText(parameters.SourceUrl);

            string subPath = @"C:\temp";

            System.IO.Directory.CreateDirectory(subPath);

            SaveImage(parameters.SourceUrl);

        }

        if (commandId == (CefMenuCommand)26504) //Save Image
        {
            if (parameters.MediaType == ContextMenuMediaType.Image)
            {
                string downloadFolder = new KnownFolder(KnownFolderType.Downloads).Path;

                Download(parameters.SourceUrl, downloadFolder);
            }
        }

        if (commandId == (CefMenuCommand)26505) //Save as
        {
            var saveDialog = new FolderBrowserDialog();

            DialogResult result = saveDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveDialog.SelectedPath))
            {
                Download(parameters.SourceUrl, saveDialog.SelectedPath);
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

    public void Download(string url, string filePath)
    {
        filePath += @"\";
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

    public void SaveImage(string imageUrl)
    {
        System.Net.WebClient client = new WebClient();
        System.IO.Stream stream = client.OpenRead(imageUrl);
        Bitmap bitmap = new Bitmap(stream);

        if (bitmap != null)
        {
            Clipboard.SetImage(bitmap);
            //bitmap.Save(filename, format);
        }

        string filePath = @"C:\temp";
        bitmap.Dispose();
        foreach (string file in Directory.GetFiles(filePath))
        {
            FileInfo fi = new FileInfo(file);
            if (fi.Name == "temp.bmp")
            {
                fi.Delete();
            }
        }
        stream.Flush();
        stream.Close();
        client.Dispose();
    }
}

