using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Modular.Items.Placeable
{
    class MeteoriteScrapForge : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Used to Combine Cores and Modifiers");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 10000;
			item.createTile = TileType<Tiles.MeteoriteScrapForge>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 50);
			recipe.AddIngredient(ItemType<PlexiyBlock>(), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
