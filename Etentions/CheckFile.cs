using System.IO;

namespace AutoFilesAcceptence.Etentions
{
    public class CheckFile
    {
        public bool IsLocked(string path)
        {
            var fileInfo = new FileInfo(path);

            try
            {
                using (var fs = fileInfo.OpenRead())
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}
