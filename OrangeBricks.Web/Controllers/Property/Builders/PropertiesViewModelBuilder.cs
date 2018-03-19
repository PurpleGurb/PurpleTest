using System;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public PropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public PropertiesViewModel Build(PropertiesQuery query)
        {
            var properties = _context.Properties
                .Where(p => p.IsListedForSale).Include(p => p.Offers);

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                properties = properties.Where(x => x.StreetName.Contains(query.Search) 
                    || x.Description.Contains(query.Search)).Include(p => p.Offers);
            }

            return new PropertiesViewModel
            {
                Properties = properties
                    .ToList()
                    .Select(p => new PropertyViewModel
                    {
                        Id = p.Id,
                        StreetName = p.StreetName,
                        Description = p.Description,
                        NumberOfBedrooms = p.NumberOfBedrooms,
                        PropertyType = p.PropertyType,
                        UnderOffer = p.Offers != null && p.Offers.Count(o => o.Status == OfferStatus.Pending) > 0
                    })
                    .ToList(),
                Search = query.Search
            };
        }
    }
}