using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace AcademySTEP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {

            RefreshDepartmentsDataGridView();
            RefreshFormsDataGridView();
            RefreshGroupsDataGridView();
            RefreshStudentsDataGridView();
        }

        private void RefreshBtn1_Click(object sender, EventArgs e)
        {
            RefreshDepartmentsDataGridView();
            RefreshFormsDataGridView();
            RefreshGroupsDataGridView();
            RefreshStudentsDataGridView();
        }

        private void RefreshBtn2_Click(object sender, EventArgs e)
        {
            RefreshDepartmentsDataGridView();
            RefreshFormsDataGridView();
            RefreshGroupsDataGridView();
            RefreshStudentsDataGridView();
        }

        private void RefreshBtn4_Click(object sender, EventArgs e)
        {
            RefreshDepartmentsDataGridView();
            RefreshFormsDataGridView();
            RefreshGroupsDataGridView();
            RefreshStudentsDataGridView();
        }

        private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=AcademySTEP;Integrated Security=True;";

        private void RefreshDepartmentsDataGridView()
        {
            DataTable dt = LoadDepartmentsData();
            DepartmentsDataGridView.DataSource = dt;
        }


        private void RefreshFormsDataGridView()
        {
            DataTable dt = LoadFormsDataGridView();

            FormsDataGridView.DataSource = dt;
        }

        private void RefreshGroupsDataGridView()
        {
            DataTable dt = LoadGroupsDataGridView();

            GroupsDataGridView.DataSource = dt;
        }

        private void RefreshStudentsDataGridView()
        {
            DataTable dt = LoadStudentsDataGridView();

            StudentsDataGridView.DataSource = dt;
        }

        private DataTable LoadDepartmentsData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Departments";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LoadFormsDataGridView()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Forms";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LoadGroupsDataGridView()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Groups";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LoadStudentsDataGridView()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Students";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        /////////////////////////////////////////////////////////////

        private void SaveChangesBtn_Click(object sender, EventArgs e)
        {
            SaveChangesToDepartments();
            RefreshDepartmentsDataGridView();
        }

        private void SaveChangesToDepartments()
        {
            DataTable dt = (DataTable)DepartmentsDataGridView.DataSource;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Departments", connection))
                {
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.Update(dt);
                    }
                }
            }
        }

        private void SaveChangesBtn1_Click(object sender, EventArgs e)
        {
            SaveChangesToForms();
            RefreshFormsDataGridView();
        }

        private void SaveChangesToForms()
        {
            DataTable dt = (DataTable)FormsDataGridView.DataSource;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Forms", connection))
                {
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.Update(dt);
                    }
                }
            }
        }

        private void SaveChangesBtn2_Click(object sender, EventArgs e)
        {
            SaveChangesToGroups();
            RefreshGroupsDataGridView();
        }

        private void SaveChangesToGroups()
        {
            DataTable dt = (DataTable)GroupsDataGridView.DataSource;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Groups", connection))
                {
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.Update(dt);
                    }
                }
            }
        }

        private void SaveChangesBtn3_Click(object sender, EventArgs e)
        {
            SaveChangesToStudents();
            RefreshStudentsDataGridView();
        }

        private void SaveChangesToStudents()
        {
            DataTable dt = (DataTable)StudentsDataGridView.DataSource;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Students", connection))
                {
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.Update(dt);
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////

        private void Delete1_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(DepartmentsDataGridView, "DepartmentId");
            RefreshDepartmentsDataGridView();
        }

        private void Delete2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(FormsDataGridView, "FormId");
            RefreshFormsDataGridView();
        }

        private void Delete3_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(GroupsDataGridView, "GroupId");
            RefreshGroupsDataGridView();
        }

        private void Delete4_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(StudentsDataGridView, "StudentId");
            RefreshStudentsDataGridView();
        }

        private void DeleteSelectedRows(DataGridView dataGridView, string primaryKeyColumnName)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataTable dt = (DataTable)dataGridView.DataSource;

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    int primaryKeyValue = Convert.ToInt32(row.Cells[primaryKeyColumnName].Value);

                    DataRow[] rows = dt.Select($"{primaryKeyColumnName} = {primaryKeyValue}");
                    if (rows.Length > 0)
                    {
                        rows[0].Delete();
                    }
                }

                UpdateDatabase(dataGridView, dt);
            }
        }


        private void UpdateDatabase(DataGridView dataGridView, DataTable dt)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {GetTableName(dataGridView)}", connection))
                {
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.Update(dt);
                    }
                }
            }
        }

        private string GetTableName(DataGridView dataGridView)
        {
            switch (dataGridView.Name)
            {
                case "DepartmentsDataGridView":
                    return "Departments";
                case "FormsDataGridView":
                    return "Forms";
                case "GroupsDataGridView":
                    return "Groups";
                case "StudentsDataGridView":
                    return "Students";
                default:
                    return string.Empty;
            }
        }
    }
}