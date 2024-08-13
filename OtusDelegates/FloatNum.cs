
namespace OtusDelegates
{
    public class FloatNum : IFloatNum
    {
        public float Value { get; }
        public FloatNum(float value)
        {
            Value = value;
        }
    }
}
