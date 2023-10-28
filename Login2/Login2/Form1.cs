using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsuario.Text.Equals("Admin") && txtSenha.Text.Equals("Admin1"))
                {
                    var Form1 = new Analista();
                    Form1.Show();

                    this.Visible = false;
                }
                 else
                {
                    MessageBox.Show("RA ou senha incorreto.",
                                    "Desculpe.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    txtSenha.Text = "";
                }
     
            }catch(Exception ex)
            {
                MessageBox.Show("Desculpe",
                                ex.Message,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form1 = new Mudar_Senha();
            Form1.Show();  
            this.Visible = false;
        }
    }
}
