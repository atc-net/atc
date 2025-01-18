namespace Atc.Tests.Serialization.XUnitTestTypes;

internal sealed class Motorcycle : VehicleBase
{
    public Motorcycle(string plateNumber)
        : base(plateNumber)
    {
        TypeDiscriminator = nameof(Motorcycle);
        NumberOfWheels = 2;
    }

    public override string ToString() => $"{base.ToString()}";
}