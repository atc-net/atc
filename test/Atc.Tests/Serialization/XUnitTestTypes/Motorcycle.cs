namespace Atc.Tests.Serialization.XUnitTestTypes;

public class Motorcycle : VehicleBase
{
    public Motorcycle(string plateNumber)
        : base(plateNumber)
    {
        TypeDiscriminator = nameof(Motorcycle);
        NumberOfWheels = 2;
    }

    public override string ToString() => $"{base.ToString()}";
}