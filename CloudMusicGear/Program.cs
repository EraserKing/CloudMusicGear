using System;
using System.Windows.Forms;
using System.Threading;

namespace CloudMusicGear
{
    internal static class Program
    {
        public static EventWaitHandle ProgramStarted;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool createNew;
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "MyStartEvent", out createNew);

            if(!createNew)
            {
                ProgramStarted.Set();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}