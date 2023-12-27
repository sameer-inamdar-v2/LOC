using MongoDB.Bson;
using Realms;
namespace LoanOffersCalculator.API.Data
{
    public class LoanType : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId LoanTypeId { get; set; } = ObjectId.GenerateNewId();

        [MapTo("loanTypeDesc")]
        [Required]
        public string LoanTypeDesc { get; set; }
    }
}
