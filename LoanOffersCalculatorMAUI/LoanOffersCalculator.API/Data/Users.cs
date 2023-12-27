using MongoDB.Bson;
using Realms;
namespace LoanOffersCalculator.API.Data
{
    public class Users : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId UsersId { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        [Required]
        public string Name { get; set; }

        [MapTo("email")]
        [Required]
        public string Email { get; set; }

        [MapTo("loanTypeId")]
        [Required]
        public string LoanTypeId { get; set; }

        [MapTo("createdDateTime")]
        public DateTimeOffset CreatedDateTime { get; set; }

        [MapTo("updatedDateTim")]
        public DateTimeOffset UpdatedDateTime { get; set; }
    }
}
