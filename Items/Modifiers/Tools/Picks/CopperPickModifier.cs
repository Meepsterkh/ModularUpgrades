
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Items.Modifiers.Tools.Picks
{
    class CopperPickModifier : Modifier
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Tool Modifier");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(40);
            item.maxStack = 1;
            item.value = 1000;
            item.rare = ItemRarityID.White;

            item.pick = 35;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var countdownTooltip = new TooltipLine(mod, "Material", $"Tool Modifier");
            countdownTooltip.overrideColor = Color.Yellow;
            tooltips.Add(countdownTooltip);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
