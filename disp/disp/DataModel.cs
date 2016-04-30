﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExifLibrary;

namespace disp
{
    class DataModel
    {
        public List<JPGFileInfo> Fichiers { get; set; }

        public DataModel()
        {
            
        }
        public DataModel(String Chemin)
        {
            Fichiers = new List<JPGFileInfo>();
            string[] fichiers = Directory.GetFiles(Chemin);
            if(fichiers !=null)
                fichiers.ToList().Where(c => c.ToLower().EndsWith("jpg")).ToList().ForEach(c => Fichiers.Add(new JPGFileInfo(c)));
        }


        public List<DirectoryItem> GetItems(string path)
        {
            var items = new List<DirectoryItem>();
            var dirInfo = new DirectoryInfo(path);
            foreach (var directory in dirInfo.GetDirectories())
            {
                var item = new DirectoryItem
                {
                    Name = directory.Name,
                    Path = directory.FullName,
                    Items = GetItems(directory.FullName)
                };
                items.Add(item);
            }
            return items;
        }
    }
}
