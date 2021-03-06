﻿using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using Modular.Items.Cores;
using static Terraria.ModLoader.ModContent;
using Modular.NPCs;
using Terraria.UI.Chat;

namespace Modular.UI
{
    class ScrapperUI : UIState
    {
        private UIItemSlot coreItemSlot;
        const int MainLeft = 20;
        const int MainTop = 260;

        /*Left = { Pixels = 67 },
          Top = { Pixels = 430 }*/
        public override void OnInitialize()
        {
            coreItemSlot = new UIItemSlot(ItemSlot.Context.BankItem, .85f)
            {
                Left = { Pixels = MainLeft },
                Top = { Pixels = MainTop }
            };
            coreItemSlot.Activate();
            Append(coreItemSlot);
        }

        public override void OnDeactivate()
        {
            if(!coreItemSlot.item.IsAir)
            {
                Main.LocalPlayer.QuickSpawnClonedItem(coreItemSlot.item, coreItemSlot.item.stack);
                coreItemSlot.item.TurnToAir();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // talkNPC is the index of the NPC the player is currently talking to. By checking talkNPC, we can tell when the player switches to another NPC or closes the NPC chat dialog.
            if (Main.LocalPlayer.talkNPC == -1 || Main.npc[Main.LocalPlayer.talkNPC].type != NPCType<Scrapper>())
            {
                // When that happens, we can set the state of our UserInterface to null, thereby closing this UIState. This will trigger OnDeactivate above.
                GetInstance<Modular>().ScrapperInterface.SetState(null);
            }
        }

        private bool tickPlayed;
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Main.HidePlayerCraftingMenu = true;

            if (!coreItemSlot.item.IsAir && coreItemSlot.item.modItem is Core)
            {

                int craftX = MainLeft + 65;
                int craftY = MainTop + 25; // + 40;
                //if mouse is over button
                bool hovering = Main.mouseX > craftX - 15 && Main.mouseX < craftX + 15 && Main.mouseY > craftY - 15 && Main.mouseY < craftY + 15;
                Texture2D modifyTexture = Main.reforgeTexture[hovering ? 1 : 0];
                Main.spriteBatch.Draw(modifyTexture, new Vector2(craftX, craftY), null, Color.Black, 0f, modifyTexture.Size() / 2f, 0.8f, SpriteEffects.None, 0f);
                if (hovering)
                {
                    Main.hoverItemName = Language.GetTextValue("LegacyInterface.19");
                    //dont repeat sound

                    if (!tickPlayed)
                    {
                        //play sound
                        Main.PlaySound(SoundID.MenuTick, -1, -1, 1, 1f, 0f);
                    }
                    tickPlayed = true;
                    Main.LocalPlayer.mouseInterface = true;
                    //if button is pressed
                    if (Main.mouseLeftRelease && Main.mouseLeft)
                    {
                        // Create Clone
                        /*Core newItem = coreItemSlot.item.modItem as Core;

                        if (newItem.IsModified)
                        {
                            Main.LocalPlayer.QuickSpawnClonedItem(coreItemSlot.item, coreItemSlot.item.stack);
                            // Main.LocalPlayer.QuickSpawnClonedItem(newItem.item, newItem.item.stack);
                            *//*int temp = coreItemSlot.item.type;
                            coreItemSlot.item.type = 0;
                            coreItemSlot.item.type = temp;*//*
                            ItemText.NewText(newItem.item, newItem.item.stack, true, false);
                            Main.PlaySound(SoundID.Item37, -1, -1);
                        }
                        else
                        {
                            Main.NewText("Sorry I only take Modified Cores", Color.Yellow);
                            // Item newItem = coreItemSlot.item.Clone();
                            // Modify new item
                        }*/

                        Main.LocalPlayer.QuickSpawnItem(coreItemSlot.item, coreItemSlot.item.stack);
                        coreItemSlot.item.TurnToAir();
                        ItemText.NewText(coreItemSlot.item, coreItemSlot.item.stack, true, false);
                        Main.PlaySound(SoundID.Item37, -1, -1);


                    }
                }
                else
                {
                    tickPlayed = false;
                }
            }
            else
            {
                string message = "Place a Core here to Wipe your Modifiers";
                ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, message, new Vector2(MainLeft + 50, MainTop), new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor), 0f, Vector2.Zero, Vector2.One, -1f, 2f);
            }
        } // draw finish

    }
}
