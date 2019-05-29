using Autofac;
using InhospitalIndicators.Service.Services.System;
using InhospitalIndicators.Service.Services.System.Interfaces;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace InhospitalIndicators.Service
{
    static class Program
    {
        private static IContainer Container { get; set; }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterType<ICanSaveFiltersImplemet>().As<ICanSaveFilters>();
            Container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            
        }
    }
}
