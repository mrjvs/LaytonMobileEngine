using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class DialogueManager
    {

        private List<Dialogue> dialogList = new List<Dialogue>();

        private GraphicsDevice g;
        private Texture2D t;

        public int currentDialog = 0;
        public bool isRunning = false;
        public int charProgress = 0;
        public bool isInAnimation = false;
        public int currentAction = 0;

        public DialogueManager(GraphicsDevice g)
        {
            this.g = g;

            t = new Texture2D(g, 1, 1);
            t.SetData<Color>(
               new Color[] { Color.White
            });
        }

        public void addDialog(Dialogue dialogue)
        {
            dialogList.Add(dialogue);
        }

        public void runDialog(int id)
        {
            currentDialog = id;
            isRunning = true;
        }

        public void draw(SpriteBatch canvas, SpriteFont font)
        {
            if (!isRunning) return;
            canvas.Draw(t, new Rectangle(200, 520, 800, 180), null, Color.Beige);
            if (dialogList[currentDialog].actionList[currentAction] is TextGameAction)
            {
                canvas.DrawString(font, ((TextGameAction)dialogList[currentDialog].actionList[currentAction]).text, new Vector2(210, 530), Color.Black);
            } else
            {
                canvas.DrawString(font, "PUZZLEGAMEACTION", new Vector2(210, 530), Color.Black);
            }

        }

        public bool click(int mouseX, int mouseY)
        {
            if (isRunning)
            {
                currentAction++;
                if (currentAction >= dialogList[currentDialog].actionList.Count)
                {
                    resetValues();
                    return true;
                }
            }
            return false;
        }

        public void resetValues()
        {
            currentDialog = 0;
            isRunning = false;
            charProgress = 0;
            isInAnimation = false;
            currentAction = 0;
        }
    }
}
