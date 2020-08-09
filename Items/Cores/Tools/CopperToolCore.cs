using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Cores.Tools
{
    class CopperToolCore : ToolCore
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Tool Core");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(50);
            item.rare = ItemRarityID.White;
            item.value = 80;
            item.maxStack = 1;

            item.autoReuse = true;
            item.useTime = 23;
            item.useAnimation = 32;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 15);
            recipe.AddRecipeGroup("Wood", 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
