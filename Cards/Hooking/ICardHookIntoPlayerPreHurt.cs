using PotOfGreed.Items.Cards;
using PotOfGreed.Players;
using Terraria.DataStructures;

namespace PotOfGreed.Cards.Hooking
{
    public interface ICardHookIntoPlayerPreHurt
    {
        bool OnPlayerPreHurt(POGPlayer player, ProxyCardItem cardItem, CardDefinition definition, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource);
    }
}