using Model;
using Newtonsoft.Json;
using Util.BD;

namespace Desktop.ModuloUsuario
{
    public partial class frmIncluirUsuario : Form
    {
        private readonly SqlFactory _factory;
        public frmIncluirUsuario(SqlFactory factory)
        {
            InitializeComponent();
            _factory = factory;
        }
        #region Eventos
        private async void mskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            string cep = mskCep.Text;
            string apiUrl = $"https://viacep.com.br/ws/{cep}/json/";
            string response = await GetApiData(apiUrl);
            var endereco = JsonConvert.DeserializeObject<EnderecoModel>(response);
            txtBairro.Text = endereco.Bairro;
        }
        #endregion

        #region Métodos
        private async Task<string> GetApiData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        #endregion
    }
}