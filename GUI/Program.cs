using System;
using System.Windows.Forms;

namespace GUI
{
    public sealed class SpreadsheetApplicationContext : ApplicationContext
    {
        private int _openForms;
        private static readonly Lazy<SpreadsheetApplicationContext> _lazy =
            new(() => new SpreadsheetApplicationContext());

        public static SpreadsheetApplicationContext getAppContext() => _lazy.Value;

        private SpreadsheetApplicationContext() { }

        public void RunForm(Form form)
        {
            _openForms++;
            form.FormClosed += (_, __) =>
            {
                if (--_openForms <= 0) ExitThread();
            };
            form.Show();
        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            SpreadsheetApplicationContext.getAppContext().RunForm(new SpreadsheetGUI());
            Application.Run(SpreadsheetApplicationContext.getAppContext());
        }
    }
}