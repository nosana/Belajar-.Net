using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Employee")]
        
        public int Id { get; set; }
        public string Password { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        [JsonIgnore]
        public Role? Role { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }



    }
}

