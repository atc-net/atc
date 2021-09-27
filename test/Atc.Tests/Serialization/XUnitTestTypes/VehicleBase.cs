using System.Text.Json.Serialization;
using Atc.Serialization.JsonConverters;

// ReSharper disable MemberCanBeProtected.Global
namespace Atc.Tests.Serialization.XUnitTestTypes
{
    [JsonConverter(typeof(JsonTypeDiscriminatorConverter<VehicleBase>))]
    public abstract class VehicleBase : ITypeDiscriminator
    {
        protected VehicleBase(string plateNumber)
        {
            this.PlateNumber = plateNumber;
        }

        public string TypeDiscriminator { get; set; } = string.Empty;

        public string PlateNumber { get; set; }

        public int NumberOfWheels { get; set; }

        public new virtual string ToString() => $"{nameof(PlateNumber)}: {PlateNumber}, {nameof(NumberOfWheels)}: {NumberOfWheels}";
    }
}