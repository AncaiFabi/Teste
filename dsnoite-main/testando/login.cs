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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioModelo us = new UsuarioModelo();
            UsuarioController uscontrole= new UsuarioController();
            us.nome = txtNome.Text;
            us.senha = txtSenha.Text;
            if(string.IsNullOrEmpty(us.nome))
            {
                    MessageBox.Show("Nome Vazio");
                    txtNome.Focus();
            }
            if (string.IsNullOrEmpty(us.senha))
            {
                MessageBox.Show("Nome Vazio");
                txtSenha.Focus();
            }
            if(uscontrole.logar(us) == true)
            {
                frmPrincipal principal= new frmPrincipal();
                principal.ShowDialog();
            }
            else
            {
                MessageBox.Show("usuario ou senha invalidos");
            }
        }

        private void txtUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
