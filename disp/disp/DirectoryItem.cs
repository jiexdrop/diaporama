﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disp
{
    public class DirectoryItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<DirectoryItem> Items { get; set; }
        public DirectoryItem()
        {
            Items = new List<DirectoryItem>();
        }

    }
}
