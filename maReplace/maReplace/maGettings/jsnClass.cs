using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maReplace
{
    public sealed class jsnClass
    {
        public string index { get; set; }

        public fileClass fiVesClass { get; set; }
    }

    public class fileClass
    {
        public  string sourcefile{get;set;}

        public string destfile{get;set;}
    }
}
