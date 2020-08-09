
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Modifiers.Tools.Picks
{
    class CrimtanePickModifier : Modifier
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deathbringer Modifier");
            Tooltip.SetDefault("Tool Modifier");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(40);
            item.maxStack = 1;
            item.value = 3600;
            item.rare = ItemRarityID.Blue;

            item.pick = 70;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12); 
            recipe.AddIngredient(ItemID.TissueSample, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
