using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkovWeb.Models
{
    public class MarkovChain
    {
        public string SourceText { get; set; }
        public string StartWord { get; set; }
        public int OutputLength { get; set; }
    }
}
