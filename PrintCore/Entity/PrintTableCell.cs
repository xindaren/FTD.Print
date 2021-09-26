using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore.Entity
{
    public class PrintTableCell
    {
        public PrintTableCell() 
        {
            this.Font = new PrintFont();
            this.Size = new PrintSize();
            this.Content = new PrintTableCellVaue();
        }

        public int RowIndex { set; get; }
          
        public int ColumnIndex { set; get; }

        public int RowSpan { set; get; }

        public int ColumnSpan { set; get; }

        public PrintFont Font { set; get; }

        public PrintSize Size { set; get; }

        public PrintTableCellVaue Content { set; get; }
    }

    public class PrintTableCellVaue
    {
        public string Text { set; get; }

        public string Value { set; get; }
    }
}
