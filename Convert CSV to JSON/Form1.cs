using System;
using System.Windows.Forms;

namespace Convert_CSV_to_JSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            openFileDialog1.Filter = "CSV Files|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;

            DialogResult openFileResult = openFileDialog1.ShowDialog();

            if (openFileResult != DialogResult.OK)
            {
                return;
            }

            System.IO.Stream fileStream = openFileDialog1.OpenFile();
            string csv = string.Empty;

            using(System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
            {
                csv = reader.ReadToEnd();
            }

            fileStream.Close();

            CSVConverter converter = new CSVConverter();

            textBoxJSON.Text = converter.ConvertToJSON(csv);
        }


    }
}
