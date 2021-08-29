using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIWinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            // Config log
            var isForm1 = Matching.FromSource<Form1>();
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Logger(lc => lc
                        .Filter.ByIncludingOnly(isForm1)
                        .MinimumLevel.Verbose()
                        .WriteTo.File("first.txt"))
                    .WriteTo.Logger(lc => lc
                        .Filter.ByExcluding(isForm1)
                        .WriteTo.File("other.txt"))
                    .CreateLogger();

            Config.IoC.Init();
            var frmMain = Config.IoC.GetForm<Form1>();

            Application.ThreadException += Application_ThreadException;

            Application.Run(frmMain);

        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error");
        }
    }
}
