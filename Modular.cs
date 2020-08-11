using Microsoft.Xna.Framework;
using Modular.Items;
using Modular.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace Modular
{
	public class Modular : Mod
	{
		public UserInterface ModifierAdditionInteraface;
		public UserInterface ScrapperInterface;


		public override void Load()
        {
			if(!Main.dedServ)
			{
				ModifierAdditionInteraface = new UserInterface();
				ScrapperInterface = new UserInterface();
			}
		}

		/*public UserInterface GetInterface()
        {
			return ModifierAdditionInteraface;
        }*/

		public override void UpdateUI(GameTime gameTime)
		{
			if(!Main.gameMenu)
			{
				ModifierAdditionInteraface?.Update(gameTime);
				ScrapperInterface?.Update(gameTime);
            }
		}

		//Add UI Layer
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{

			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));

			if (mouseTextIndex != -1)
			{

				layers.Insert(
					mouseTextIndex,
					new LegacyGameInterfaceLayer(
						"ModularClass: Modifier Menu",
							delegate {
								ModifierAdditionInteraface.Draw(Main.spriteBatch, new GameTime());
								return true;
							},
						InterfaceScaleType.UI
					)
				);

				layers.Insert(
					mouseTextIndex,
					new LegacyGameInterfaceLayer(
						"ModularClass: Modifier Menu",
							delegate {
								ScrapperInterface.Draw(Main.spriteBatch, new GameTime());
								return true;
							},
						InterfaceScaleType.UI
					)
				);
			}

		}

		/*private bool DrawSomethingUI()
		{
			// it will only draw if the player is not on the main menu
			if (!Main.gameMenu)
			{
				MyInterface.Draw(Main.spriteBatch, new GameTime());
			}
			return true;
		}*/
	}
}