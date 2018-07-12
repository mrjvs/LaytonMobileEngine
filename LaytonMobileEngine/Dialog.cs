using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaytonMobileEngine
{
    class Dialog
    {
        public List<GameAction> actionList;

        public Dialog(List<GameAction> actionList)
        {
            this.actionList = actionList;
        }

    }

    public interface GameAction { }

    public class TextGameAction : GameAction
    {
        public String text;

        public TextGameAction(String actionText)
        {
            text = actionText;
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
