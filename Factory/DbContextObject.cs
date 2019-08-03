using Factory.Interfaces;

namespace Factory
{
    public class DbContextObject<T> : IDbContextObject<T> where T : new()
    {
        public T GetInstance()
        {
            return new T();
        }
    }
}
