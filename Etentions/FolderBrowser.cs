using Microsoft.WindowsAPICodePack.Dialogs;

namespace AutoFilesAcceptence.Etentions
{
    internal static class FolderBrowser
    {
        public static string GetSelectedPath()
        {
            using (var directoryDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Multiselect = false,
                Title = "Select Folder"
            })
            {
                var directoryPath = (directoryDialog.ShowDialog() != CommonFileDialogResult.Ok) ? null : directoryDialog.FileName;
                return directoryPath;
            }
        }
    }
}
