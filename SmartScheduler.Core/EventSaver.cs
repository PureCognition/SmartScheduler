using SmartScheduler.Core.Data;

namespace SmartScheduler.Core
{
    public interface IEventSaver
    {
        void Save(Event eventToSave);
    }

    public class EventSaver : IEventSaver
    {
        private readonly IEventToDataSetConverter _eventToDataSetConverter;
        private readonly IExcelFileWriter _excelFileWriter;

        public EventSaver(IEventToDataSetConverter eventToDataSetConverter, IExcelFileWriter excelFileWriter)
        {
            _eventToDataSetConverter = eventToDataSetConverter;
            _excelFileWriter = excelFileWriter;
        }

        public void Save(Event eventToSave)
        {
            var eventDataSet = _eventToDataSetConverter.Convert(eventToSave);
            _excelFileWriter.Write(eventDataSet, "Data\\SavedData.xlsx");
        }



    }
}
