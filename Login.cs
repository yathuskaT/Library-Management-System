using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace day
{
    public partial class Login : Form
    {
        

        public Login()
        {
            InitializeComponent();
        }

        private void btnBut1_Click(object sender, EventArgs e)
        {
            string username, password;
            
                 username = txtUser.Text;
                 password = txtPass.Text;

                MySqlConnection conn = new MySqlConnection("server=localhost;user id=root; password=; database=LibraryDB");
                string query = "SELECT * FROM user WHERE username=@username AND password=@password";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", txtUser.Text);
                cmd.Parameters.AddWithValue("@password", txtPass.Text); 

                conn.Open();
                MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string role = reader["Role"].ToString();
                    MessageBox.Show("Login Successful as " + role);

                if(role == "Student")
                {
                    student st = new student();
                    st.Show();
                }
                else if(role =="Librarian")
                {
                    librarian lb = new librarian();
                    lb.Show();
                }
                this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Invalid username and password.");
                }
                reader.Close();
                conn.Close();
            }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

        }
    

