using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore.Entity
{
    public class PrintTemplateFoot
    {
        public PrintTemplateFoot()
        {
            this.Font = new PrintFont();
            this.Size = new PrintSize();
            this.Table = new PrintTable();
        }

        public PrintFont Font { set; get; }

        public PrintSize Size { set; get; }

        public PrintTable Table { set; get; }
    }
}
