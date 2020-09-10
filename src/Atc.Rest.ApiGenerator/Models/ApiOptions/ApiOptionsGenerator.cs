namespace Atc.Rest.ApiGenerator.Models.ApiOptions
{
    public class ApiOptionsGenerator
    {
        public bool UseNullableReferenceTypes { get; set; } = true;

        public bool UseAuthorization { get; set; } = true;

        public ApiOptionsGeneratorRequest Request { get; set; } = new ApiOptionsGeneratorRequest();

        public ApiOptionsGeneratorResponse Response { get; set; } = new ApiOptionsGeneratorResponse();
    }
}