using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PotOfGreed.Cards;
using PotOfGreed.Cards.Behavior;
using PotOfGreed.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace PotOfGreed.Items.Cards
{
    public class ProxyCardItem : CardItem, ILinkedToCardDefinition
    {
        private const string UNDEFINED = "PROXY ITEM, SHOULD NOT EXIST";
        internal static Dictionary<int, CardDefinition> definitionsById;


        public ProxyCardItem() : base(UNDEFINED, "PROXY ITEM, SHOULD NOT EXIST")
        {
        }

        public ProxyCardItem(CardDefinition definition) :
            base(definition.NormalSpecifications.DisplayNames, definition.NormalSpecifications.Tooltips, 44, 64,
                rarity: definition.NormalSpecifications.Rarity, maxStack: definition.NormalSpecifications.MaxInInventory)
        {
            RealCard = true;
            Definition = definition;

            Type definitionType = Definition.GetType();

            AutoloadName = "ProxyCard." + Definition.UnlocalizedName;
            Texture = definitionType.NamespaceAsPath().Replace('\\', '/') + "/ItemSprite";
        }

        public override bool Autoload(ref string name) => RealCard;


        public override void SetDefaults()
        {
            base.SetDefaults();

            if (RealCard)
                if (!definitionsById.ContainsKey(item.type))
                    definitionsById.Add(item.type, Definition);
            if (!RealCard)
            {
                if (!definitionsById.ContainsKey(item.type))
                    throw new NullReferenceException("Tried creating a card without a corresponding definition.");

                Definition = definitionsById[item.type];
            }

            item.rare = Definition.NormalSpecifications.Rarity;

            item.consumable = Definition.NormalBehavior.UseBehavior.HasFlag(NormalCardUseBehavior.Consume);
            item.maxStack = Definition.NormalSpecifications.MaxInInventory;

            if (Definition.NormalBehavior.UseBehavior.HasFlag(NormalCardUseBehavior.Use))
            {
                item.useStyle = Definition.NormalBehavior.UseStyle;

                item.useTime = Definition.NormalBehavior.UseTime;
                item.useAnimation = Definition.NormalBehavior.UseAnimation;
            }

            item.accessory = Definition.NormalBehavior.UseBehavior.HasFlag(NormalCardUseBehavior.Equip);
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int index = tooltips.FindLastIndex(t => t.Name.StartsWith(TooltipLines.TOOLTIP_LINE_NAME));

            POGPlayer pogPlayer = POGPlayer.Get();

            int max = pogPlayer.NormalMaxCardUses(Definition);
            int remaining = pogPlayer.NormalCardRemainingUses(Definition);

            tooltips.Insert(index + 1, new TooltipLine(mod, "POG_Card_UsesLeft", $"{remaining} out of {max} uses left.")
            {
                overrideColor = remaining > 0 ? new Color(0, 255, 0) : Color.Red
            });
        }


        public override bool CanUseItem(Player player) => Definition.NormalBehavior.CanUseItem(POGPlayer.Get(player), Definition);

        public override bool UseItem(Player player)
        {
            POGPlayer pogPlayer = POGPlayer.Get(player);
            bool useItem = Definition.NormalBehavior.UseItem(pogPlayer, Definition);

            if (useItem)
                pogPlayer.NormalOnCardUsed(Definition);

            return useItem;
        }



        public bool RealCard { get; }

        public CardDefinition Definition { get; private set; }

        public string AutoloadName { get; }

        public override string Texture { get; }


        public override bool CloneNewInstances { get; } = true;
    }
}