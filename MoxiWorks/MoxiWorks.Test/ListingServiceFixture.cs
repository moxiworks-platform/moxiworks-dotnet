using System;
using System.Collections.Generic;
using System.Dynamic;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;
using Xunit;

namespace MoxiWorks.Test
{
    public class ListingServiceFixture
    {
        [Fact]
        public void ShouldReturnAListing()
        {
            var listingJson = StubDataLoader.LoadJsonFile("Listing.json");

            IListingService service = new ListingService(new MoxiWorksClient(new StubContextClient(listingJson)));

            var response = service.GetListingAsync("some_moxiworks_listing_id", "some_moxiworks_company_id").Result;
            Assert.IsType<Listing>(response.Item);
            Assert.True(response.Item.LotSizeAcres.HasValue);
            Assert.True(response.Item.BathroomsFull.HasValue);
            Assert.True(response.Item.BathroomsHalf.HasValue);
            Assert.False(response.Item.BathroomsOneQuarter.HasValue);
            Assert.False(response.Item.BathroomsPartial.HasValue);
            Assert.False(response.Item.BathroomsThreeQuarter.HasValue);
            Assert.True(response.Item.BathroomsTotalInteger.HasValue);
            Assert.True(response.Item.BathroomsTotal.HasValue);
            Assert.True(response.Item.BedroomsTotal.HasValue);
            Assert.NotNull(response.Item.PublicTitle);
            Assert.NotNull(response.Item.PublicRemarks);
            Assert.True(response.Item.ModificationTimestamp.HasValue);
            Assert.True(response.Item.InternetAddressDisplayYN.HasValue);
            Assert.True(response.Item.DaysOnMarket.HasValue);
            Assert.True(response.Item.ListingContractDate.HasValue);
            Assert.True(response.Item.CreatedDate.HasValue);
            Assert.NotNull(response.Item.ElementarySchool);
            Assert.True(response.Item.GarageSpaces.HasValue);
            Assert.True(response.Item.WaterfrontYN.HasValue);
            Assert.NotNull(response.Item.HighSchool);
            Assert.False(response.Item.AssociationFee.HasValue);
            Assert.NotNull(response.Item.ListOfficeName);
            Assert.True(response.Item.ListPrice.HasValue);
            Assert.NotNull(response.Item.ListingID);
            Assert.NotNull(response.Item.ListAgentFullName);
            Assert.NotNull(response.Item.ListAgentUUID);
            Assert.NotNull(response.Item.ListAgentOfficeID);
            Assert.NotNull(response.Item.ListAgentMoxiWorksOfficeID);
            Assert.NotNull(response.Item.SecondaryListAgentFullName);
            Assert.NotNull(response.Item.SecondaryListAgentUUID);
            Assert.Null(response.Item.SchoolDistrict);
            Assert.NotNull(response.Item.Address);
            Assert.Null(response.Item.Address2);
            Assert.NotNull(response.Item.City);
            Assert.NotNull(response.Item.CountyOrParish);
            Assert.NotNull(response.Item.Latitude);
            Assert.NotNull(response.Item.Longitude);
            Assert.NotNull(response.Item.StateOrProvince);
            Assert.NotNull(response.Item.PostalCode);
            Assert.Null(response.Item.Community);
            Assert.False(response.Item.LotSizeSquareFeet.HasValue);
            Assert.True(response.Item.InternetEntireListingDisplayYN.HasValue);
            Assert.NotNull(response.Item.MiddleOrJuniorSchool);
            Assert.NotNull(response.Item.ListOfficeAOR);
            Assert.NotNull(response.Item.ListOfficeAORArea);
            Assert.True(response.Item.PoolYN.HasValue);
            Assert.NotNull(response.Item.PropertyType);
            Assert.True(response.Item.TaxAnnualAmount.HasValue);
            Assert.True(response.Item.TaxYear.HasValue);
            Assert.True(response.Item.SingleStory.HasValue);
            Assert.True(response.Item.LivingArea.HasValue);
            Assert.True(response.Item.ViewYN.HasValue);
            Assert.True(response.Item.YearBuilt.HasValue);
            Assert.True(response.Item.OnMarket.HasValue);
            Assert.NotNull(response.Item.Status);
            Assert.NotNull(response.Item.MoxiWorksListingId);
            Assert.True(response.Item.AgentCreatedListing.HasValue);
            Assert.NotNull(response.Item.VirtualTourURL);
            Assert.NotNull(response.Item.ListingURL);
            Assert.IsType<List<PropertyFeatures>>(response.Item.PropertyFeatures);
            Assert.True(response.Item.PropertyFeatures.Count == 4);
            Assert.IsType<List<CompanyListingAttribute>>(response.Item.CompanyListingAttributes);
            Assert.True(response.Item.CompanyListingAttributes.Count == 2);
            Assert.IsType<List<OpenHouse>>(response.Item.OpenHouse);
            Assert.True(response.Item.OpenHouse.Count == 1);
            Assert.IsType<List<ListingImage>>(response.Item.ListingImages);
            Assert.True(response.Item.ListingImages.Count == 1);
            Assert.IsType<ExpandoObject>(response.Item.SharedPartnerData);
            Assert.NotNull(response.Item.SharedPartnerData);
            Assert.True(response.Item.SharedPartnerData.foo == 1);
            foreach (var property in response.Item.SharedPartnerData)
            {
                Assert.NotNull(property.Key);
                Assert.NotNull(property.Value);
                if (property.Value is ExpandoObject propertyValue)
                {
                    foreach (var subproperty in propertyValue)
                    {
                        Assert.NotNull(subproperty.Key);
                        Assert.NotNull(subproperty.Value);
                        //you could keep going or handle the data differently if you wish
                    }
                }
            }
        }

        [Fact]
        public void ShouldReturnACollectionOfListings()
        {
            var listingJson = StubDataLoader.LoadJsonFile("listings.json");

            IListingService service = new ListingService(new MoxiWorksClient(new StubContextClient(listingJson)));

            var response = service.GetListingsUpdatedSinceAsync("moxi_works_company_id", AgentIdType.AgentUuid,"some_uuid",DateTime.Now).Result;
            Assert.IsType<ListingResults>(response.Item);
            Assert.True(response.Item.Listings.Count == 1);
        }

        [Fact]
        public void ShouldUpdateListingInfo()
        {
            var listingJson = StubDataLoader.LoadJsonFile("listings.json");

            IListingService service = new ListingService(new MoxiWorksClient(new StubContextClient(listingJson)));
            var update = new ListingUpdate
            {
                VirtualTourURL = "http://www.example.com"
            };
            
            var response = service.UpdateListingDataAsync(update).Result;
            Assert.IsType<ListingResults>(response.Item);
            Assert.True(response.Item.Listings.Count == 1);
        }
          
    }
}