using PotOfGreed.Players;
using Terraria.DataStructures;

namespace PotOfGreed.Commons.Hooking
{
    public interface IHookIntoPlayerPreHurt
    {
        bool OnPlayerPreHurt(POGPlayer player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource);
    }
}