using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Core.Enteties.Test
{
    public class TestQuestion
    {
        public Guid Id { get; set; }
        [ForeignKey("Test")]
        public Guid TestId { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Options' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<TestQuestionOption> Options { get; set; } = new List<TestQuestionOption>();
#pragma warning restore CS8618 // Non-nullable property 'Options' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
