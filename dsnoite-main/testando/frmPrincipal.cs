using Controller;
using Modelo;
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
        int idUsu;//crio a variavel do id usuario local
        //passo oID pelo parametro do
        //declaro os objetos para instanciar o usuario
        UsuarioController usController = new UsuarioController();
        UsuarioModelo usmodelo = new UsuarioModelo();
        public frmPrincipal(int codigo)
        {
            idUsu = codigo;//atribui a variavel local
            MessageBox.Show("Seja bem vindo Id" + codigo);
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

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //carrego no usuario as informações
            usmodelo=usController.CarregaUsuario(idUsu);
            label1.Text = usmodelo.nome;
            if (usmodelo.idperfil == 2)
            {
                //deixar o meu invisivel
                usuarioToolStripMenuItem.Visible = false;
            }else
                if(usmodelo.idperfil == 1)
            {
                usuarioToolStripMenuItem.Visible = true;
            }
        }
    }
}
