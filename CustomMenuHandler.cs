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
using InfernoBrowser;
using CefSharp.Example.Handlers;

public class CustomMenuHandler : IContextMenuHandler
{
    string filter = null;
    bool result = false;

    SaveFileDialog saveFile;
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

        model.AddItem((CefMenuCommand)26506, "Copy Image");
        model.AddItem((CefMenuCommand)26504, "Save image");
        model.AddItem((CefMenuCommand)26505, "Save image as");
    }

    public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
    {
        if (commandId == (CefMenuCommand)26506) // Copy Image
        {

            //if (parameters.LinkUrl.Length > 0)   (this is for copying a link, ignore this)
            //{

            //    Clipboard.SetText(parameters.LinkUrl);

            //}


            Clipboard.SetText(parameters.SourceUrl);

            string subPath = @"C:\temp";

            System.IO.Directory.CreateDirectory(subPath);

            CopyImage(parameters.SourceUrl);
        }

        if (commandId == (CefMenuCommand)26504) //Save Image
        {
            string downloadFolder = new KnownFolder(KnownFolderType.Downloads).Path;
            var fileName = Path.GetFileName(parameters.SourceUrl);

            Download(parameters.SourceUrl, downloadFolder, fileName);
        }

        if (commandId == (CefMenuCommand)26505) //Save as
        {
            SaveFileAs(parameters);

            if (result)
            {
                string filePath = Path.GetDirectoryName(saveFile.FileName);
                var fileName = Path.GetFileName(saveFile.FileName);

                Download(parameters.SourceUrl, filePath, fileName);
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

    public void Download(string url, string filePath, string fileName)
    {
        if(result != true)
        {
            return;
        }
        filePath += @"\";
        Console.WriteLine("Downloads folder path: " + filePath);
        string fileAndPath = filePath + fileName;
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

    public void CopyImage(string imageUrl)
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

    private void SaveFileAs(IContextMenuParams parameters) //In the future this can/will be made to download universal files
    {
        CheckTheFilter(parameters);
        saveFile = new SaveFileDialog();
        saveFile.Title = "Save an image file";
        saveFile.Filter = filter;
        saveFile.FileName = Path.GetFileNameWithoutExtension(parameters.SourceUrl);

        DialogResult dialogResult = saveFile.ShowDialog();
        if (dialogResult == DialogResult.OK)
        {
            result = true;
        }
    }

    private void CheckTheFilter(IContextMenuParams parameters)//It checks the files filter/format (for now it only support Images) :D
    {
        var easyVar = Path.GetExtension(parameters.SourceUrl);

        var filterDictionary = new Dictionary<string, string>(){
            {".png", "PNG Image"},
            {".bmp", "Bitmap Image"},
            {".gif", "Gif Image"},
            {".jpeg", "JPEG Image"},
            {".tiff", "Tiff Image"},
            {".wmf", "Wmf Image"}
        };

        for (int i = 0; i < filterDictionary.Count; i++)
        {
            if (easyVar == filterDictionary.ElementAt(i).Key)
            {
                string key = filterDictionary.ElementAt(i).Key;
                string value = filterDictionary.ElementAt(i).Value;

                filter = $"{value} |{key}";
            }
        }
    }
}

