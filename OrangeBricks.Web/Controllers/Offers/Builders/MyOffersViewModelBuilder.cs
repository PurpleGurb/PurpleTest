using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public OffersOnPropertiesViewModel Build(string buyerUserId)
        {
            var property = _context.Properties.Where(p => p.Offers.Any(o => o.BuyerUserId == buyerUserId));


            return new OffersOnPropertiesViewModel
            {
                Properties = property.Select(p => new OffersOnPropertyViewModel()
                {
                     HasOffers = true,
                     Offers = p.Offers.Select(o => new OfferViewModel()
                     {
                         Amount = o.Amount,
                         CreatedAt = o.CreatedAt,
                         Id = o.Id,
                         IsPending = o.Status == OfferStatus.Pending,
                         Status = o.Status.ToString()
                     }),
                     NumberOfBedrooms = p.NumberOfBedrooms,
                     PropertyId = p.Id,
                     PropertyType = p.PropertyType,
                     StreetName = p.StreetName
                }
                )
            };
        }
    }
}