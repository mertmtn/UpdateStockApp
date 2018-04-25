using System;
using System.IO;

namespace UpdateStockApp.Methods.DatabaseMethods
{
    public class Backup
    {
        public static void DbBackup()
        { 
            string query = "BACKUP DATABASE UpdateStock TO DISK='C:\\Yedek\\BackUpUpdateStock-" + DateTime.Now.ToString("yyyy MM dd HH mm ss") + ".bak'";
            ExecuteMethods.ExecuteNonQuery(query);
        }

        public static void CreateBackUpDirectory()
        {
            if (!Directory.Exists(@"C:\Yedek"))
            {
                Directory.CreateDirectory(@"C:\Yedek");
                DbBackup();
            }
            else
            {
                DbBackup();
            }
        }


       

    }
}