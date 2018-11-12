using Xunit;
using Bogus;
using MoxiWorks.Platform;

namespace MoxiWorks.Test
{
    public class BuyerTransactionFixture
    {

        [Fact]
        public void ValidateMoxiWorksContactIdOrPartnerContactID()
        {
            var fake = GetFakerBuyerTransaction().Generate();
            fake.PartnerContactId = "foo";
            fake.MoxiWorksContactId = "bar";
            Assert.False(fake.Validate());
            Assert.StrictEqual(1, fake.Errors.Count); 
        }

        [Fact]
        public void ValidateMlsBuyerTransactionContainsMlsNumber()
        {
            var fake = GetFakerBuyerTransaction().Generate();
            fake.IsMlsTransaction = true;
            fake.MlsNumber = string.Empty;
            
            Assert.False(fake.Validate());
            Assert.StrictEqual(1, fake.Errors.Count); 
        }

        [Fact]
        public void ValidateCommisionPercentageOrCommisionFlatFeeNotBoth()
        {
            var fake = GetFakerBuyerTransaction().Generate();
            fake.CommissionPercentage = 0.10m;
            fake.CommissionFlatFee = 2000; 
            
            Assert.False(fake.Validate());
            Assert.StrictEqual(1, fake.Errors.Count); 
        }
        
        [Fact]
        public void ValidateTargetPriceOrMinMaxPriceButNotBoth()
        {
            var fake = GetFakerBuyerTransaction().Generate();
            fake.TargetPrice = 1;
            fake.MinPrice = 1;
            fake.MaxPrice = 1;
            
            Assert.False(fake.Validate());
            Assert.StrictEqual(1, fake.Errors.Count); 
        }

        [Fact]
        public void ReturnsByTransaction()
        {
           var buyerTransaction = StubDataLoader.LoadJsonFile("BuyerTransaction.json");  
        }
        
        public Faker<BuyerTransaction> GetFakerBuyerTransaction()
        {
            return new Faker<BuyerTransaction>()
                .RuleFor(b => b.Address, f => f.Address.StreetAddress())
                .RuleFor(b => b.City, f => f.Address.City())
                .RuleFor(b => b.State, f => f.Address.State())
                .RuleFor(b => b.ZipCode, f => f.Address.ZipCode())
                .RuleFor(b => b.Notes, f => f.Lorem.Paragraph());

        }
        
        
    }
}