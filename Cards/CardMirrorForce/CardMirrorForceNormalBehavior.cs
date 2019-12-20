using PotOfGreed.Cards.Behavior;
using PotOfGreed.Cards.Hooking;
using PotOfGreed.Items.Cards;
using PotOfGreed.Players;
using Terraria;
using Terraria.DataStructures;
using WebmilioCommons.Extensions;
using WebmilioCommons.Tinq;

namespace PotOfGreed.Cards.CardMirrorForce
{
    public sealed class CardMirrorForceNormalBehavior : NormalCardBehavior, ICardHookIntoPlayerPreHurt
    {
        public CardMirrorForceNormalBehavior() : base(NormalCardUseBehavior.None)
        {
        }


        public bool OnPlayerPreHurt(POGPlayer player, ProxyCardItem cardItem, CardDefinition definition, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            int dmg = damage;
            bool crt = crit;

            Main.npc.WhereActive(npc => !npc.townNPC).Do(npc => npc.StrikeNPC(dmg * 2, 0, 0, crt));

            damage = 0;

            cardItem.Consume();
            player.NormalOnCardUsed(definition);
            return true;
        }
    }
}