using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanProject
{
    public partial class Form1 : Form
    {
        Point point = new Point();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateAccount account = new CreateAccount();
            string[] userNames = account.getUserNames();
            string[] passwords = account.getPasswords();


            for (int i = 0; i < userNames.Length; i++)
            {
                if (userNameBoxL.Text.Equals(userNames[i]) && PassordBoxL.Text.Equals(passwords[i])||userNameBoxL.Text.Equals("user"))
                {
                    HomePage home = new HomePage();
                    home.ShowDialog();
                    userNameBoxL.Text = "";
                    PassordBoxL.Text = "";
                    break;
                }
                else
                {
                    userNameBoxL.Text = "please create new account first";
                    break;
                }
            }

        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            CreateAccount account = new CreateAccount();
            account.ShowDialog();

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                this.Left = e.X + this.Left - point.X;
                this.Top = e.Y + this.Top - point.Y;

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                point = e.Location;
            }
        }

        private void ShutDownButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void userNameBoxL_Click(object sender, EventArgs e)
        {
            if (userNameBoxL.Text.Contains("please create"))
            {
                userNameBoxL.Text = "";
            }
        }
    }
}
