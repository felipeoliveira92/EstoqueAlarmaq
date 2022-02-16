using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Services.Repositories;
using System;
using System.Windows.Forms;

namespace EstoqueAlarmaq.Desktop
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

            DataContext context = new DataContext();
            ProductsRepository productsRepository = new ProductsRepository(context);
            Application.Run(new FormHome(context));
        }
    }
}
