using System.Xml.Serialization;

namespace Questionnaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;

            string userInfo = $"{firstName} {lastName} - {email} - {phoneNumber}";
            lstUsers.Items.Add(userInfo);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedIndex != -1)
            {
                string selectedUserInfo = lstUsers.SelectedItem.ToString();
                string[] userInfoParts = selectedUserInfo.Split(new string[] { " - " }, StringSplitOptions.None);

                if (userInfoParts.Length == 3)
                {
                    txtFirstName.Text = userInfoParts[0].Split(' ')[0];
                    txtLastName.Text = userInfoParts[0].Split(' ')[1];
                    txtEmail.Text = userInfoParts[1];
                    txtPhoneNumber.Text = userInfoParts[2];
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedIndex != -1)
            {
                lstUsers.Items.RemoveAt(lstUsers.SelectedIndex);
            }
        }

        private void btnExportText_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("users.txt"))
            {
                foreach (string item in lstUsers.Items)
                {
                    writer.WriteLine(item);
                }
            }
        }

        private void btnImportText_Click(object sender, EventArgs e)
        {
            lstUsers.Items.Clear();

            try
            {
                using (StreamReader reader = new StreamReader("users.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lstUsers.Items.Add(line);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading from the text file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            List<string> userInfos = new List<string>();
            foreach (string item in lstUsers.Items)
            {
                userInfos.Add(item);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            using (TextWriter writer = new StreamWriter("users.xml"))
            {
                serializer.Serialize(writer, userInfos);
            }
        }

        private void btnImportXML_Click(object sender, EventArgs e)
        {
            lstUsers.Items.Clear();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                using (TextReader reader = new StreamReader("users.xml"))
                {
                    List<string> userInfos = (List<string>)serializer.Deserialize(reader);
                    foreach (string userInfo in userInfos)
                    {
                        lstUsers.Items.Add(userInfo);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading from the XML file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}