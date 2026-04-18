using NorthWind.Services.DTOs;

namespace NorthWind.XUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var product = new ProductDto
            {
                UnitPrice = 20,
                UnitsInStock = 5
            };

            Assert.Equal(100, product.InventoryValue);
        }
    }
}