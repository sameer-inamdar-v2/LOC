using MongoDB.Bson;
using Realms;
namespace LoanOffersCalculator.API.Data
{
    public class UserAnswers : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId UserAnswerId { get; set; } = ObjectId.GenerateNewId();

        [MapTo("userId")]
        [Required]
        public string UserId { get; set; }

        [MapTo("loanTypeId")]
        [Required]
        public string LoanTypeId { get; set; }

        [MapTo("questionId")]
        [Required]
        public string QuestionId { get; set; }

        [MapTo("answerId")]
        [Required]
        public string AnswerId { get; set; }

        [MapTo("createdDateTime")]
        public DateTimeOffset CreatedDateTime { get; set; }

        [MapTo("updatedDateTim")]
        public DateTimeOffset UpdatedDateTime { get; set; }
    }
}
