using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Core.Enteties.Test
{
    public class UsersTest
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Test")]
        public Guid TestId { get; set; }
        public bool isCompleted { get; set; }
        public int Result { get; set; }
    }
}
