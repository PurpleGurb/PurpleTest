using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookViewingCommand command)
        {

            var viewing = new Viewing
            {
                BuyerId = command.BuyerUserId,
                PropertyId = command.PropertyId,
                When = command.When
            };

            _context.Viewings.Add(viewing);

            _context.SaveChanges();
        }
    }
}