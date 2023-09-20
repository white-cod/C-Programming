namespace TextFileReaderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                lblStatus.Text = $"Status: Reading {Path.GetFileName(filePath)}...";

                string content = File.ReadAllText(filePath);

                int totalCharacters = content.Length;
                int charactersRead = 0;

                while (charactersRead < totalCharacters)
                {
                    int charactersToRead = Math.Min(100, totalCharacters - charactersRead);
                    string chunk = content.Substring(charactersRead, charactersToRead);


                    charactersRead += charactersToRead;
                    progressBar.Value = (int)((double)charactersRead / totalCharacters * 100);
                    Application.DoEvents();
                }

                lblStatus.Text = $"Status: Finished reading {Path.GetFileName(filePath)}";
            }
        }
    }
}