using Terraria;
using Terraria.ID;
using WebmilioCommons.Extensions;

namespace PotOfGreed.Items.Cards
{
    public sealed class CardItemPotOfGreed : CardItem
    {
        public CardItemPotOfGreed() : base("Pot Of Greed", "Draw 2 cards.", value: Item.buyPrice(gold: 1), rarity: ItemRarityID.Green)
        {
        }


        public override bool UseItem(Player player)
        {
            for (int i = 0; i < 2; i++)
            {
                int rand = Main.rand.Next(CardItemLoader.Instance.FirstIndex, CardItemLoader.Instance.NextIndex);

                Item randomCard = new Item();
                randomCard.SetDefaults(CardItemLoader.Instance.GetGeneric(rand));

                player.QuickSpawnItem(randomCard);
            }

            return true;
        }
    }
}