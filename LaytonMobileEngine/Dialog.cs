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

    class GameAction
    {
        public int type; //1 = dialogtext, 2 = unlock, 3 = puzzle
        public String text;

        public GameAction(int actionType, String actionText)
        {
            type = actionType;
            text = actionText;
        }
    }
}
