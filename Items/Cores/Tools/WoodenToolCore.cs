using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Cores.Tools
{
    class WoodenToolCore : ToolCore
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Tool Core");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(50);
            item.rare = ItemRarityID.White;
            item.value = 0;
            item.maxStack = 1;

            item.autoReuse = true;
            item.useTime = 30;
            item.useAnimation = 35;
            item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 35);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
