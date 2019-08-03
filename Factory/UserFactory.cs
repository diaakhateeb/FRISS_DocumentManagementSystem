using DMSDomainModel.Entities;
using Factory.Interfaces;
using Microsoft.Extensions.Logging;
using Repository;
using Unity;
using Unity.Injection;
using UserRepository.Api.Interfaces;

namespace Factory
{
    public class UserFactory<T> : IUserFactory<T> where T : IUserRepository
    {
        private IUnityContainer _container;
        private CustomLogger.CustomLogger _logger;
        public T GetInstance()
        {
            try
            {
                if (_container != null) return (T)_container.Resolve<IUserRepository>();

                _container = new UnityContainer();
                //var frissDmsContextDb = new FRISSDMSContext();
                var userContextRepo = new Repository<User>(new FRISSDMSContext());

                _container.RegisterType<IUserRepository, T>
                (
                    new InjectionConstructor(userContextRepo)
                );
                return (T)_container.Resolve<IUserRepository>();
            }
            catch (ResolutionFailedException resFailExp)
            {
                _logger = new CustomLogger.CustomLogger();
                _logger.Log(LogLevel.Error, resFailExp.Message, "UserFactory..." + typeof(T));
                throw;
            }
        }
    }
}
