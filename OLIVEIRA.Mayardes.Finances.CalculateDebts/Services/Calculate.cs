namespace OLIVEIRA.Mayardes.Finances.CalculateDebts.Services
{
    public static class Calculate
    {
        private static decimal Value;
        public static void ToSum(decimal value)
        {
            Value += value;
        }
        public static decimal GetValueTotalExpenses()
        {
            return Value;
        }
    }
}
