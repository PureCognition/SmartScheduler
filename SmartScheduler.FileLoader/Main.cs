using System;
using System.IO;
using System.Windows.Forms;
using Excel;

namespace SmartScheduler.FileLoader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ReadData("Data\\Sessions.xlsx", dataGridView1);
            ReadData("Data\\Student Survey.xlsx", dataGridView2);

        }

        private static void ReadData(string filePath, DataGridView dataGridView)
        {
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            var result = excelReader.AsDataSet();
            dataGridView.DataSource = result.Tables[0];
            excelReader.Close();
        }
    }
}
