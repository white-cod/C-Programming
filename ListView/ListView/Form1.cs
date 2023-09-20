namespace ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewCatalog.View = View.Details;

            listViewCatalog.Columns.Add("Name");
            listViewCatalog.Columns.Add("Size");

            PopulateListView("D:\\My Documents\\Me\\files");
        }

        private void PopulateListView(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    ListViewItem item = new ListViewItem(new[] { file.Name, file.Length.ToString() + " bytes" });
                    listViewCatalog.Items.Add(item);
                }

                foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                {
                    ListViewItem item = new ListViewItem(new[] { subDir.Name, "<Folder>" });
                    listViewCatalog.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("��������� ������� �� ����������.");
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;

            switch (item.Text)
            {
                case "��������� ���":
                    listViewCatalog.View = View.Details;
                    break;
                case "������� ������":
                    listViewCatalog.View = View.LargeIcon;
                    break;
                case "������ ������":
                    listViewCatalog.View = View.SmallIcon;
                    break;
                case "��� ������":
                    listViewCatalog.View = View.List;
                    break;
            }
        }
    }
}