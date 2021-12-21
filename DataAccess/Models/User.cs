using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}