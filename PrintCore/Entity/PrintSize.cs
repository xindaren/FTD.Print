using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore.Entity
{
    public class PrintSize
    {
        public decimal Width { set; get; }

        public decimal Height { set; get; }

        public decimal LeftMargin { set; get; }

        public decimal TopMargin { set; get; }

        public decimal RightMargin { set; get; }

        public decimal BottomMargin { set; get; }
    }
}
