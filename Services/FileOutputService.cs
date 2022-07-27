using Lxqtpr.Calculator.Shell.Services.Base;

namespace Lxqtpr.Calculator.Shell.Services;

public class FileOutputService : OutputServiceBase
{
    private const string FileName = "output.txt";
    private const string FolderName = "Logs";
    
    protected override void Output(string message)
    {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using var file = File.AppendText(Path.Combine(path, FileName));
            file.WriteLine(message);
    }
}