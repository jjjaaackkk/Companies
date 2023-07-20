using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Companies.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Position Company { get; set; }


        [MaxLength(100)]
        public string First { get; set; }

        [MaxLength(100)]
        public string Last { get; set; }

        [ForeignKey("Title")]
        public int TitleId { get; set; }
        public virtual Title Title { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}
