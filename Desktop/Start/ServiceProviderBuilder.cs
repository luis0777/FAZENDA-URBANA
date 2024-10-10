using Desktop.ModuloCliente;
using Desktop.ModuloInicial;
using Desktop.ModuloUsuario;
using Microsoft.Extensions.DependencyInjection;
using Util.BD;

namespace Desktop.Start
{
    public static class ServiceProviderBuilder
    {
        public static ServiceProvider Build()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<frmIncluirCliente>();
            serviceCollection.AddTransient<frmGerenciarCliente>();
            serviceCollection.AddTransient<frmIncluirUsuario>();
            serviceCollection.AddTransient<frmMenu>();
            serviceCollection.AddTransient<frmLogin>();
            serviceCollection.AddScoped<SqlFactory>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}