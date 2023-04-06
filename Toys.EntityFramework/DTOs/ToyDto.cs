namespace Toys.EntityFramework.DTOs
{
    public class ToyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public bool IsValid { get; set; }
    }
}
