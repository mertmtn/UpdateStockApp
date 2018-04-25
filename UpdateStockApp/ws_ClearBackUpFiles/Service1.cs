using System;
using System.IO;
using System.ServiceProcess;

namespace ws_ClearBackUpFiles
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        System.Timers.Timer timer = new System.Timers.Timer();

        protected override void OnStart(string[] args)
        {

            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 7 * 24 * 60 * 60 ; //1 hafta kaç saniyedir.
            timer.Start();

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ClearFile();
        }



        public static void ClearFile()
        {
            string[] files = Directory.GetFiles(@"C:\Yedek");

            Array.ForEach(files, File.Delete);

            Console.ReadKey();
        }


        protected override void OnStop()
        {
            timer.Enabled = false;
        }
    }
}
