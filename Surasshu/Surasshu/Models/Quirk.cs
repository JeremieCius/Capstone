using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Surasshu.Models
{
    public class Quirk
    {
        [Required]
        public int QuirkId { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string QuirkName { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string QuirkDescription { get; set; }

        public int? QuirkCost { get; set; }

        public Quirk()
        {

        }

        public Quirk(int quirkId, string quirkName, string quirkDescription, int? quirkCost)
        {
            QuirkId = quirkId;
            QuirkName = quirkName;
            QuirkDescription = quirkDescription;
            QuirkCost = quirkCost;
        }
    }
}
