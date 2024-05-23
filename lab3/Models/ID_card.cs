using System.ComponentModel.DataAnnotations.Schema;

namespace BazaGRUD.Models
{
    public class ID_card
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public Student? Student { get; set; }
    }
}
