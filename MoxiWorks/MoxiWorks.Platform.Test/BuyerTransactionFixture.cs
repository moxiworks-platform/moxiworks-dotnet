using System.Text;
using NUnit.Framework;
using Bogus;
namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    public class BuyerTransactionFixture
    {

        [Test]
        public void ValidateMoxiWorksContactIdOrPartnerContactID()
        {
            var fake = GetFakerBuyerTransaction().Generate();
            fake.PartnerContactId = "foo";
            fake.MoxiWorksContactId = "bar";
            Assert.IsFalse(fake.Validate());
            Assert.AreEqual(1, fake.Errors.Count); 
        }

        [Test]
        public void ValidateMlsBuyerTransactionContainsMlsNumber()
        {
            var fake = GetFakerBuyerTransaction().Generate();
            fake.IsMlsTransaction = true;
            fake.MlsNumber = string.Empty;
            
            Assert.IsFalse(fake.Validate());
            Assert.AreEqual(1, fake.Errors.Count); 
        }

        [Test]
        public void ValidateCommisionPercentageOrCommisionFlatFeeNotBoth()
        {
            var fake = GetFakerBuyerTransaction().Generate();
            fake.CommisionPercentage = 0.10m;
            fake.CommissionFlatFee = 2000; 
            
            Assert.IsFalse(fake.Validate());
            Assert.AreEqual(1, fake.Errors.Count); 
        }
        
        [Test]
        public void ValidateTargetPriceOrMinMaxPriceButNotBoth()
        {
            var fake = GetFakerBuyerTransaction().Generate();
            fake.TargetPrice = 1;
            fake.MinPrice = 1;
            fake.MaxPrice = 1;
            
            Assert.IsFalse(fake.Validate());
            Assert.AreEqual(1, fake.Errors.Count); 
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