using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class User_StatsUpdateDTO
    {
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
