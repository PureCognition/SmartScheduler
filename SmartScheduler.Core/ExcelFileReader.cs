using System.Data;
using System.IO;
using Excel;

namespace SmartScheduler.Core
{
    public interface IExcelFileReader
    {
        DataSet Read(string filePath);
    }

    public class ExcelFileReader : IExcelFileReader
    {
        public DataSet Read(string filePath)
        {
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            var result = excelReader.AsDataSet();
            excelReader.Close();
            return result;
        }
    }
}
