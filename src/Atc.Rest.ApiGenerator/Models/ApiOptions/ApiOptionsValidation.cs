namespace Atc.Rest.ApiGenerator.Models.ApiOptions
{
    public class ApiOptionsValidation
    {
        public CasingStyle OperationIdCasingStyle { get; set; } = CasingStyle.CamelCase;

        public CasingStyle ModelNameCasingStyle { get; set; } = CasingStyle.PascalCase;

        public CasingStyle ModelPropertyNameCasingStyle { get; set; } = CasingStyle.CamelCase;
    }
}