using System;
using System.Reflection;

namespace Atc.Rest.Options
{
    public class AssemblyPairOptions
    {
        public AssemblyPairOptions(Assembly apiAssembly, Assembly domainAssembly)
        {
            ApiAssembly = apiAssembly ?? throw new ArgumentNullException(nameof(apiAssembly));
            DomainAssembly = domainAssembly ?? throw new ArgumentNullException(nameof(domainAssembly));
        }

        public Assembly ApiAssembly { get; }

        public Assembly DomainAssembly { get; }

        public override string ToString()
        {
            return $"{nameof(ApiAssembly)}: {ApiAssembly?.FullName}, {nameof(DomainAssembly)}: {DomainAssembly?.FullName}";
        }
    }
}