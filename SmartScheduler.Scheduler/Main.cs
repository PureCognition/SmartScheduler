using System;
using System.Windows.Forms;
using SmartScheduler.Core;

namespace SmartScheduler.SchedulerApplication
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            var scheduler = new Scheduler(new EventRetriever(
                new EventInitializer(
                    new EventDefinitionRetriever(
                        new SessionDefinitionGenerator(
                            new PresenterRetriever(
                                new ExcelFileReader())))),
                                new AttendeeRetriever(
                                    new ExcelFileReader())));

            var testEvent = scheduler.Schedule();

            var eventSaver = new EventSaver(
                new EventToDataSetConverter(),
                new ExcelFileWriter());

            eventSaver.Save(testEvent);

            MessageBox.Show("Done.");
        }
    }
}
