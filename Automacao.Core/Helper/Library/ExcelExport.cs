using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Automacao.Core.Helper.Library
{
    public class ExcelExport<T> where T : class
    {
        private IEnumerable<T> _objectList;

        public ExcelExport(IEnumerable<T> objectList)
        {
            _objectList = objectList;
        }
        public FileInfo GetFile()
        {
            if (_objectList == null)
            {
                throw new ArgumentNullException(nameof(_objectList));
            }

            var rnd = new Random();
            var nomeArquivo = $"DadosASC_Ocorrencias_{DateTime.Now.ToString("yyyyMMddmmss")}{rnd.Next(100)}.xlsx";
            string excelFile = Path.Combine(Environment.CurrentDirectory, nomeArquivo);
            using (ExcelPackage pck = new ExcelPackage())
            {

                var wsDt = pck.Workbook.Worksheets.Add("DadosASC");
                wsDt.HeaderFooter.OddHeader.CenteredText = "Contemplação";
                wsDt.Cells["A1"].LoadFromCollection(_objectList, true, OfficeOpenXml.Table.TableStyles.Medium9);

                var fi = new FileInfo(excelFile);
                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);
                Process.Start(excelFile);

                return pck.File;
            }
        }

        public string Gerar()
        {

            if (_objectList == null)
            {
                throw new ArgumentNullException(nameof(_objectList));
            }

            try
            {
                //denifindo o nome do arquivo
                var rnd = new Random();
                var nomeArquivo = $"DadosASC_Ocorrencias_{DateTime.Now.ToString("yyyyMMddhhmmss")}{rnd.Next(100)}.xlsx";
                string excelFile = Path.Combine($"Content/{nomeArquivo}");

                using (ExcelPackage pck = new ExcelPackage())
                {
                    var wsDt = pck.Workbook.Worksheets.Add("DadosASC");
                    wsDt.Cells["A1"].LoadFromCollection(_objectList, true, TableStyles.Medium9);
                    wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();
                    var fi = new FileInfo(excelFile);
                    if (fi.Exists)
                        fi.Delete();
                    pck.SaveAs(fi);

                    return nomeArquivo;
                }
            }
            catch (Exception e)
            {
                return $"Message:{e.Message}. InnerException.Message:{e.InnerException.Message}";
            }
        }
        private ExcelPackage Gerar(List<T> objectList)
        {
            // criando o arquivo em memória
            ExcelPackage arquivoExcel = new ExcelPackage(); // nao recebe mais o caminho do arquivo

            //(operacoes para construir o arquivo do mesmo jeito que antes)

            // Salvando e fechando o arquivo - desnecessários agora
            //arquivoExcel.Save();
            //arquivoExcel.Dispose();            

            return arquivoExcel; // retornando o arquivo aberto em memória para a controller
        }
    }
}
