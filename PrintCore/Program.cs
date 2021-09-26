
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PrintCore.Core;
using PrintCore.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore
{
    class Program
    {
        static void Main(string[] args)
        { 
            Print print = new Print(); 
            var data = new PrintTemplate();

            data.Head = new PrintTemplateHead();
            data.Head.Table.ColumnList.Add(new PrintTableColumn() { Index = 0, Width = 99 });  
            data.Head.Table.RowList.Add(new PrintTableRow() { Index = 0, Height = 10 }); 

            var cell = new PrintTableCell();
            cell.Font.Size = 12;
            cell.Content.Text = "head";
            cell.Content.Value = "dfgfdgfdgfdgfdgfdggfdgf";
            cell.RowIndex = 0;
            cell.ColumnIndex = 0; 
            data.Head.Table.CellList.Add(cell);

            data.Body = new PrintTemplateBody();
            data.Body.Table.ColumnList.Add(new PrintTableColumn() { Index = 0, Width = 33 });
            data.Body.Table.ColumnList.Add(new PrintTableColumn() { Index = 1, Width = 33 });
            data.Body.Table.ColumnList.Add(new PrintTableColumn() { Index = 2, Width = 33 });

            data.Body.Table.RowList.Add(new PrintTableRow() { Index = 0, Height = 10 });
            data.Body.Table.RowList.Add(new PrintTableRow() { Index = 1, Height = 10 });
            
            var bodyCell = new PrintTableCell();
            bodyCell.Font.Size = 12;
            bodyCell.Content.Text = "body";
            bodyCell.Content.Value = "标题1";
            bodyCell.RowIndex = 0;
            bodyCell.ColumnIndex = 0;
            data.Body.Table.CellList.Add(bodyCell);

            bodyCell = new PrintTableCell();
            bodyCell.Font.Size = 12;
            bodyCell.Content.Text = "body";
            bodyCell.Content.Value = "标题2";
            bodyCell.RowIndex = 0;
            bodyCell.ColumnIndex = 1;
            data.Body.Table.CellList.Add(bodyCell);

            bodyCell = new PrintTableCell();
            bodyCell.Font.Size = 12;
            bodyCell.Content.Text = "body";
            bodyCell.Content.Value = "标题3";
            bodyCell.RowIndex = 0;
            bodyCell.ColumnIndex = 2;
            data.Body.Table.CellList.Add(bodyCell);


            bodyCell = new PrintTableCell();
            bodyCell.Font.Size = 12;
            bodyCell.Content.Text = "body";
            bodyCell.Content.Value = "数据1";
            bodyCell.RowIndex = 1;
            bodyCell.ColumnIndex = 0;
            data.Body.Table.CellList.Add(bodyCell);

            bodyCell = new PrintTableCell();
            bodyCell.Font.Size = 12;
            bodyCell.Content.Text = "body";
            bodyCell.Content.Value = "数据2";
            bodyCell.RowIndex = 1;
            bodyCell.ColumnIndex = 1;
            data.Body.Table.CellList.Add(bodyCell);

            bodyCell = new PrintTableCell();
            bodyCell.Font.Size = 12;
            bodyCell.Content.Text = "body";
            bodyCell.Content.Value = "数据3";
            bodyCell.RowIndex = 1;
            bodyCell.ColumnIndex = 2;
            data.Body.Table.CellList.Add(bodyCell);


            print.GeneratePDF(data);
             
        }
         
    }
}
