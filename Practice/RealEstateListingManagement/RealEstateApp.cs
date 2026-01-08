using System;
using System.Collections.Generic;

namespace RealEstateListingManagement;

public class RealEstateApp
{
    private List<RealEstateListing> listings = new List<RealEstateListing>();

    //AddListing
    public void AddListing(RealEstateListing listing)
    {
        listings.Add(listing);
    }

    //RemoveListing
    public void RemoveListing(int listingID)
    {
        RealEstateListing found = null;

        foreach(var item in listings)
        {
            if(item.ID == listingID)
            {
                found = item;
                break;
            }
        }

        if(found != null)
        {
            listings.Remove(found);
        }
    }

    //UpdateListing
    public void UpdateListing(RealEstateListing Updatedlisting)
    {
        foreach(var item in listings)
        {
            if(item.ID == Updatedlisting.ID)
            {
                item.Title = Updatedlisting.Title;
                item.Description = Updatedlisting.Description;
                item.Price = Updatedlisting.Price;
                item.Location = Updatedlisting.Location;
                break;
            }
        }
    }

    //GetListings
    public List<RealEstateListing> GetListings()
    {
        return listings;
    }

    //GetListings by Location
    public List<RealEstateListing> GetListingsByLocation(string Location)
    {
        List<RealEstateListing> loc = new List<RealEstateListing>();

        foreach(var item in listings)
        {
            if(item.Location.Equals(Location, StringComparison.OrdinalIgnoreCase))
            {
                loc.Add(item);
            }
        }

        return loc;
    }

    //GetListings By PriceRange
    public List<RealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        List<RealEstateListing> result = new List<RealEstateListing>();

        foreach(var items in listings)
        {
            if(items.Price >= minPrice && items.Price <= maxPrice)
            {
                result.Add(items);
            }
        }
        return result;
    }
}