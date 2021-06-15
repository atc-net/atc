using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc.Math.InternationalSystemOfUnits
{
    /// <summary>
    /// Enumeration: BaseUnitType
    /// </summary>
    /// <remarks>
    /// https://da.wikipedia.org/wiki/Grundl%C3%A6ggende_SI-enheder
    /// </remarks>
    public enum BaseUnitType
    {
        /// <summary>
        /// None, and it's not a BaseUnitType.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None,

        /// <summary>
        /// Length.
        /// </summary>
        [LocalizedDescription("BaseUnitTypeLength", typeof(EnumResources))]
        Length,

        /// <summary>
        /// Mass.
        /// </summary>
        [LocalizedDescription("BaseUnitTypeMass", typeof(EnumResources))]
        Mass,

        /// <summary>
        /// Time.
        /// </summary>
        [LocalizedDescription("BaseUnitTypeTime", typeof(EnumResources))]
        Time,

        /// <summary>
        /// ElectricCurrent.
        /// </summary>
        [LocalizedDescription("BaseUnitTypeElectricCurrent", typeof(EnumResources))]
        ElectricCurrent,

        /// <summary>
        /// ThermodynamicTemperature.
        /// </summary>
        [LocalizedDescription("BaseUnitTypeThermodynamicTemperature", typeof(EnumResources))]
        ThermodynamicTemperature,

        /// <summary>
        /// LuminousIntensity.
        /// </summary>
        [LocalizedDescription("BaseUnitTypeLuminousIntensity", typeof(EnumResources))]
        LuminousIntensity,

        /// <summary>
        /// AmountOfSubstance.
        /// </summary>
        [LocalizedDescription("BaseUnitTypeAmountOfSubstance", typeof(EnumResources))]
        AmountOfSubstance,
    }
}
