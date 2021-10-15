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
    public partial class frmIndex : Form
    {
        public frmIndex()
        {
            InitializeComponent();
        }

        private void PrepararTabla(string var, string value)
        {
            string comando = "";
            DataTable DT = new DataTable();

            if (var == "*")
            {
                comando = "SELECT * FROM Equipo";
            }
            else
            {
                if (value != "")
                {
                    comando = "SELECT * FROM Equipo WHERE " + var + " LIKE \"%" + value + "%\"";
                }
            }

            //SELECT * FROM Equipo
            //comando = "SELECT "+row+" FROM Equipo WHERE "+var+" = \""+ value +"\";";

            comando = comando + ";";

            DT = DBCommands.CargarTabla(comando);
            dGVConsulta.DataSource = DT;
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            DBCommands.CrearBBDDSiNoExiste();
            comboBox1.Text = "*";
            PrepararTabla(comboBox1.Text, "");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdd formAgregar = new FormAdd();
            formAgregar.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dGVConsulta.SelectedCells.Count > 0)
            {
                int selectedrowindex = dGVConsulta.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dGVConsulta.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells[0].Value);
                DBCommands.EliminarDato(a);

                PrepararTabla("*", "");
            }
            else
            {
                MessageBox.Show("No ha elegido un pedido o no hay pedidos pendientes en este momento");
            }
        }

        private void dGVConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
