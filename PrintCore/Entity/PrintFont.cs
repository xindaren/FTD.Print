using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore.Entity
{
    public class PrintFont
    {
        public PrintFont()
        {
            this.Familie = "微软雅黑";
        }
          
        public int Size { set; get; }

        public int Weight { set; get; }

        public string Familie { set; get; }
    }
}
