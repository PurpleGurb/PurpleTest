using System;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookViewingCommand
    {
        public int PropertyId { get; set; }

        public string BuyerUserId { get; set; }

        public DateTime When { get; set; }
    }
}