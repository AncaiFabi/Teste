using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testando
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
          FrmCliente usuario = new FrmCliente();
           usuario.MdiParent = this;
           usuario.Show();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListarUsuario frmListar = new frmListarUsuario();
            frmListar.MdiParent = this;
            frmListar.Show();
        }
    }
}
