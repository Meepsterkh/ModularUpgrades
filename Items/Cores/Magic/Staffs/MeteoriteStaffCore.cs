using Microsoft.Xna.Framework;
using Modular.Projectiles;
using Terraria;
using Terraria.ID;

namespace Modular.Items.Cores.Magic.Staffs
{
    class MeteoriteStaffCore : MagicCore
    {
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingOut;   //The way your Weapon will be used, 1 is the regular sword swing for example
            item.noMelee = true; //so the item's animation doesn't do damage

            item.magic = true;
            item.damage = 19;
            item.width = 50;
            item.height = 50;
            item.useTime = 3;   //How fast the Weapon is used.
            item.useAnimation = 20;     //How long the Weapon is used for.
            item.knockBack = 1.0f;
            item.UseSound = SoundID.Item34;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.shootSpeed = 4.5f; //This defines the projectile speed when shoot , for flamethrower this make how far the flames can go

            MainMagicProj moddedProj = new MainMagicProj();
            moddedProj.SetColor(new Color(new Vector3(255, 40, 0)));
            moddedProj.SetLighting(100f, 15.7f, 0f);
            item.shoot = moddedProj.projectile.type;
        }
    }
}
