using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Dtos.OfferDiscountDtos
{
    public class ResultOfferDiscountDto
    {
        public string OfferDiscountId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImgUrl { get; set; }
        public string ButtonTitle { get; set; }
    }
}
