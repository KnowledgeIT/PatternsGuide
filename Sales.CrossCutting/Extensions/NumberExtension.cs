namespace Sales.CrossCutting.Extensions
{
    public static class NumberExtension
    {
        public static decimal RoundCentsUp(this decimal value)
        {
            decimal result = value;
            int lastDecimal = value.ToString().Substring(value.ToString().Length - 1, 1).ToInt16();
            if (lastDecimal == 0)
                return value;

            if (lastDecimal != 0 && lastDecimal != 5)
            {
                if (lastDecimal < 5)
                {
                    result = value + (("0.05".ToDecimal() - $"0.0{lastDecimal}".ToDecimal()) / 100);
                }
                else
                {
                    result = value + (("0.10".ToDecimal() - $"0.0{lastDecimal}".ToDecimal()) / 100);
                }
            }

            return result;
        }
    }
}
