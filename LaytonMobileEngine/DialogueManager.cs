using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace LaytonMobileEngine
{
    class DialogueManager
    {

        private List<Dialogue> dialogueList = new List<Dialogue>();

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

            t = Texture2D.FromStream(g, new FileStream(ConfigurationManager.AppSettings["scriptFilePath"] + "\\test.png", FileMode.Open));
        }

        public void AddDialog(Dialogue dialogue)
        {
            dialogueList.Add(dialogue);
        }

        public void RunDialog(int id)
        {
            currentDialog = id;
            isRunning = true;
        }

        public void Draw(SpriteBatch canvas, SpriteFont font)
        {
            if (!isRunning) return;

            canvas.Draw(t, new Rectangle(200, 520, 800, 180), null, Color.Beige);
            

            if (dialogueList[currentDialog].actionList[currentAction] is TextGameAction)
            {
                canvas.DrawString(font, ((TextGameAction)dialogueList[currentDialog].actionList[currentAction]).text, new Vector2(240, 570), Color.Black);
                canvas.DrawString(font, ((TextGameAction)dialogueList[currentDialog].actionList[currentAction]).nameText, new Vector2(240, 535), Color.Black);
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
                if (currentAction >= dialogueList[currentDialog].actionList.Count)
                {
                    ResetValues();
                    return true;
                }
            }
            return false;
        }

        public void ResetValues()
        {
            currentDialog = 0;
            isRunning = false;
            charProgress = 0;
            isInAnimation = false;
            currentAction = 0;

        }
    }
}
