using System.Reflection;

namespace DM.Shared.Infrastructure.Extensions
{
    public static class AppDomainExtensions
    {
        public static Assembly[] GetClientAssemblies(this AppDomain domain)
        {
            var DmAssemblyPrefix = domain.FriendlyName.Split('.')[0];

            return Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Select(x => Assembly.Load(AssemblyName.GetAssemblyName(x)))
                .Where(a => !string.IsNullOrEmpty(a.FullName) && a.FullName.Contains(DmAssemblyPrefix))
                .ToArray();
        }
    }
}
