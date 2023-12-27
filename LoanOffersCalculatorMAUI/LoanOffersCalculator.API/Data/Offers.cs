using MongoDB.Bson;
using Realms;
namespace LoanOffersCalculator.API.Data
{
    public class Offers : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId OfferId { get; set; } = ObjectId.GenerateNewId();

        [MapTo("loanTypeId")]
        [Required]
        public string LoanTypeId { get; set; }

        [MapTo("lenderId")]
        [Required]
        public string LenderId { get; set; }

        [MapTo("userAnswerId")]
        [Required]
        public string UserAnswerId { get; set; }
    }
}
