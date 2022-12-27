namespace Atc.Tests.XUnitTestTypes;

internal sealed class TestItem
{
    public int Dosage { get; set; }

    public string Drug { get; set; }

    public string Patient { get; set; }

    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"{nameof(Dosage)}: {Dosage}, {nameof(Drug)}: {Drug}, {nameof(Patient)}: {Patient}, {nameof(Date)}: {Date}";
    }
}