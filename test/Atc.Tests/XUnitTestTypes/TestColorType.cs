namespace Atc.Tests.XUnitTestTypes;

public enum TestColorType
{
    None,

    [System.ComponentModel.Description("The color red")]
    [Display(Name = "Display Red", Description = "A red color")]
    Red,

    [System.ComponentModel.Description("The color blue")]
    Blue,

    [Display(Name = "Display Green")]
    Green,
}