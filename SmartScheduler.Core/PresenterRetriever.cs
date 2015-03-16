using System;
using System.Collections.ObjectModel;
using System.Data;
using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface IPresenterRetriever
    {
        Collection<Presenter> Retrieve();
    }

    public class PresenterRetriever : IPresenterRetriever
    {
        private readonly IExcelFileReader _excelFileReader;

        public PresenterRetriever(IExcelFileReader excelFileReader)
        {
            _excelFileReader = excelFileReader;
        }

        public Collection<Presenter> Retrieve()
        {
            var results = new Collection<Presenter>();
            const string fileName = "Data\\Sessions.xlsx";
            var table = _excelFileReader.Read(fileName).Tables[0];


            foreach (DataRow row in table.Rows)
                results.Add(new Presenter()
                {
                    Name = string.Format("{0} {1}", row[0], row[1]),
                    Room = Convert.ToInt32(row[2]),
                    Company = row[3].ToString(),
                    Topic = row[4].ToString(),
                    Category = row[5].ToString()
                });

            return results;
        }
    }
}
