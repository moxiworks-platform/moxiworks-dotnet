using Xunit;
using static Xunit.Assert;
using Bogus;
using MoxiWorks.Platform;

namespace MoxiWorks.Test
{
    public class SellerTransactionFixture
    {
        [Fact]
        public void ValidateMoxiWorksContactIdOrPartnerContactId()
        {
            var fake = GetFakerSellerTransaction().Generate();
            fake.PartnerContactId = "foo";
            fake.MoxiWorksContactId = "bar";
            False(fake.Validate());
            Equal(1, fake.Errors.Count); 
        }

        [Fact]
        public void ValidateMlsBuyerTransactionContainsMlsNumber()
        {
            var fake = GetFakerSellerTransaction().Generate();
            fake.IsMlsTransaction = true;
            fake.MlsNumber = string.Empty;
            
            False(fake.Validate());
            Equal(1, fake.Errors.Count); 
        }

        [Fact]
        public void ValidateCommisionPercentageOrCommisionFlatFeeNotBoth()
        {
            var fake = GetFakerSellerTransaction().Generate();
            fake.CommissionPercentage = 0.10m;
            fake.CommissionFlatFee = 2000; 
            
            False(fake.Validate());
            True(fake.HasErrors);
            Equal(1, fake.Errors.Count);
             
        }
        
        [Fact]
        public void ValidateTargetPriceOrMinMaxPriceButNotBoth()
        {
            var fake = GetFakerSellerTransaction().Generate();
            fake.TargetPrice = 1;
            fake.MinPrice = 1;
            fake.MaxPrice = 1;
            
            False(fake.Validate());
            True(fake.HasErrors);
            Equal(1, fake.Errors.Count); 
        }


        private Faker<SellerTransaction> GetFakerSellerTransaction()
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