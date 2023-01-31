namespace TestApp.Core.DTOs.Test
{
    public class TestCompleteDTO
    {
        public Guid Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'UserId' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string UserId { get; set; } = "";
#pragma warning restore CS8618 // Non-nullable property 'UserId' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Answers' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<Guid> Answers { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Answers' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
