
namespace OtusDelegates
{
    public class FileFoundArgs : EventArgs
    {
        public string FoundFile { get; }

        public bool CancelRequested { get; set; }

        public event EventHandler<FileFoundArgs> FileFound;

        public FileFoundArgs(string fileName) => FoundFile = fileName;
    }
}
