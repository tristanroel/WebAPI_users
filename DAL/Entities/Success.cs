using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Success
    {
        public int Id { get; set; }    
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ScoreMax { get; set; }
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
