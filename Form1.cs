namespace VRCLogParser
{
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using static System.ComponentModel.Design.ObjectSelectorEditor;
    using static System.Net.Mime.MediaTypeNames;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Running...");

            listBox1.Items.Clear();

            DirectoryInfo d = new DirectoryInfo(@"C:\Users\mail\AppData\LocalLow\VRChat\VRChat");

            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files

            if(Files.Length > 1)
            {
                System.Diagnostics.Debug.WriteLine($"Found more then 1 log file: {Files.Length} found");
            }

            foreach (FileInfo file in Files)
            {
                parse_file(file);
            }
        }

        private void parse_file(FileInfo file)
        {
            System.Diagnostics.Debug.WriteLine($"Parsing {file.Name}...");

            string[] lines = File.ReadAllLines(file.FullName);

            lines = lines.Reverse().ToArray();

            foreach (string line in lines.Where(l => l.Contains("[Video Playback]")))
                listBox1.Items.Add(line);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string txt = listBox1.GetItemText(listBox1.SelectedItem);

            foreach (Match item in Regex.Matches(txt, @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)"))
            {
                System.Diagnostics.Debug.WriteLine($"{item.Value}");
                //MessageBox.Show(item.Value);

                Clipboard.SetText(item.Value);
            }
        }
    }
}