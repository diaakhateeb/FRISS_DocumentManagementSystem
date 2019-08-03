using Microsoft.EntityFrameworkCore;
using Repository;

namespace Factory
{
    public static class UnitOfWorkFactory<T, TT> where T : DbContext, new() where TT : class, new()
    {
        public static UnitOfWork<TT> UnitOfWorkInstance()
        {
            return new UnitOfWork<TT>(new T(), new TT());
        }
    }
}
