
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Modifiers.Tools.Picks
{
    class HellstonePickModifier : Modifier
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Tool Modifier");
        }
        public override void SetDefaults()
        {
            item.SetNameOverride("Molten Modifier");
            item.Size = new Vector2(40);
            item.maxStack = 1;
            item.value = 100;
            item.rare = ItemRarityID.White;

            item.pick = 100;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
