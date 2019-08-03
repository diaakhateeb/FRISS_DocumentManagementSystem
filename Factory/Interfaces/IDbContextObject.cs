namespace Factory.Interfaces
{
    public interface IDbContextObject<out T> where T : new()
    {
        T GetInstance();
    }
}
