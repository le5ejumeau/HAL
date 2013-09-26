using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HAL.Library.DomainModel;

namespace HAL.Library
{
    public static class LogService
    {

        private static String path
        {
            get { return Environment.CurrentDirectory + @"\" + DateTime.Now.ToString("YYYYmmdd") + "_log.txt"; }
        }

        private static void CheckExist()
        {
            if (File.Exists(path))
                File.Create(path);
        }

        public async static void Write(String message)
        {
            CheckExist();

            using (StreamWriter file = new StreamWriter(path, true))
            {
                await file.WriteAsync(message);
            }
                
        }
    }
}
