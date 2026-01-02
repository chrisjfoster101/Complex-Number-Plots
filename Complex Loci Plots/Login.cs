using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Forms_Implicits
{
    public partial class Login : Form
    {
        private SQLiteConnection sqliteConn;
        private Revision RevisionForm;
        public Login(Revision mainForm)
        {
            InitializeComponent();
            LoginTypeBox.SelectedIndex = 0;
            RevisionForm = mainForm;
            sqliteConn = new SQLiteConnection("Data Source = RevisionData.db; Version = 3; New = True; Compress = True;");
            sqliteConn.Open();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqliteConn.Close();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
            if (LoginTypeBox.SelectedIndex == 0)
            {
                if (attemptLogin()) Close();
            }
            else if (LoginTypeBox.SelectedIndex == 1)
            {
                if (CreateUser()) Close();
            }
        }

        private bool attemptLogin()
        {
            string truePassword;
            string name = UsernameBox.Text;
            if (name == "")
            {
                ErrorLabel.Text = "Must enter username and password";
                return false;
            }
            SQLiteCommand sqlcmd = sqliteConn.CreateCommand();
            sqlcmd.CommandText = $"SELECT Password FROM Users WHERE Name = '{name}'";
            SQLiteDataReader sqldr = sqlcmd.ExecuteReader();
            try
            {
                sqldr.Read();
                truePassword = sqldr.GetString(0);
            }
            catch
            {
                ErrorLabel.Text = "User not found";
                return false;
            }
            if (PasswordBox.Text != truePassword)
            {
                ErrorLabel.Text = "Incorrect password";
                return false;
            }
            RevisionForm.setUsername(name);
            return true;
        }

        private bool CreateUser()
        {
            string name = UsernameBox.Text;
            string password = PasswordBox.Text;
            if (name == "" | password == "")
            {
                ErrorLabel.Text = "Must enter username and password";
                return false;
            }

            SQLiteCommand sqlcmd = sqliteConn.CreateCommand();
            sqlcmd.CommandText = $"SELECT * FROM Users WHERE Name = '{name}'";
            SQLiteDataReader sqldr = sqlcmd.ExecuteReader();
            if (sqldr.HasRows)
            {
                ErrorLabel.Text = "Username already exists";
                return false;
            }

            sqlcmd = sqliteConn.CreateCommand();
            sqlcmd.CommandText = $"INSERT INTO Users VALUES ('{name}','{password}')";
            sqlcmd.ExecuteNonQuery();
            RevisionForm.setUsername(name);
            return true;
        }
    }
}
