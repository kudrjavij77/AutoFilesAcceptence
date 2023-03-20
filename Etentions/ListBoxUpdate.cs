using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoFilesAcceptence.Etentions
{
    internal static class ListBoxUpdate
    {
        public static void UpdateItemsOfCheckedListBox(CheckedListBox obj, List<string> list)
        {
            obj.Items.Clear();
            obj.Items.AddRange(list.ToArray());
            obj.Refresh();
        }
    }
}
