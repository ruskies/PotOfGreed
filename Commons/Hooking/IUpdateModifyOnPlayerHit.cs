using PotOfGreed.Players;

namespace PotOfGreed.Commons.Hooking
{
    public interface IUpdateModifyOnPlayerHit
    {
        void ModifyOnPlayerHitByAnything(POGPlayer player, ref int damage, ref bool crit);
    }
}