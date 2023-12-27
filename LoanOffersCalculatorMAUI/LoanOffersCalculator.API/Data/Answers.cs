using MongoDB.Bson;
using Realms;
namespace LoanOffersCalculator.API.Data
{
    public class Answers : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId AnswerId { get; set; } = ObjectId.GenerateNewId();

        [MapTo("questionId")]
        public string QuestionId { get; set; }

        [MapTo("answerText")]
        public string AnswerText { get; set; }

        [MapTo("answerImage")]
        public string AnswerImage { get; set; }

    }
}
