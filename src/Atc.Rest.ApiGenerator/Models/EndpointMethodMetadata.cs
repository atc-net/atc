using System;
using System.Collections.Generic;
using System.Net;
using Atc.Rest.ApiGenerator.SyntaxGenerators.Api;
using Microsoft.OpenApi.Models;

namespace Atc.Rest.ApiGenerator.Models
{
    public class EndpointMethodMetadata
    {
        public EndpointMethodMetadata(
            string segmentName,
            string route,
            OperationType httpOperation,
            string methodName,
            string contractInterfaceHandlerTypeName,
            string? contractParameterTypeName,
            string? contractResultTypeName,
            List<Tuple<HttpStatusCode, string, OpenApiSchema?>> contractReturnTypeNames,
            SyntaxGeneratorContractParameter? sgContractParameter)
        {
            SegmentName = segmentName;
            Route = route;
            HttpOperation = httpOperation;
            MethodName = methodName;
            ContractInterfaceHandlerTypeName = contractInterfaceHandlerTypeName;
            ContractParameterTypeName = contractParameterTypeName;
            ContractResultTypeName = contractResultTypeName;
            ContractReturnTypeNames = contractReturnTypeNames;
            ContractParameter = sgContractParameter;
        }

        public string SegmentName { get; private set; }

        public string Route { get; private set; }

        public OperationType HttpOperation { get; private set; }

        public string MethodName { get; private set; }

        public string ContractInterfaceHandlerTypeName { get; private set; }

        public string? ContractParameterTypeName { get; private set; }

        public string? ContractResultTypeName { get; private set; }

        public List<Tuple<HttpStatusCode, string, OpenApiSchema?>> ContractReturnTypeNames { get; private set; }

        public SyntaxGeneratorContractParameter? ContractParameter { get; private set; }

        public override string ToString()
        {
            return $"{nameof(SegmentName)}: {SegmentName}, {nameof(HttpOperation)}: {HttpOperation}, {nameof(MethodName)}: {MethodName}, {nameof(Route)}: {Route}";
        }
    }
}