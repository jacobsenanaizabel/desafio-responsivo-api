﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSPA.Models
{
    public class Item : Base
    {
        public String Label { get; set; }
        public String Url { get; set; }
        public SubItem SubItm { get; set; }
    }
}
