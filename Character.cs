using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampire_Builder
{
    internal class Character
    {
        String strStartWeapon;
        String strName;
        int intStartingLevel;
        int intMaxHealth;
        int intArmor;
        double dblRecovery;
        int intMoveSpeed;
        int intMight;
        int intArea;
        int intSpeed;
        int intDuration;
        int intAmount;
        int intCooldown;
        int intLuck;
        int intGrowth;
        int intGreed;
        int intCurse;
        int intMagnet;
        int intRevival;
        int intReroll;
        int intSkip;

        public Character(string strStartWeapon, string strName, int intStartingLevel, int intMaxHealth, int intArmor, double dblRecovery, int intMoveSpeed, int intMight, int intArea, int intSpeed, int intDuration, int intAmount, int intCooldown, int intLuck, int intGrowth, int intGreed, int intCurse, int intMagnet, int intRevival, int intReroll, int intSkip)
        {
            this.strStartWeapon = strStartWeapon;
            this.strName = strName;
            this.intStartingLevel = intStartingLevel;
            this.intMaxHealth = intMaxHealth;
            this.intArmor = intArmor;
            this.dblRecovery = dblRecovery;
            this.intMoveSpeed = intMoveSpeed;
            this.intMight = intMight;
            this.intArea = intArea;
            this.intSpeed = intSpeed;
            this.intDuration = intDuration;
            this.intAmount = intAmount;
            this.intCooldown = intCooldown;
            this.intLuck = intLuck;
            this.intGrowth = intGrowth;
            this.intGreed = intGreed;
            this.intCurse = intCurse;
            this.intMagnet = intMagnet;
            this.intRevival = intRevival;
            this.intReroll = intReroll;
            this.intSkip = intSkip;
        }
    }
}