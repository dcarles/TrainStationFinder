using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainStationFinder.DataStructures;

namespace TrainStationFinder.DemoApp
{
    public partial class MainForm : Form
    {
        private readonly ITrie<WordPosition> m_Trie;
        private long m_WordCount;

        public MainForm()
        {
            InitializeComponent();
            m_Trie = new Trie<WordPosition>();
            folderName.Text =
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "texts");
        }

        private void LoadFile(string fileName)
        {
            IEnumerable<WordPosition> words = GetWords(fileName);
            foreach (var word in words)
            {
                string text = word.Word;
                WordPosition wordPosition = word;
                m_Trie.Add(text, wordPosition);
            }
        }


        private IEnumerable<WordPosition> GetWords(string file)
        {
            String line;
            int counter = 1;

            using (StreamReader stream = new StreamReader(file))
            {
                while ((line = stream.ReadLine()) != null)
                {
                    var wordPosition = new WordPosition(counter, file, line.ToLower());
                    yield return wordPosition;      
                    m_WordCount++;
                    counter++;
                }
            }
        }      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string text = textBox1.Text;
            if (string.IsNullOrEmpty(text) || text.Length < 3) return;
            WordPosition[] result = m_Trie.Retrieve(text.ToLower()).ToArray();

            foreach (WordPosition wordPosition in result)
            {
                wordPosition.NextPosition = text.Length;
                listBox1.Items.Add(wordPosition);
            }
        }       

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = folderName.Text;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            folderName.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void LoadAll()
        {
            m_WordCount = 0;
            string path = folderName.Text;
            if (!Directory.Exists(path)) return;
            string[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
          
            for (int index = 0; index < files.Length; index++)
            {
                string file = files[index];
                progressText.Text =
                    string.Format(
                        "Processing file {0} of {1}: [{2}]",
                        index,
                        files.Length,
                        Path.GetFileName(file));

                var fileInfo = new FileInfo(file);              
                LoadFile(file);              
            }
            progressText.Text = string.Format("{0:n0} stations read in {1} file(s). Ready.", m_WordCount, files.Length);
        }
    }
}