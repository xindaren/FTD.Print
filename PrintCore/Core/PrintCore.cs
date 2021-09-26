
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PrintCore.Entity;

namespace PrintCore.Core
{
    public class Print
    {  
        public Print() 
        {
            System.Drawing.Text.PrivateFontCollection pfcFonts = new System.Drawing.Text.PrivateFontCollection();
            string strFontPath = @"D:\SourceCode\PrintCore\PrintCore\msyh.ttf";
            pfcFonts.AddFontFile(strFontPath); 
        }

        public void GeneratePDF(PrintTemplate printTemplate)
        {    
            Document doc = new Document();
            
            var sec = doc.AddSection(); 
            sec.PageSetup.TopMargin = 5;
            sec.PageSetup.LeftMargin = 5;
            sec.PageSetup.RightMargin = 5;
            sec.PageSetup.BottomMargin = 5;
            sec.PageSetup.PageWidth = Unit.FromMillimeter(100);
            sec.PageSetup.PageHeight = Unit.FromMillimeter(100);
            

            #region Head
            if (printTemplate.Head != null)
            {
                Table headTable = new Table();
                headTable.Borders.Width = 0.5;

                foreach (var colItem in printTemplate.Head.Table.ColumnList)
                {
                    headTable.AddColumn(Unit.FromMillimeter(colItem.Width));
                }

                foreach (var rowItem in printTemplate.Head.Table.RowList)
                {
                    var row = headTable.AddRow();
                    row.Height = Unit.FromMillimeter(rowItem.Height);
                    row.HeadingFormat = true;
                }

                foreach (var cellItem in printTemplate.Head.Table.CellList)
                {
                    var cell = headTable.Rows[cellItem.RowIndex].Cells[cellItem.ColumnIndex];
                    cell.MergeRight = cellItem.ColumnSpan;
                    cell.MergeDown = cellItem.RowSpan;
                    this.AddWarpText(cellItem.Content.Value, cell, new Font(cellItem.Font.Familie, cellItem.Font.Size));
                }

                sec.Add(headTable);
            }
            #endregion

            #region Body

            if (printTemplate.Body != null)
            {
                Table bodyTable = new Table();
                bodyTable.Borders.Width = 0.5;

                foreach (var colItem in printTemplate.Body.Table.ColumnList)
                {
                    bodyTable.AddColumn(Unit.FromMillimeter(colItem.Width));
                }

                foreach (var rowItem in printTemplate.Body.Table.RowList)
                {
                    var row = bodyTable.AddRow();
                    row.Height = Unit.FromMillimeter(rowItem.Height);
                }

                foreach (var cellItem in printTemplate.Body.Table.CellList)
                {
                    var cell = bodyTable.Rows[cellItem.RowIndex].Cells[cellItem.ColumnIndex];
                    cell.MergeRight = cellItem.ColumnSpan;
                    cell.MergeDown = cellItem.RowSpan;
                    this.AddWarpText(cellItem.Content.Value, cell, new Font(cellItem.Font.Familie, cellItem.Font.Size));
                }

                sec.Add(bodyTable);
            }
            #endregion

            #region Foot

            if (printTemplate.Foot != null)
            {
                Table footTable = new Table();
                footTable.Borders.Width = 0.5;

                foreach (var colItem in printTemplate.Foot.Table.ColumnList)
                {
                    footTable.AddColumn(Unit.FromMillimeter(colItem.Width));
                }

                foreach (var rowItem in printTemplate.Foot.Table.RowList)
                {
                    var row = footTable.AddRow();
                    row.Height = Unit.FromMillimeter(rowItem.Height);
                    row.HeadingFormat = true;
                }

                foreach (var cellItem in printTemplate.Foot.Table.CellList)
                {
                    var cell = footTable.Rows[cellItem.RowIndex].Cells[cellItem.ColumnIndex];
                    cell.MergeRight = cellItem.ColumnSpan;
                    cell.MergeDown = cellItem.RowSpan;
                    this.AddWarpText(cellItem.Content.Value, cell, new Font(cellItem.Font.Familie, cellItem.Font.Size));
                }

                sec.Add(footTable);
            }
            #endregion
             
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = doc;  
            pdfRenderer.RenderDocument();

            //var dd = pdfRenderer.DocumentRenderer.FormattedDocument.GetRenderInfos(1);
            //var area = dd[0].LayoutInfo.ContentArea;
             
            var path = @"D:\SourceCode\PrintCore\PrintCore\pdf\1.pdf";
            pdfRenderer.Save(path);
        }

         
        private Paragraph AddWarpText(string instring, Cell cell, Font font) 
        {
            var tm = new TextMeasurement(font);

            Unit maxWidth = cell.Column.Width - (cell.Column.LeftPadding + cell.Column.RightPadding)-3;
          
            List<string> strList = new List<string>();
            string warpText = ""; 
            foreach (var str in instring)
            {
                warpText += str; 
                var strWidth = tm.MeasureString(warpText, UnitType.Millimeter).Width;

                if (strWidth > maxWidth.Millimeter)
                {
                    strList.Add(warpText.Remove(warpText.Length - 1));
                    warpText = str.ToString();
                } 
            }

            if (!string.IsNullOrEmpty(warpText))
            {
                strList.Add(warpText);
                warpText = string.Empty;
            }

            Paragraph par = cell.AddParagraph();
            foreach (var str in strList)
            {
                par.AddFormattedText(str, font);
            }

            return par;
        }


       
    }
}
