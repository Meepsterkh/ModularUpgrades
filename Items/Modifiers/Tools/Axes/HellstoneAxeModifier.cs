using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Modifiers.Tools.Axes
{
    class HellstoneAxeModifier : Modifier
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Axe Modifier");
            Tooltip.SetDefault("Tool Modifier");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(40);
            item.maxStack = 1;
            item.value = 5400;
            item.rare = ItemRarityID.Orange;

            item.axe = 70;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
