using Bogus;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    public class SellerTransactionFixture
    {
        [Test]
        public void ValidateMoxiWorksContactIdOrPartnerContactId()
        {
            var fake = GetFakerSellerTransaction().Generate();
            fake.PartnerContactId = "foo";
            fake.MoxiWorksContactId = "bar";
            IsFalse(fake.Validate());
            AreEqual(1, fake.Errors.Count); 
        }

        [Test]
        public void ValidateMlsBuyerTransactionContainsMlsNumber()
        {
            var fake = GetFakerSellerTransaction().Generate();
            fake.IsMlsTransaction = true;
            fake.MlsNumber = string.Empty;
            
            IsFalse(fake.Validate());
            AreEqual(1, fake.Errors.Count); 
        }

        [Test]
        public void ValidateCommisionPercentageOrCommisionFlatFeeNotBoth()
        {
            var fake = GetFakerSellerTransaction().Generate();
            fake.CommissionPercentage = 0.10m;
            fake.CommissionFlatFee = 2000; 
            
            IsFalse(fake.Validate());
            IsTrue(fake.HasErrors);
            AreEqual(1, fake.Errors);
             
        }
        
        [Test]
        public void ValidateTargetPriceOrMinMaxPriceButNotBoth()
        {
            var fake = GetFakerSellerTransaction().Generate();
            fake.TargetPrice = 1;
            fake.MinPrice = 1;
            fake.MaxPrice = 1;
            
            IsFalse(fake.Validate());
            IsTrue(fake.HasErrors);
            AreEqual(1, fake.Errors.Count); 
        }


        public Faker<SellerTransaction> GetFakerSellerTransaction()
        {
            return new Faker<SellerTransaction>()
                .RuleFor(b => b.Address, f => f.Address.StreetAddress())
                .RuleFor(b => b.City, f => f.Address.City())
                .RuleFor(b => b.State, f => f.Address.State())
                .RuleFor(b => b.ZipCode, f => f.Address.ZipCode())
                .RuleFor(b => b.Notes, f => f.Lorem.Paragraph());

        }
    }
}