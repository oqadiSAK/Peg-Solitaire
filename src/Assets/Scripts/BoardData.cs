using UnityEngine;

namespace pegGame
{
    /*
     Class which stores the data of the board
     */
    [System.Serializable]
    public class BoardData
    {
        public int[,] board;
        public int boardType;
        public BoardData(GameLogic game , int _boardType)
        {
            board = game.representedBoard.Clone() as int[,];
            boardType = _boardType;
        }
        
    }
}
