using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Plagiarism.Vectoriser;
using PlagiarismChecker.Pdf.Parser;

namespace PlagiarismChecker.Ui.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BtnFolderLocation_OnClick(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                TbxFolderLocation.Text = dialog.SelectedPath;
            }
        }

        private void BtnProceed_Click(object sender, RoutedEventArgs e)
        {
            
            var folderLocation = TbxFolderLocation.Text;
            var outputLocation = TbxOutputLocation.Text;
            var ngram = TbxNgram.Text;
            var threshold = TbxThreshold.Text;

            if (string.IsNullOrEmpty(folderLocation))
            {
                MessageBox.Show("Select folder location", "Error");
                return;
            }

            if (string.IsNullOrEmpty(outputLocation))
            {
                MessageBox.Show("Select output location", "Error");
                return;
            }

            if (!int.TryParse(ngram, out var nGramValue))
            {
                MessageBox.Show("Invalid word sequence no.", "Error");
                return;
            }

            if (!float.TryParse(threshold, out var thresholdValue))
            {
                MessageBox.Show("Invalid threshold", "Error");
                return;
            }

            BorderLoading.Visibility = Visibility.Visible;

            Task.Factory.StartNew(() =>
            {
                Proceed(folderLocation, nGramValue, outputLocation, thresholdValue);

            }).ContinueWith(previousTask =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    BorderLoading.Visibility = Visibility.Hidden;
                }));
            });
        }

        private void BtnBtnOutputLocation_OnClick(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                TbxOutputLocation.Text = dialog.SelectedPath;
            }
        }

        private void Proceed(string folderLocation, int nGramValue, string outputLocation, float threshold)
        {
            var pdfParser = new PdfParser();
            var tfIdf = new DocumentTermFrequency();
            var nGram = new Ngram();

            var reports = new Dictionary<string, List<string>>();

            foreach (var file in Directory.EnumerateFiles(folderLocation, "*.pdf"))
            {
                var fileName = Path.GetFileNameWithoutExtension(file);

                var contents = pdfParser.GetText(file);

                reports[fileName] = nGram.Create(contents, nGramValue);
            }

            var tfIdfMatrix = tfIdf.Create(reports);

            var sim = new Similarity().CreateRowWise(tfIdfMatrix);

            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("Roll,Similarity");

            for (var r = 0; r < sim.GetLength(0); r++)
            {
                var line = "";
                for (var c = 0; c < sim.GetLength(1); c++)
                {
                    if (sim[r, c] > threshold)
                    {
                        line += $"{reports.Keys.ElementAt(c)}={Math.Round(sim[r, c] * 100, 2)}%,";
                    }
                }

                if (!string.IsNullOrEmpty(line))
                {
                    var idx = line.LastIndexOf(',');

                    if (idx >= 0)
                    {
                        line = line.Substring(0, line.Length - 1);
                    }
                }

                strBuilder.AppendLine($"\"{reports.Keys.ElementAt(r)}\",\"{line}\"");
            }

            var output = $"{outputLocation}/Plagiarism_Output{DateTime.Now:yyyy-dd-M--HH-mm-ss}.csv";

            File.WriteAllBytes(output, Encoding.UTF8.GetBytes(strBuilder.ToString()));

            Process.Start(output);
        }
    }
}
