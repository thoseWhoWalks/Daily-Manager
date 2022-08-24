using System.Reflection;

namespace DM.Shared.Infrastructure.Extensions
{
    public static class AppDomainExtenstions
    {
        public static Assembly[] GetClientAssemblies(this AppDomain domain)
        {
            var DmAssemblyPrefix = domain.FriendlyName.Split('.')[0];

            return domain.GetAssemblies()
                .Where(a => !string.IsNullOrEmpty(a.FullName) && a.FullName.Contains(DmAssemblyPrefix))
                .ToArray();
        }
    }
}
