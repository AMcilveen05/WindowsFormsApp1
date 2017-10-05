using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WindowsFormsApp1.BusinessLayer;
using WindowsFormsApp1.PresentationLayer;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        private UserManager userManager;
    
        public LoginForm()
        {
            InitializeComponent();
            userManager = new UserManager();
        }

        private  async void button1_ClickAsync(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task LoginAsync()
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                textBox3.Visible = true;
                return;
            }
            User user = new User();
            user.UserName = textBox1.Text;
            user.Password = textBox2.Text;

            var userExits = await userManager.UserExists(user);

            if (userExits == 1)
            {
                this.Hide();
                var mainForm = new MainForm();
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();
            }else if (userExits == 0)
            {
                textBox3.Visible = true;
            }
            else
            {
                MessageBox.Show("You are unable to login!", "Login Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
