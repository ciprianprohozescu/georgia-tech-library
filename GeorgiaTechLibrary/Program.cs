using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using GeorgiaTechLibrary.Model;

namespace GeorgiaTechLibrary
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();

        // DB connection test
        // private static void Main()
        // {
        //     var db = new GeorgiaTechLibraryContext();
        //     Console.WriteLine("Querying for an address");
        //     var address = db.Addresses
        //                 .OrderBy(b => b.Id)
        //                 .FirstOrDefault();
        //     Console.WriteLine(address);
        // }
    }
}
