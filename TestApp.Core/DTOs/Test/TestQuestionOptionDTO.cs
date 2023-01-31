namespace TestApp.Core.DTOs.Test
{
    public class TestQuestionOptionDTO
    {
        public Guid Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
