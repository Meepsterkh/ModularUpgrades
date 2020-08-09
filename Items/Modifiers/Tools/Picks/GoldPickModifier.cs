
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Modifiers.Tools.Picks
{
    class GoldPickModifier : Modifier
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Tool Modifier");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(40);
            item.maxStack = 1;
            item.value = 2000;
            item.rare = ItemRarityID.White;

            item.pick = 55;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
