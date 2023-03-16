namespace ValidationAttributes.Attributes;

public class MyRangeAttribute : MyValidationAttribute
{
    private readonly int minValue;
    private int maxValue;

    public MyRangeAttribute(int minValue, int maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
    }

    public override bool IsValid(object obj)
        => (int)obj > minValue && (int)obj < maxValue;
}
