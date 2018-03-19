using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class BookViewingCommandHandlerTest
    {
        private BookViewingCommandHandler _handler;
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _handler = new BookViewingCommandHandler(_context);
            _context.Properties.Returns(Substitute.For<IDbSet<Models.Property>>());
            _context.Viewings.Returns(Substitute.For<IDbSet<Models.Viewing>>());
        }

        [Test]
        public void HandleShouldAddViewing()
        {
            // Arrange
            var property = new Models.Property()
            {
                Id = 1
            };

            _context.Properties.Find(1).Returns(property);

            var command = new BookViewingCommand();

            DateTime appointment = DateTime.Now;
            command.When = appointment;
            command.PropertyId = 1;
            command.BuyerUserId = "1";

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Is<Models.Viewing>(x => x.When == appointment));
        }
    }
}
