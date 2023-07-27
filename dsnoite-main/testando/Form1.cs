using System;
using System.Windows.Forms;
using Modelo;
using Controller;
namespace testando
{
    public partial class FrmCliente : Form
    {
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
            datausuario.DataSource = usControle.ObterDados("select * from usuario");
            //MessageBox.Show("Seja bem vindo(a)");
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
            int codigo = Convert.ToInt32(datausuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            //convert o inteiro para string
            MessageBox.Show("usuário selecopnado : " + codigo.ToString());
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {

        }
    }
}
