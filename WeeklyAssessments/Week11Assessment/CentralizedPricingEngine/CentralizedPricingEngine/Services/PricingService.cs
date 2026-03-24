namespace CentralizedPricingEngine.Services
{
    public class PricingService : IPricingService
    {        

        public double CalculateDiscount(double basePrice, string promocode)
        {
            if(promocode == "WINTER25")
            {
                return basePrice - (basePrice * 0.15);
            }
            if(promocode == "FREESHIP")
            {
                return basePrice - 5;
            }
            return basePrice;
        }
    }
}
