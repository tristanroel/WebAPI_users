using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Entities
{
    public class User
    {
        public User() { }
        public User(string alias, string email, string passwd)
        {
            Alias = alias;
            Email = email;
            Passwd = passwd;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[MaxLength(15)]
        public string? Alias { get; set; }

        //[Required]
        //[MaxLength(50)]
        //[EmailAddress]
        public string? Email { get; set; }

        //[MaxLength(50)]
        public string? AvatarUrl { get; set; }

        //[MaxLength(50)]
        public string? Country { get; set; }

        public string? Passwd { get; set; }

        public bool IsAdmin { get; set; }

        public int Credits { get; set; }

        public int Score { get; set; }
    }
}
