using System.Reflection;

namespace DM.Shared.Application.Mapping
{
    public class MapperRegistrator
    {
        public void FromAssembly(Assembly assembly)
        {
            var configs = assembly
                .GetTypes()
                .Where(t => t.GetInterface(nameof(IMapperConfig)) != null);

            foreach (var config in configs)
            {
                var configInstance = Activator.CreateInstance(config);

                var createMethod = config.GetMethod(nameof(IMapperConfig.Create));
                createMethod?.Invoke(configInstance, null);
            }
        } 
    }
}
