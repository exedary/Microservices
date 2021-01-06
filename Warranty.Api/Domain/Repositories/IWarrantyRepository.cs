using System;
using System.Threading.Tasks;

namespace Warranty.Api.Domain.Repositories
{
    internal interface IWarrantyRepository
    {
        public Task<Warranty> GetById(Guid id);

        public Task Add(Warranty warranty);
    }
}
