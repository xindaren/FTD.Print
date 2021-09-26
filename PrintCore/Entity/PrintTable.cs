using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore.Entity
{
    public class PrintTable
    {
        public PrintTable() 
        {
            this.ColumnList = new List<PrintTableColumn>();
            this.RowList = new List<PrintTableRow>();
            this.CellList = new List<PrintTableCell>();
        }

        public List<PrintTableColumn> ColumnList { set; get; }

        public List<PrintTableRow> RowList { set; get; }

        public List<PrintTableCell> CellList { set; get; }
    }

    public class PrintTableColumn
    {  
        public int Index { set; get; }

        public double Width { set; get; } 
    }

    public class PrintTableRow
    {  
        public int Index { set; get; }

        public double Height { set; get; }
    }
}
