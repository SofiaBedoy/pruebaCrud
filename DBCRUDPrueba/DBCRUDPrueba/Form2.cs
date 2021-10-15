using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCRUDPrueba
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            textBoxfecha.Text = $"{DateTime.Now:d}\n";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxmarca.Text == "" || textBoxmodelo.Text == "" || textBoxserie.Text == "" || comboBoxtipo.Text == "" || textBoxprocesador.Text == "" || textBoxcapacidad.Text == "" || comboBoxestado.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
            }
            else
            {
                DBCommands.InsertarComputadora(
                    textBoxfecha.Text,
                    textBoxmarca.Text,
                    textBoxmodelo.Text,
                    textBoxserie.Text,
                    comboBoxtipo.Text,
                    textBoxprocesador.Text,
                    textBoxcapacidad.Text,
                    comboBoxestado.Text);

                this.Close();
            }
        }
    }
}
