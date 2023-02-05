using System.Data.SqlClient;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class PaycheckRepository : IPaycheckRepository
    {
        private const string _connectionString = "Data Source=DESKTOP-TTJ6DGH\\SQLEXPRESS;Initial Catalog=WebCompany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public async Task Create(Paycheck entity)
        {
            var queryString = "insert into Paychecks(Id, PaycheckNumber) values(@id, @paycheckNumber)";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", entity.Id.ToString());
                command.Parameters.AddWithValue("@paycheckNumber", entity.PaycheckNumber);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<List<Paycheck>> GetAll()
        {
            var paychecks = new List<Paycheck>();
            var queryString = "select * from Paychecks";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var paycheck = new Paycheck
                        {
                            Id = Guid.Parse(sqlDataReader[0].ToString()),
                            PaycheckNumber = sqlDataReader[1].ToString(),
                            PaymentGross = Convert.ToDecimal(sqlDataReader[2]),
                            PaymentNet = Convert.ToDecimal(sqlDataReader[3]),
                            IsPaid = Convert.ToBoolean(sqlDataReader[4].ToString()),
                        };
                        paychecks.Add(paycheck);
                    }
                    sqlDataReader.Close();
                    return paychecks;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<Paycheck> GetById(Guid Id)
        {
            var paychecks = new List<Paycheck>();
            var queryString = "select * from Paychecks where Paychecks.Id=@id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var paycheck = new Paycheck
                        {
                            Id = Guid.Parse(sqlDataReader[0].ToString()),
                            PaycheckNumber = sqlDataReader[1].ToString(),
                            PaymentGross = Convert.ToDecimal(sqlDataReader[2]),
                            PaymentNet = Convert.ToDecimal(sqlDataReader[3]),
                            IsPaid = Convert.ToBoolean(sqlDataReader[4].ToString()),
                        };
                        paychecks.Add(paycheck);
                    }
                    sqlDataReader.Close();
                    return paychecks.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<Paycheck> GetByNumber(string paycheckNumber)
        {
            var paychecks = new List<Paycheck>();
            var queryString = "select * from Paychecks where Paychecks.PaycheckNumber=@paycheckNumber";

            using (var connection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand(queryString, connection);
                sqlCommand.Parameters.AddWithValue("@paycheckNumber", paycheckNumber);
                try
                {
                    connection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var paycheck = new Paycheck
                        {
                            Id = Guid.Parse(sqlDataReader[0].ToString()),
                            PaycheckNumber = sqlDataReader[1].ToString(),
                            PaymentGross = Convert.ToDecimal(sqlDataReader[2]),
                            PaymentNet = Convert.ToDecimal(sqlDataReader[3]),
                            IsPaid = Convert.ToBoolean(sqlDataReader[4].ToString()),
                        };
                        paychecks.Add(paycheck);
                    }
                    sqlDataReader.Close();
                    return paychecks.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task UpdateSalary(Paycheck paycheck)
        {
            var queryString = "update Paychecks set PaymentGross=@paymentGross, PaymentNet=@paymentNet where PaycheckNumber=@paycheckNumber";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@paymentGross", paycheck.PaymentGross);
                command.Parameters.AddWithValue("@paymentNet", paycheck.PaymentNet);
                command.Parameters.AddWithValue("@paycheckNumber", paycheck.PaycheckNumber);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
