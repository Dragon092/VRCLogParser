namespace VRCLogParser
{
    using System.IO;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Running...");

            DirectoryInfo d = new DirectoryInfo(@"C:\Users\mail\AppData\LocalLow\VRChat\VRChat");

            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files

            foreach (FileInfo file in Files)
            {
                parse_file(file);
            }
        }

        private void parse_file(FileInfo file)
        {
            System.Diagnostics.Debug.WriteLine("Parsing "+file.Name+"...");
        }
    }
}