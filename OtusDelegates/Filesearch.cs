namespace OtusDelegates
{
    //2.Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
    //3.Оформить событие и его аргументы с использованием .NET соглашений:
    //public event EventHandler FileFound;
    //FileArgs – будет содержать имя файла и наследоваться от EventArgs
    //4.	Добавить возможность отмены дальнейшего поиска из обработчика;
    //5.Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.

    public class Filesearch
    {
        public event EventHandler<FileFoundArgs> FileFound;

        private System.Timers.Timer _timer;

        public void Search(string directory, string searchPattern)
        {

            _timer = new System.Timers.Timer(3000) { };
            _timer.Interval = 500;

            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                var fileargs = PutUpFileFound(file);

                Console.WriteLine("Файл найден");

                if (fileargs.CancelRequested) { break; }
            }
        }

        private FileFoundArgs PutUpFileFound(string fileName)
        {
            var args = new FileFoundArgs(fileName);

            FileFound?.Invoke(this, args);

            return args;
        }
    }
}
