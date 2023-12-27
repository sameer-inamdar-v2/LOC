using MongoDB.Bson;
using Realms;
namespace LoanOffersCalculator.API.Data
{
    public class Lenders : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId LenderId { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        [Required]
        public string Name { get; set; }

        [MapTo("logoUrl")]
        [Required]
        public string LogoUrl { get; set; }

        [MapTo("phoneNumber")]
        public string PhoneNumber { get; set; }

        [MapTo("destinationUrl")]
        public string DestinationUrl { get; set; }

        [MapTo("markettingBullets")]
        public string MarkettingBullets { get; set; }
    }
}
