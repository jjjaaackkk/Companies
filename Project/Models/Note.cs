using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Companies.Models
{
    public class Note
    {
        public int Id { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int InvoidId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [MaxLength(150)]
        public string StoreCity { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
