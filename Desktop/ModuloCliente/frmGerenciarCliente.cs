using Controller;
using Model;
using Util.BD;

namespace Desktop.ModuloCliente
{
    public partial class frmGerenciarCliente : Form
    {
        private readonly SqlFactory _factory;

        public frmGerenciarCliente(SqlFactory factory)
        {
            InitializeComponent();
            _factory = factory;
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            ClienteController clienteController = new ClienteController(_factory);
            try
            {
                if (!String.IsNullOrEmpty(txtFiltro.Text))
                {
                    dgCliente.DataSource = clienteController.ConsultarCliente(txtFiltro.Text);
                    if (dgCliente.RowCount == 0)
                    {
                        MessageBox.Show("Não existem registros para o cliente informado.");
                    }
                }
                else
                {
                    MessageBox.Show("Preencher o filtro.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar dados do cliente: " + ex.Message);
            }
        }

        private void dgCliente_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgCliente.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgCliente.SelectedRows[0];
                    txtNome.Text = selectedRow.Cells["NomeCliente"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar dados do cliente: " + ex.Message);
            }
        }

        private void btnAlterarCliente_Click(object sender, EventArgs e)
        {
            ClienteController clienteController = new ClienteController(_factory);
            ClienteModel clienteModel = new ClienteModel();
            bool clienteAtualizado = false;
            try
            {
                if (dgCliente.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgCliente.SelectedRows[0];
                    if (!String.IsNullOrEmpty(txtNome.Text))
                    {
                        clienteModel.NomeCliente = txtNome.Text;
                    }
                    else
                    {
                        MessageBox.Show("Preencher o campo Nome.");
                    }
                    clienteModel.Id = Convert.ToInt16(selectedRow.Cells["Id"].Value);
                    clienteAtualizado = clienteController.AlterarCliente(clienteModel);
                    if (clienteAtualizado)
                    {
                        MessageBox.Show("Dados do cliente atualizados com sucesso.");
                        LimparTela();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados do cliente: " + ex.Message);
            }
        }

        private void LimparTela()
        {
            try
            {
                dgCliente.DataSource = null;
                txtFiltro.Clear();
                txtNome.Clear();
                txtFiltro.Focus();
            }
            catch
            {
                throw;
            }
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            ClienteController clienteController = new ClienteController(_factory);
            bool clienteExcluido = false;
            try
            {
                if (dgCliente.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgCliente.SelectedRows[0];
                    clienteExcluido = clienteController.ExcluirCliente(Convert.ToInt16(selectedRow.Cells["Id"].Value));
                    if (clienteExcluido)
                    {
                        MessageBox.Show("Dados do cliente excluído com sucesso.");
                        LimparTela();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir dados do cliente: " + ex.Message);
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
