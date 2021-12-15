using System;
using System.Windows.Forms;
using System.Drawing;
namespace HumanProject
{
    public partial class CreateAccount : Form
    {
        Point point = new Point();
        private static string[] userNamesArr = { "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
        private static string[] passwordsArr = new string[10];
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ShowPasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCheck.Checked)
            {

                PasswordBox.PasswordChar = '\0';
                ConfirmPasswordBox.PasswordChar = '\0';
            }
            else if (!ShowPasswordCheck.Checked)
            {
                PasswordBox.PasswordChar = '*';
                ConfirmPasswordBox.PasswordChar = '*';
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            UserNameError.Visible = false;
            PasswordError.Visible = false;
            AccountNote.Visible = false;

            if (!userNameCheck() && !passwordCheck())
            {
                for (int i = 0; i < userNamesArr.Length; i++)
                {
                    if (userNamesArr[i].Equals("*"))
                    {
                        userNamesArr[i] = UserNameBox.Text;
                        passwordsArr[i] = PasswordBox.Text;
                        AccountNote.Visible = true;
                        break;

                    }
                }
            }

        }
        public string[] getUserNames()
        {
            return userNamesArr;
        }
        public string[] getPasswords()
        {
            return passwordsArr;
        }

        private bool userNameCheck()
        {
            for (int i = 0; i < userNamesArr.Length; i++)
            {
                if (UserNameBox.Text.Equals(userNamesArr[i]) || UserNameBox.TextLength < 3)
                {
                    UserNameError.Visible = true;
                    return true;

                }
            }
            return false;

        }
        private bool passwordCheck()
        {
            if (PasswordBox.Text.Equals(ConfirmPasswordBox.Text) == false || PasswordBox.TextLength < 3
                || ConfirmPasswordBox.TextLength < 3)
            {
                PasswordError.Visible = true;
                return true;
            }
            return false;
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                point = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                this.Left = e.X + this.Left - point.X;
                this.Top = e.Y + this.Top - point.Y;

            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
