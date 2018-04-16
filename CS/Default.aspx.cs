using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    Dictionary<String, String> extensionsDisplayName;

    Dictionary<String, String> ExtensionsDisplayName {
        get {
            if (extensionsDisplayName == null) {
                extensionsDisplayName = new Dictionary<String, String>();
                extensionsDisplayName.Add(".txt", "Text Document (.txt)");
                extensionsDisplayName.Add(".rtf", "Rich Text Document (.rtf)");
                extensionsDisplayName.Add(".xml", "XML File (.xml)");
                extensionsDisplayName.Add(".png", "PNG image (.png)");
                extensionsDisplayName.Add(".jpg", "JPEG image (.jpg)");
                extensionsDisplayName.Add(".mp3", "MPEG Layer 3 Audio File (.mp3)");
                extensionsDisplayName.Add(".avi", "AVI File (.avi)");
                extensionsDisplayName.Add(".zip", "Compressed (zipped) Folder (.zip)");
            }
            return extensionsDisplayName;
        }
    }

    public string GetItemName(FileManagerItem item) {
        if (item == null)
            return String.Empty;
        FileManagerFile file = item as FileManagerFile;
        if (file != null)
            return Path.GetFileNameWithoutExtension(file.RelativeName);
        else
            return item.Name;
    }
    public string GetItemType(FileManagerItem item) {
        if (item == null) return String.Empty;
        FileManagerFile file = item as FileManagerFile;
        if (file != null) {
            if (ExtensionsDisplayName.ContainsKey(file.Extension))
                return ExtensionsDisplayName[file.Extension];
        }
        else {
            return item.Name.Equals("..") ? String.Empty : "Folder";
        }
        return String.Empty;
    }

    public string GetSize(FileManagerItem item) {
        if (item == null) return String.Empty;
        FileManagerFolder folder = item as FileManagerFolder;
        if (folder != null) {
            if (folder.Name.Equals(".."))
                return String.Empty;
            else
                return string.Format("{0:f} Kb", CountFolderSize(folder) / 1024);
        }
        return item.Length / 1024 + " Kb";
    }

    private float CountFolderSize(FileManagerFolder folder, float length = 0) {
        FileManagerFile[] files = folder.GetFiles();
        foreach (FileManagerFile file in files)
            length += file.Length;

        FileManagerFolder[] folders = folder.GetFolders();
        foreach (FileManagerFolder childFolder in folders)
            length = CountFolderSize(childFolder, length);
        return length;
    }
}