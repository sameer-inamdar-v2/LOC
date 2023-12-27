using MongoDB.Bson;
using Realms;
namespace LoanOffersCalculator.API.Data
{
    public class Questions : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId QuestionId { get; set; } = ObjectId.GenerateNewId();

        [MapTo("loanTypeId")]
        [Required]
        public string LoanTypeId { get; set; }

        [MapTo("questionText")]
        [Required]
        public string QuestionText { get; set; }

        [MapTo("description")]
        public string Description { get; set; }
    }
}
