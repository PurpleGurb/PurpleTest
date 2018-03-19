using NUnit.Framework;
using NSubstitute;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Controllers.Property.Commands.Tests
{
    [TestFixture()]
    public class MakeOfferCommandHandlerTests
    {
        private MakeOfferCommandHandler _handler;
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _context.Offers.Returns(Substitute.For<IDbSet<Offer>>());
            _handler = new MakeOfferCommandHandler(_context);
            _context.Properties.Returns(Substitute.For<IDbSet<Models.Property>>());
        }


        [Test()]
        public void HandleShouldMakeOfferTest()
        {
            // Arrange
            var property = new Models.Property()
            {
                Id = 1
            };

            var command = new MakeOfferCommand()
            {
                PropertyId = 1
            };

            _context.Properties.Find(1).Returns(property);
            // Act
            _handler.Handle(command);

            // Assert
            _context.Properties.Received(1).Find(1);
            _context.Received(1).SaveChanges();
        }
    }
}