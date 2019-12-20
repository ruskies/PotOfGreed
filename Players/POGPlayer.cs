using System;
using PotOfGreed.Cards;
using PotOfGreed.Commons;
using PotOfGreed.Items.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PotOfGreed.Cards.Hooking;
using PotOfGreed.Commons.Hooking;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using WebmilioCommons.Extensions;

namespace PotOfGreed.Players
{
    public sealed class POGPlayer : ModPlayer
    {
        private const string
            LIFETIMECARDS_TAG = "LifetimeCards",
            CURRENTCARDS_TAG = "CurrentCards";

        private Dictionary<CardDefinition, int> _lifetimeCardsUsed;


        public static POGPlayer Get() => Get(Main.LocalPlayer);
        public static POGPlayer Get(Player player) => player.GetModPlayer<POGPlayer>();


        public void ResetCardsUsed() => CurrentCardsUsed.Clear();

        public int NormalMaxCardUses(CardDefinition definition) => definition.NormalSpecifications.MaxUses;

        public int NormalCardRemainingUses(CardDefinition definition) => Math.Max(NormalMaxCardUses(definition) - this[definition], 0);

        public bool NormalCanUseCard(CardDefinition definition) => !CurrentCardsUsed.ContainsKey(definition) || CurrentCardsUsed[definition] < NormalMaxCardUses(definition);

        public void NormalOnCardUsed(CardDefinition definition)
        {
            if (!_lifetimeCardsUsed.ContainsKey(definition))
                _lifetimeCardsUsed.Add(definition, 0);

            if (!CurrentCardsUsed.ContainsKey(definition))
                CurrentCardsUsed.Add(definition, 0);

            _lifetimeCardsUsed[definition]++;
            CurrentCardsUsed[definition]++;
        }


        #region Hooks

        public override void Initialize()
        {
            _lifetimeCardsUsed = new Dictionary<CardDefinition, int>();
            CurrentCardsUsed = new Dictionary<CardDefinition, int>();
        }

        public override void Load(TagCompound tag)
        {
            foreach (KeyValuePair<string, object> card in tag.GetCompound(LIFETIMECARDS_TAG))
                _lifetimeCardsUsed.Add(CardDefinitionLoader.Instance.GetGeneric(card.Key), int.Parse(card.Value.ToString()));

            foreach (KeyValuePair<string, object> card in tag.GetCompound(CURRENTCARDS_TAG))
                CurrentCardsUsed.Add(CardDefinitionLoader.Instance.GetGeneric(card.Key), int.Parse(card.Value.ToString()));
        }


        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {

            foreach (ProxyCardItem card in player.GetItemsByType<ProxyCardItem>(inventory: true, unique: true, condition: i => i.favorited))
                if (NormalCanUseCard(card.Definition) && card.Definition.NormalBehavior is ICardHookIntoPlayerPreHurt hook)
                    if (!hook.OnPlayerPreHurt(this, card, card.Definition, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource))
                        return false;

            return true;
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit) => OnHitByAnything(damage, crit);

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit) => ModifyHitByAnything(ref damage, ref crit);

        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit) => ModifyHitByAnything(ref damage, ref crit);

        private void ModifyHitByAnything(ref int damage, ref bool crit)
        {
            foreach (IUpdateModifyOnPlayerHit i in player.GetItemsByType<IUpdateModifyOnPlayerHit>(inventory: true))
                i.ModifyOnPlayerHitByAnything(this, ref damage, ref crit);
        }

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit) => OnHitByAnything(damage, crit);

        private void OnHitByAnything(int damage, bool crit)
        {

        }

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();
            TagCompound lifetimeTag = new TagCompound();
            TagCompound currentTag = new TagCompound();

            foreach (KeyValuePair<CardDefinition, int> card in _lifetimeCardsUsed)
                lifetimeTag.Add(card.Key.UnlocalizedName, card.Value);

            tag.Add(LIFETIMECARDS_TAG, lifetimeTag);

            foreach (KeyValuePair<CardDefinition, int> card in CurrentCardsUsed)
                currentTag.Add(card.Key.UnlocalizedName, card.Value);

            tag.Add(CURRENTCARDS_TAG, currentTag);
            return tag;
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item potOfGreed = new Item();
            potOfGreed.SetDefaults(ModContent.ItemType<CardItemPotOfGreed>());
            potOfGreed.stack = 1;

            items.Add(potOfGreed);
        }

        #endregion


        public Dictionary<CardDefinition, int> CurrentCardsUsed { get; private set; }

        public ReadOnlyDictionary<CardDefinition, int> AllTimeCardsUsed => new ReadOnlyDictionary<CardDefinition, int>(_lifetimeCardsUsed);


        public int this[CardDefinition definition] => CurrentCardsUsed.ContainsKey(definition) ? CurrentCardsUsed[definition] : 0;
    }
}