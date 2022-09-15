namespace Atc.Tests.Serialization.XUnitTestTypes;

public class Car : VehicleBase
{
    public Car(string plateNumber)
        : base(plateNumber)
    {
        TypeDiscriminator = nameof(Car);
        NumberOfWheels = 4;
    }

    public bool HasSunroof { get; set; }

    public override string ToString() => $"{base.ToString()}, {nameof(HasSunroof)}: {HasSunroof}";
}