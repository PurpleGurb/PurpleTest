using System;

namespace OrangeBricks.Web.Controllers.Viewings.ViewModels
{
    public class ViewingViewModel
    {
        public int Id;
        public int PropertyId { get; set; }
        public DateTime When { get; set; }
        public string BuyerUserId { get; set; }
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        public string Status { get; set; }
    }
}