namespace Factory.Interfaces
{
    public interface IDocumentFactory<out T>
    {
        /// <summary>
        /// Document factory interface.
        /// </summary>
        /// <typeparam name="T">Generic type to get instance of.</typeparam>
        /// <summary>
        /// Gets instance of the specified generic type.
        /// </summary>
        /// <returns>Returns specified type object.</returns>
        T GetInstance();
    }
}
