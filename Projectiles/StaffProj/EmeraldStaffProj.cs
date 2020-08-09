using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Modular.Items.Cores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular.Projectiles.StaffProj
{
    public class EmeraldStaffProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 100;
           //  projectile.extraUpdates = 3;
        }
        private int num = 0;
        public override void AI()
        {
            ChangeProperties();

            Lighting.AddLight(projectile.Center,
               ((255 - projectile.alpha) * 1.14f) / 255f,  // R
               ((255 - projectile.alpha) * 1.84f) / 255f,  // G
               ((255 - projectile.alpha) * 1.71f) / 255f); // B
        
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 12f)  //this defines where the flames starts
            {
                if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 61 , projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, new Color(new Vector3(80, 200, 120)), 3.75f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    // int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.PinkFlame, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, new Color(new Vector3(80, 200, 120)), 1.5f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }
        private bool played = false;
        private void ChangeProperties()
        {
            if (!played)
            {
                Item tempItem = Main.LocalPlayer.inventory[Main.LocalPlayer.selectedItem];
                MagicCore core = (MagicCore)tempItem.modItem;

                if (core != null)
                {
                    if (core.penetrate != 0)
                    {
                        projectile.penetrate = core.penetrate;
                    }
                    if (core.time != 0)
                    {
                        // Main.NewText("Old Time Left: " + projectile.timeLeft + "\nNew Time Left: " + core.time);
                        projectile.timeLeft = core.time;
                        // Main.NewText("Changed: " + projectile.timeLeft);
                    }
                    if (core.coldDamage)
                    {
                        projectile.coldDamage = core.coldDamage;
                    }
                }
                played = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}