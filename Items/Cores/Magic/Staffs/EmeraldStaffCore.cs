using Microsoft.Xna.Framework;
using Modular.Projectiles;
using Terraria;
using Terraria.ID;

namespace Modular.Items.Cores.Magic.Staffs
{
    class EmeraldStaffCore : MagicCore
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingOut;   //The way your Weapon will be used, 1 is the regular sword swing for example
            item.noMelee = true; //so the item's animation doesn't do damage

            item.magic = true;
            item.damage = 19;
            item.width = 50;
            item.height = 50;
            item.useTime = 1;   //How fast the Weapon is used.
            item.useAnimation = 20;     //How long the Weapon is used for.
            item.knockBack = 1.0f;
            item.UseSound = SoundID.Item20;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shoot = mod.ProjectileType("EmeraldStaffProj");
            item.shootSpeed = 16f;
            item.autoReuse = true;
        }
    }
}
