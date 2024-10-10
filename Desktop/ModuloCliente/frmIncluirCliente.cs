using Controller;
using Desktop.ValidadoresComponentes;
using Model;
using System.Security.Cryptography;
using Util.BD;
using Util.Controles;
using Util.Encrypt;

namespace Desktop
{
    public partial class frmIncluirCliente : Form
    {
        private readonly SqlFactory _factory;
        public frmIncluirCliente(SqlFactory factory)
        {
            InitializeComponent();
            _factory = factory;
        }

        private void btnIncluirCliente_Click(object sender, EventArgs e)
        {
            CPF cpf = new CPF();
            Email email = new Email();
            EncryptionHelper encryptionHelper = new EncryptionHelper();
            ValidadorTextBox validadorTextBox = new ValidadorTextBox();
            ClienteModel clienteModel = new ClienteModel();
            ClienteController clienteController = new ClienteController(_factory);
            bool retornoIncluirCliente = false;
            try
            {
                if (validadorTextBox.ValidarTextBoxesPreenchidos(txtNomeCliente.Parent))
                {
                    clienteModel.NomeCliente = txtNomeCliente.Text;
                }
                if (validadorTextBox.ValidarTextBoxesPreenchidos(mskCpf.Parent))
                {
                    if(cpf.ValidarCPF(mskCpf.Text))
                    {
                        clienteModel.Cpf = mskCpf.Text;
                    }
                    else
                    {
                        MessageBox.Show("CPF inválido");
                    }                    
                }
                if (validadorTextBox.ValidarTextBoxesPreenchidos(txtEmail.Parent))
                {
                    if (email.ValidarEmail(txtEmail.Text))
                    {                        
                        clienteModel.Email = txtEmail.Text;
                    }
                    else
                    {
                        MessageBox.Show("Email inválido");
                    }
                }
                if (validadorTextBox.ValidarTextBoxesPreenchidos(txtSenha.Parent))
                {
                    // Cria uma nova instância da classe Aes.
                    using (Aes myAes = Aes.Create())
                    {
                        byte[] senha = encryptionHelper.EncryptStringToBytes_Aes(txtEmail.Text, myAes.Key, myAes.IV);
                        clienteModel.Senha = senha;
                    }
                }
                retornoIncluirCliente = clienteController.IncluirCliente(clienteModel);
                if (retornoIncluirCliente)
                {
                    MessageBox.Show("Cliente cadastrado com sucesso");
                    InicializarTela();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void InicializarTela()
        {
            try
            {
                txtNomeCliente.Clear();
                mskCpf.Clear();
                txtEmail.Clear();
                txtSenha.Clear();
                txtNomeCliente.Focus();
            }
            catch
            {
                throw;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você realmente deseja sair?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
