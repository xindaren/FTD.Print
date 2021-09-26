using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore.Entity
{
    public class PrintTemplate
    {
        public PrintTemplate() 
        {
            this.Font = new PrintFont();
            this.Size = new PrintSize(); 
        }

        public string Version { set; get; }

        public string Title { set; get; }

        public PrintFont Font { set; get; }

        public PrintSize Size { set; get; }
          
        public PrintTemplateHead Head { set; get; }

        public PrintTemplateBody Body { set; get; }

        public PrintTemplateFoot Foot { set; get; }
    }
}
