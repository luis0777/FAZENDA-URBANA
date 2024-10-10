using Microsoft.Data.SqlClient;
using Model;
using System.Data;
using Util.BD;

namespace Controller
{
    public class ClienteController
    {
        private readonly IDbConnection _connection;

        public ClienteController(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public bool IncluirCliente(ClienteModel clienteModel)
        {
            bool incluirCliente = false;
            try
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand("InserirCliente", (SqlConnection)_connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NomeCliente", clienteModel.NomeCliente);
                    command.Parameters.AddWithValue("@Cpf", clienteModel.Cpf);                    
                    command.Parameters.AddWithValue("@Email", clienteModel.Email);
                    command.Parameters.AddWithValue("@Senha", clienteModel.Senha);                    

                    if (command.ExecuteNonQuery() > 0)
                    {
                        incluirCliente = true;
                        _connection.Close();
                    }                    
                }                
            }
            catch
            {
                _connection.Close();
                throw;
            }
            return incluirCliente;
        }

        public List<ClienteModel> ConsultarCliente(string nomeCliente)
        {
            List<ClienteModel> lstClienteModel = new List<ClienteModel>();
            try
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand("ConsultarCliente", (SqlConnection)_connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NomeCliente", nomeCliente);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ClienteModel cliente = new ClienteModel
                            {
                                Id = (int)reader["Id"],
                                NomeCliente = reader["NomeCliente"].ToString(),
                                Cpf = reader["Cpf"].ToString(),
                                Email = reader["Email"].ToString()                                
                            };
                            lstClienteModel.Add(cliente);
                        }
                    }
                    _connection.Close();
                }
            }
            catch
            {
                _connection.Close();
                throw;
            }
            return lstClienteModel;
        }

        public bool AlterarCliente(ClienteModel clienteModel)
        {
            bool alterarCliente = false;
            try
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand("AlterarCliente", (SqlConnection)_connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NomeCliente", clienteModel.NomeCliente);
                    command.Parameters.AddWithValue("@Id", clienteModel.Id);                   

                    if (command.ExecuteNonQuery() > 0)
                    {
                        alterarCliente = true;
                        _connection.Close();
                    }
                }
            }
            catch
            {
                _connection.Close();
                throw;
            }            
            return alterarCliente;
        }

        public bool ExcluirCliente(int id)
        {
            bool excluirCliente = false;
            try
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand("ExcluirCliente", (SqlConnection)_connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@Id", id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        excluirCliente = true;
                        _connection.Close();
                    }
                }
            }
            catch
            {
                _connection.Close();
                throw;
            }
            return excluirCliente;
        }
    }
}