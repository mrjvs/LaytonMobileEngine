using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class Dialogue
    {
        public List<GameAction> actionList;

        public Dialogue(List<GameAction> actionList)
        {
            this.actionList = actionList;
        }

    }

    public interface GameAction { }

    public class TextGameAction : GameAction
    {
        public String text;
        public string nameText;

        public TextGameAction(String actionText, string nText)
        {
            text = actionText;
            nameText = nText;
        }
    }

    public class PuzzleGameAction : GameAction
    {
        public int id;

        public PuzzleGameAction(int puzzleId)
        {
            id = puzzleId;
        }
    }
}
