using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User_Stats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Stats_Id { get; set; }
        //public string? Alias { get; set; }
        public int LevelMax { get; set; }
        public int DeathNumber { get; set; }
        public int KillNumber { get; set; }
        public int BonusNumber { get; set; }
        public int WeaponNumber { get; set; }
        public int BulletDamage { get; set; }
        public int BossKill { get; set; }
        public int DragonKill { get; set; }
        public int SuccessRate { get; set; }
        public char Rank { get; set; }
    }
}
