﻿using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Modular.Items.Placeable
{
    class WoodenScrapForge : ModItem
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
			item.value = 1000;
			item.createTile = TileType<Tiles.WoodenScrapForge>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Acorn, 10);
			recipe.AddRecipeGroup("Wood", 100);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
