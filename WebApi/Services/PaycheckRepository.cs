using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class PaycheckRepository : IPaycheckRepository
    {
        public Task Create(Paycheck entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Paycheck>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Paycheck> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
