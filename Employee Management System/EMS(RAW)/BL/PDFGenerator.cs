//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml.Linq;
//using iTextSharp.text;
//using iTextSharp.text.pdf;


//namespace EMS_RAW_.BL
//{
//    class PdfGenerator
//    {
//        public void GeneratePdfReport(List<Transaction> transactions)
//        {
//            // Create a new document
//            Document document = new Document();
//            // Store the address of the destination at which the file is to be stored
//            SaveFileDialog saveFileDialog = new SaveFileDialog();
//            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
//            saveFileDialog.DefaultExt = "pdf";
//            // Show the SaveFileDialog and get the selected file path
//            DialogResult result = saveFileDialog.ShowDialog();
//            string filePath = string.Empty;
//            if (result == DialogResult.OK)
//            {
//                filePath = saveFileDialog.FileName;
//            }
//            // Create a new PDF writer
//            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath,
//           FileMode.Create));
//            // Open the document
//            document.Open();
//            // Create a PDF table
//            PdfPTable pdfTable = new PdfPTable(5); // 5 columns: Date, Amount, 
//            Transaction Type, Client Name, Client Account Number, Client Balance;
//            // Set the table width to fit the page
//            pdfTable.WidthPercentage = 100;
//            // Set header properties
//            Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD);
//            foreach (string columnName in new string[] { "Date", "Amount", "Transaction Type", "Reference AccountNumber", "Final Balance" })
// {
// PdfPCell cell = new PdfPCell(new Phrase(columnName, headerFont));
//            cell.BackgroundColor = BaseColor.LIGHT_GRAY; // Set the background color 
//            of the header cell
//       cell.HorizontalAlignment = Element.ALIGN_CENTER; // Set the horizontal 
//            alignment of the header cell
//        cell.VerticalAlignment = Element.ALIGN_MIDDLE; // Set the vertical 
//            alignment of the header cell
//        cell.Padding = 5; // Set padding for the header cell
//            pdfTable.AddCell(cell);
//        }
// // Add table rows
// foreach (var transaction in transactions)
// {
// PdfPCell cellDate = new PdfPCell(new
//Phrase(transaction.Date.ToString()));
//        PdfPCell cellAmount = new PdfPCell(new
//       Phrase(transaction.Amount.ToString()));
//        PdfPCell cellTransactionType = new PdfPCell(new
//       Phrase(transaction.TransactionType.ToString()));
//        PdfPCell cellReferenceAccountNumber = new PdfPCell(new
//       Phrase(transaction.RefrenceAccount.ToString()));
//        PdfPCell cellClientBalance = new PdfPCell(new
//       //Phrase(transaction.T_Client.Account.Balance.ToString()));
// foreach (PdfPCell cell in new PdfPCell[] { cellDate, cellAmount, 
//cellTransactionType, cellReferenceAccountNumber, cellClientBalance
//    })
// {
// cell.HorizontalAlignment = Element.ALIGN_CENTER; // Set the 
//horizontal alignment of the cell
// cell.VerticalAlignment = Element.ALIGN_MIDDLE; // Set the vertical 
//    alignment of the cell
// cell.Padding = 5; // Set padding for the cell
//pdfTable.AddCell(cell);
// }
// }
// // Add the table to the document
// document.Add(pdfTable);
//// Close the document and the writer
//document.Close();
//writer.Close();
// }
//}
//}
