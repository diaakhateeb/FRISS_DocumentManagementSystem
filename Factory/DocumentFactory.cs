using DocumentRepository.Api.Interfaces;
using Factory.Interfaces;
using Microsoft.Extensions.Logging;
using Unity;
using Unity.Injection;

namespace Factory
{
    public class DocumentFactory<T> : IDocumentFactory<T> where T : IDocumentRepository
    {
        private IUnityContainer _container;
        private CustomLogger.CustomLogger _logger;

        public T GetInstance()
        {
            try
            {
                if (_container != null) return (T)_container.Resolve<IDocumentRepository>();

                _container = new UnityContainer();
                _container.RegisterType<IDocumentRepository, T>
                (
                    new InjectionConstructor()
                );
                return (T)_container.Resolve<IDocumentRepository>();
            }
            catch (ResolutionFailedException resFailExp)
            {
                _logger = new CustomLogger.CustomLogger();
                _logger.Log(LogLevel.Error, resFailExp.Message, "DocumentFactory..." + typeof(T));
                throw;
            }
        }
    }
}
