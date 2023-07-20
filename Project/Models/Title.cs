using System.ComponentModel.DataAnnotations;

namespace Companies.Models
{
    public class Title
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }
    }
}
