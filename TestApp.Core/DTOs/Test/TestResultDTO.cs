namespace TestApp.Core.DTOs.Test
{
    public class TestResultDTO
    {
        public Guid Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public int Result { get; set; }
    }
}
