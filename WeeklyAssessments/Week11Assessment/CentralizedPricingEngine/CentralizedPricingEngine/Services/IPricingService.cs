namespace CentralizedPricingEngine.Services
{
    public interface IPricingService
    {
        double CalculateDiscount(double basePrice, string promocode);        
    }
}
