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

        private void PrepararTabla()
        {
            string comando;
            DataTable DT = new DataTable();

            //SELECT * FROM Equipo
            comando = "SELECT * FROM Equipo;";

            DT = DBCommands.CargarTabla(comando);
            dGVConsulta.DataSource = DT;
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            DBCommands.CrearBBDDSiNoExiste();
            PrepararTabla();
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

                PrepararTabla();
            }
            else
            {
                MessageBox.Show("No ha elegido un pedido o no hay pedidos pendientes en este momento");
            }
        }

        private void dGVConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
