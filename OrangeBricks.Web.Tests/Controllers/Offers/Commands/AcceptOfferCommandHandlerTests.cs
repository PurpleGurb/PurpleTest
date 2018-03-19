using NUnit.Framework;
using NSubstitute;
using OrangeBricks.Web.Controllers.Offers.Commands;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Controllers.Offers.Commands.Tests
{
    [TestFixture()]
    public class AcceptOfferCommandHandlerTests
    {
        private AcceptOfferCommandHandler _handler;
        private IOrangeBricksContext _context;
        private IDbSet<Offer> _offers;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _context.Offers.Returns(Substitute.For<IDbSet<Offer>>());
            _handler = new AcceptOfferCommandHandler(_context);
            _offers = Substitute.For<IDbSet<Offer>>();
            _context.Offers.Returns(_offers);

        }


        [Test()]
        public void HandleShouldAddOfferAcceptanceTest()
        {
            
            // Arrange
            var command = new AcceptOfferCommand()
            {
                OfferId = 1
            };

            var offer = new Offer
            {
                Id = 1,
                Status = OfferStatus.Pending

            };

            _offers.Find(1).Returns(offer);

            // Act
            _handler.Handle(command);

            // Assert
            _context.Offers.Received(1).Find(1);
            _context.Received(1).SaveChanges();
            Assert.True(offer.Status == OfferStatus.Accepted);
        }
    }
}