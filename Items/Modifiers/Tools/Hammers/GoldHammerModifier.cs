using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Modifiers.Tools.Hammers
{
    class GoldHammerModifier : Modifier
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Modifier");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(40);
            item.maxStack = 1;
            item.value = 1600;
            item.rare = ItemRarityID.White;

            item.hammer = 55;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
