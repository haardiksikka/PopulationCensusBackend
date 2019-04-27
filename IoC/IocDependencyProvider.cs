using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;

namespace IoC
{
    public static class IocDependencyProvider
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>The container.</value>
        public static IUnityContainer Container { get; set; }

        /// <summary>
        /// Initializes the unity container.
        /// </summary>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="unityContainerExtension">Optionally, a unity container extension you might want to register</param>
        /// <returns>Unity container.</returns>
        public static IUnityContainer InitializeContainer(string containerName, UnityContainerExtension unityContainerExtension = null)
        {
            if (Container == null)
            {
                Container = new UnityContainer();

                if (unityContainerExtension != null)
                {
                    Container.AddExtension(unityContainerExtension);
                }
            }

            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
            section.Configure(Container, containerName);

            return Container;
        }

        /// <summary>
        /// Resolves with specified parameters.
        /// </summary>
        /// <typeparam name="T">Parameters required by constructor.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Object instance.</returns>
        public static T Resolve<T>()
        {
            T instance;
            try
            {
                instance = Container.Resolve<T>();
            }
            catch
            {
                throw;
            }

            return instance;
        }
        public static T Resolve<T>(string name)
        {
            T instance;
            try
            {
                instance = Container.Resolve<T>(name);
            }
            catch
            {
                throw;
            }

            return instance;
        }

        /// <summary>
        /// Cleans up the unity container by calling its 'dispose' method.
        /// </summary>
        public static void CleanUp()
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }
    }
}
