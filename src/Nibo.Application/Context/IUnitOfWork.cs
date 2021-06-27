using System;
using System.Threading.Tasks;

namespace Nibo.Application.Context
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
