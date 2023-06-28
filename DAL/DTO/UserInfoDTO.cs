using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string? Alias { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Country { get; set; }
        public int Score { get; set; }
    }
}
