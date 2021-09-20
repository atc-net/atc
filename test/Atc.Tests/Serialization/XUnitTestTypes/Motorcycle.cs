namespace Atc.Tests.Serialization.XUnitTestTypes
{
    public class Motorcycle : VehicleBase
    {
        public Motorcycle(string plateNumber)
            : base(plateNumber)
        {
            this.TypeDiscriminator = nameof(Motorcycle);
            this.NumberOfWheels = 2;
        }

        public override string ToString() => $"{base.ToString()}";
    }
}