using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using Modular.Items.Cores;

namespace Modular.UI
{
    class ModifierUI : UIState
    {
        private UIItemSlot[] modifierSlotArr;
        private UIItemSlot coreItemSlot;
        private bool active = false;
        const int MainLeft = 20;
        const int MainTop = 260;

        public ModifierUI(int slots)
        {
            modifierSlotArr = new UIItemSlot[slots];
        }

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
            CreateSlotArr();
        }
        public void SetActive(bool newActive)
        {
            active = newActive;
        }

        public bool GetActive()
        {
            return active;
        }

        public void CreateSlotArr()
        {
            for (int i = 0; i < modifierSlotArr.Length; i++)
            {
                UIItemSlot tempItemSlot = new UIItemSlot(ItemSlot.Context.BankItem, .65f)
                {
                    Left = { Pixels = MainLeft + 5},
                    Top = { Pixels = MainTop + 50 + (i * 40) }
                };
                tempItemSlot.Activate();
                Append(tempItemSlot);
                modifierSlotArr[i] = tempItemSlot;
            }
        }

        public void VisableModifiedSlots()
        {
            for (int i = 0; i < modifierSlotArr.Length; i++)
            {
                modifierSlotArr[i].Visible = true;
            }
        }

        public void DeactivateCoreSlot()
        {
            Main.LocalPlayer.QuickSpawnClonedItem(coreItemSlot.item, coreItemSlot.item.stack);
            coreItemSlot.item.TurnToAir();
        }
        public void DeactivateModifierSlot()
        {
            for (int i = 0; i < modifierSlotArr.Length; i++)
            {
                UIItemSlot tempItemSlot = modifierSlotArr[i];
                if(tempItemSlot.item.IsAir)
                {
                    tempItemSlot.Visible = false;
                    continue;
                }

                Main.LocalPlayer.QuickSpawnClonedItem(tempItemSlot.item, tempItemSlot.item.stack);
                tempItemSlot.item.TurnToAir();
                tempItemSlot.Visible = false;
            }
        }

        public override void OnDeactivate()
        {
            DeactivateModifierSlot();
            DeactivateCoreSlot();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(!active)
            {
                Deactivate();
            }
        }

        private bool tickPlayed;
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            Main.HidePlayerCraftingMenu = true;

            if (!coreItemSlot.item.IsAir && coreItemSlot.item.modItem is Core)
            {
                VisableModifiedSlots();

                int craftX = MainLeft + 25;
                int craftY = MainTop + 70 + (modifierSlotArr.Length * 40);
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
                        Core newItem = coreItemSlot.item.modItem as Core;

                        if (newItem.IsModified)
                        {
                            Main.NewText("Please Use UnModified Cores", Color.Yellow);
                        }
                        else
                        {
                            // Item newItem = coreItemSlot.item.Clone();
                            // Modify new item
                            newItem = newItem.SetModifiers(modifierSlotArr);

                            //if item changed
                            if (newItem != null)
                            {
                                //give back item
                                // Main.LocalPlayer.QuickSpawnClonedItem(newItem.item, newItem.item.stack);

                                ItemText.NewText(newItem.item, newItem.item.stack, true, false);
                                Main.PlaySound(SoundID.Item37, -1, -1);

                                // Wipe out Custom Ui
                                // coreItemSlot.item.TurnToAir();
                                for (int i = 0; i < modifierSlotArr.Length; i++)
                                {
                                    // wipe
                                    modifierSlotArr[i].item.TurnToAir();
                                }
                            }
                        }
                    }
                }
                else
                {
                    tickPlayed = false;
                }
            }
            else if(modifierSlotArr[0].Visible)
            {
                DeactivateModifierSlot();
            }
        } // draw finish

    }
}
