using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Core.Enteties.Test
{
    public class TestQuestionOption
    {
        public Guid Id { get; set; }
        [ForeignKey("Test")]
        public Guid TestId { get; set; }
        [ForeignKey("TestQuestion")]
        public Guid TestQuestionId { get; set; }
        public string Description { get; set; }
        public bool IsRight { get; set; }
    }
}
