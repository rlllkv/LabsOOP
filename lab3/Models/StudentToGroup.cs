using System.ComponentModel.DataAnnotations.Schema;

namespace BazaGRUD.Models
{
    public class StudentToGroup
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public Student? Student { get; set; }
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public Group? Group { get; set; }
    }
}
