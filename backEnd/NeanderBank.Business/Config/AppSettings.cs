using NeanderBank.Business.Models;
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

        public static Dictionary<Type, Dictionary<string, int>> StringLengths = new Dictionary<Type, Dictionary<string, int>>()
        {
            {typeof(Costumer),new Dictionary<string, int>(){
                {nameof(Costumer.Name), 100 },
                {nameof(Costumer.CPF), 11 },
                {nameof(Costumer.Address), 100 },
                {nameof(Costumer.Neighboorhood), 50 },
                {nameof(Costumer.City), 30 },
                {nameof(Costumer.State), 30 },
                {nameof(Costumer.CEP), 8 }
            } },

            {typeof(Account),new Dictionary<string, int>(){
                {nameof(Account.Number), 9 },
                {nameof(Account.Password), 8 },
                {nameof(Account.Agency), 4 }
            } }
        };
    }
}
