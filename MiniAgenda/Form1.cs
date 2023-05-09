using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniAgenda
{
    public partial class Anotações : Form
    {
        DataTable table;
        public Anotações()
        {
            InitializeComponent();
        }

        private void Anotações_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Título", typeof(string));
            table.Columns.Add("Mensagem", typeof (string));

            dgvNotas.DataSource = table;
            dgvNotas.Columns["Mensagem"].Visible = false;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtTitulo.Clear();
            txtMensagem.Clear();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitulo.Text, txtMensagem.Text);
            btnNovo.PerformClick();

        }

        private void btnLer_Click(object sender, EventArgs e)
        {
            int index = dgvNotas.CurrentCell.RowIndex;
            if (index > -1)
            {
                txtTitulo.Text = table.Rows[index].ItemArray[0].ToString();
                txtMensagem.Text = table.Rows[index].ItemArray[1].ToString();

            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            int index = dgvNotas.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }

        private void dgvNotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
