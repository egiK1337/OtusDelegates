namespace OtusDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SearchElement.Start();

            var fileLister = new Filesearch();

            int filesFound = 0;

            List<string> filenames = new List<string>();

            EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
            {
                filenames.Add(eventArgs.FoundFile);

                eventArgs.CancelRequested = false;

                if (eventArgs.FoundFile.Contains(".txt")) eventArgs.CancelRequested = true;

                filesFound++;
            };

            fileLister.FileFound += onFileFound;

            fileLister.Search(@"C:\Users\", "*");

            fileLister.FileFound -= onFileFound;

            Console.WriteLine(String.Join(System.Environment.NewLine, filenames));
            Console.WriteLine("Максимальная длина: " + filenames.Max(filenames => filenames.Length));
            Console.WriteLine("Файл найден: " + filesFound);
            Console.WriteLine(new string('_', 23));
        }
    }
}
