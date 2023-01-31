namespace TestApp.Core.DTOs.Test
{
    public class TestQuestionDTO
    {
#pragma warning disable CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Options' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<TestQuestionOptionDTO> Options { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Options' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
