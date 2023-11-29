namespace DTO
{
    public class UserDto
    {
        public string Password { get; set; } = null!;


        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string LastName { get; set; } = null!;

        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? OrderSum { get; set; }
    }
}