using ClosedXML.Excel;
using Entities;

namespace Business
{
    public class FileUtil
    {
        public static void FileExcelCSV(List<Client> clients)
        {
            var excel = new XLWorkbook();

            var workSheet = excel.Worksheets.Add("Clients");

            workSheet.Cell("A1").Value = "Id cliente";
            workSheet.Cell("B1").Value = "Numero de identificación";
            workSheet.Cell("C1").Value = "Nombres";
            workSheet.Cell("D1").Value = "Apellidos";
            workSheet.Cell("E1").Value = "correo electronico";

            int row = 2;

            foreach (Client client in clients)
            {
                workSheet.Cell("A" + row).Value = client.IdClient;
                workSheet.Cell("B" + row).Value = client.NumberDocument;
                workSheet.Cell("C" + row).Value = client.FirstName;
                workSheet.Cell("D" + row).Value = client.LastName;
                workSheet.Cell("E" + row).Value = client.Email;
                row++;
            }
            excel.SaveAs("Clients.xlsx");
        }
    }
}