namespace Atc.Serialization
{
    public class JsonSerializerFactorySettings
    {
        public bool UseCamelCase { get; set; } = true;

        public bool IgnoreNullValues { get; set; } = true;

        public bool PropertyNameCaseInsensitive { get; set; } = true;

        public bool WriteIndented { get; set; } = true;

        public bool UseConverterEnumAsString { get; set; } = true;

        public bool UseConverterTimespan { get; set; } = true;

        public bool UseConverterDatetimeOffsetMinToNull { get; set; }
    }
}