using System.Data;

namespace SmartScheduler.Core
{
    public interface IExcelFileWriter
    {
        void Write(DataSet data, string filePath);
    }

    public class ExcelFileWriter : IExcelFileWriter
    {
        public void Write(DataSet data, string filePath)
        {
            CreateExcelFile.CreateExcelDocument(data, filePath);

        }
    }
}
