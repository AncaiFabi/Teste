using System;
using System.Windows.Forms;
using Modelo;
using Controller;
using System.Data;

namespace testando
{
    public partial class FrmCliente : Form
    {
        int codigo;
        int idperfil;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //chamo a instancia do modelo usuario
            UsuarioModelo usmodelo=new UsuarioModelo();
            //populo os atributos do modelo
            usmodelo.nome=txtnome.Text;
            usmodelo.senha=txtSenha.Text;
            usmodelo.idperfil = idperfil;
            UsuarioController uscontrole=new UsuarioController();
           if(uscontrole.cadastrar(usmodelo) == true)
            {
                MessageBox.Show("Usuário cadastrado " + txtnome.Text);
            }
            else
            {
                 MessageBox.Show("Usuário não cadastrado ");

            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            //instaciar meu controleusuario
            UsuarioController usControle=new UsuarioController();
            datausuario.DataSource = usControle.ObterDados("SELECT * from usuario");
            //MessageBox.Show("Seja bem vindo(a)");
            cboPerfil.DataSource = usControle.ObterDados("select * from perfil_usuario");
            cboPerfil.DisplayMember = "nome_perfil";
            cboPerfil.ValueMember = "id_perfil";
 
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            //chamando a instancia do objeto da conexao
            Conexao conexao = new Conexao();
            //verifico se a conexão funcionou
           if(conexao.getConexao() == null)
            {
                MessageBox.Show("Erro na conexao");
            }
            else
            {
                MessageBox.Show("Acessando o servidor");
            }
        }

        private void datausuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datausuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {//convertendo a 1 celula em inteiro
            codigo = Convert.ToInt32(datausuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            //convert o inteiro para string
            MessageBox.Show("usuário selecionado : " + codigo.ToString());
            txtnome.Text = datausuario.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txtSenha.Text = datausuario.Rows[e.RowIndex].Cells["Senha"].Value.ToString();
            cboPerfil.Text = datausuario.Rows[e.RowIndex].Cells["id_perfil"].Value.ToString();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            UsuarioController uscontroller = new UsuarioController();
            //chamo o metodo excluir do ususraio controller se verdade
            if(uscontroller.Excluir(codigo)==true)
            {//excluir o usuario
                MessageBox.Show("codigo do usuário " + codigo + " excluido com sucesso");
            }
            else
            {//falso erro ao excluir
                MessageBox.Show("Erro ao excluir o usuário");
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            //instancio o objeto usuario controle
            UsuarioController usController = new UsuarioController();  
            UsuarioModelo usmodelo = new UsuarioModelo();
            usmodelo.nome= txtnome.Text;
            usmodelo.senha = txtSenha.Text;
            usmodelo.idusuario = codigo;
            if( usController.editar(usmodelo)==true)
            {
                MessageBox.Show("Usuario atualizado com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao atualizar usuário");
            }
        }

        private void btnListarusuario_Click(object sender, EventArgs e)
        {
            frmListarUsuario frmListar = new frmListarUsuario();
            frmListar.ShowDialog();//mostro o formulário listar
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //variavel convert para inteiro
            idperfil = Convert.ToInt32(((DataRowView)cboPerfil.SelectedItem)["id_perfil"]);
            MessageBox.Show("id= " + idperfil);
        }

        private void FrmCliente_MouseHover(object sender, EventArgs e)
        {

        }

        private void label3_MouseHover(object sender, EventArgs e)
        {

        }

        private void txtSenha_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtSenha, "Insira a senha");
        }
    }
}
