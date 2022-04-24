using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Config
{
    public static class AppSettings
    {
        public static string ProjectRootPath;
        public static void SetSettings()
        {
            ProjectRootPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.FullName;
        }
    }
}
