using System;
using System.Collections.Generic;
using System.Reflection;

// ReSharper disable ConstantNullCoalescingCondition
namespace Atc.Rest.Options
{
    public class RestApiOptions
    {
        public bool AllowAnonymousAccessForDevelopment { get; set; } = true;

        public bool UseApplicationInsights { get; set; } = true;

        public bool UseAutoRegistrateServices { get; set; } = true;

        public bool UseEnumAsStringInSerialization { get; set; } = true;

        public RestApiOptionsErrorHandlingExceptionFilter ErrorHandlingExceptionFilter { get; set; } = new RestApiOptionsErrorHandlingExceptionFilter();

        public bool UseRequireHttpsPermanent { get; set; } = true;

        public bool UseJsonSerializerOptionsIgnoreNullValues { get; set; } = true;

        public bool UseValidateServiceRegistrations { get; set; } = true;

        public List<AssemblyPairOptions> AssemblyPairs { get; set; } = new List<AssemblyPairOptions>();

        public void AddAssemblyPairs(Assembly? apiAssembly, Assembly? domainAssembly)
        {
            if (apiAssembly == null)
            {
                throw new ArgumentNullException(nameof(apiAssembly));
            }

            if (domainAssembly == null)
            {
                throw new ArgumentNullException(nameof(domainAssembly));
            }

            this.AssemblyPairs ??= new List<AssemblyPairOptions>();
            this.AssemblyPairs.Add(new AssemblyPairOptions(apiAssembly, domainAssembly));
        }
    }
}