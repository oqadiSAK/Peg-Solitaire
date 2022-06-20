using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace pegGame
{
    /*
     God class that represents and controls the game
     */
    [System.Serializable]
    public class GameLogic : MonoBehaviour
    {
        public GameObject pegPrefab;
        public GameObject openPrefab;
        public AudioSource moveSound;
        public GameObject endGamePanel;
        private Cell clickedCell = null;
        private Cell oldClickedCell = null;
        public Cell[,] board = new Cell[9, 9];
        public int[,] representedBoard = new int[9,9];
        private int width = 9;
        private int height = 9;
        private bool justLoaded = false;
        // Start is called before the first frame update
        void Start ( )
        {
            initRepresentedBoard();
            moveSound = GetComponent<AudioSource>();
            for (int i = 0 ; i < width ; i++)
            {
                for (int j = 0 ; j < height ; j++)
                {
                    var peg = Instantiate(pegPrefab, new Vector3(i * 2.5f, 0, j * 2.5f), Quaternion.identity);
                    string pegName = ("Cell" + i + "- " + j);
                    peg.GetComponent<Cell>().init(i, j, (CellType)representedBoard[j, i], pegName, this.transform);          
                    board[j, i] = peg.GetComponent<Cell>();
                }
            }

        }
        // Update is called once per frame
        void Update ( )
        {
            Direction? dirOfMovement;
            bool found = false;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    for (int i = 0 ; i < 9 ; i++)
                    {
                        for (int j = 0 ; j < 9 ; j++)
                        {
                            if (hit.transform.gameObject.GetComponent<Cell>() == board[i, j])
                            {
                                clickedCell = board[i, j];
                                found = true;
                                break;
                            }
                        }
                        if (found)
                            break;
                    }
                    if (oldClickedCell != null)
                    {
                        dirOfMovement = oldClickedCell.GetComponent<Cell>().findDirectionOfMovement(clickedCell.GetComponent<Cell>());
                        if (dirOfMovement != null)
                        {
                            if (this.isLegal(oldClickedCell.coorY, oldClickedCell.coorX, (Direction)dirOfMovement))
                            {
                                this.makeMovement(oldClickedCell, clickedCell, (Direction) dirOfMovement);
                                oldClickedCell = null;
                            }
                        }

                    }
                    oldClickedCell = clickedCell;
                    if (this.endGame())
                    {
                        endGamePanel.GetComponent<EndGameController>().show();
                        GameObject.Find("EndGameImage").GetComponentInChildren<Text>().text = "YOUR SCORE IS " + this.boardScore().ToString();
                    }
                }

            }
            
        }
        private void initRepresentedBoard ()
        {
            if(!justLoaded)
                representedBoard = Constants.boards[Constants.selectedBoard].Clone() as int[,];
        }
        public bool isLegal ( int coorY, int coorX, Direction dir )
        {
            if (board[coorY, coorX].state == CellType.Peg)
            {
                switch (dir)
                {
                    case Direction.Right:
                        /* Checking right bounds */
                        if (coorX + 2 < 9 && board[coorY, coorX + 1].state == CellType.Peg && board[coorY, coorX + 2].state == CellType.Open)
                            return true;
                        break;

                    case Direction.Left:
                        /* Checking left bounds */
                        if (coorX - 2 >= 0 && board[coorY, coorX - 1].state == CellType.Peg && board[coorY, coorX - 2].state == CellType.Open)
                            return true;
                        break;

                    case Direction.Up:
                        /* Checking upward bounds */
                        if (coorY - 2 >= 0 && board[coorY - 1, coorX].state == CellType.Peg && board[coorY-2, coorX].state == CellType.Open)
                            return true;
                        break;

                    case Direction.Down:
                        /* Checking downward bounds */
                        if (coorY + 2 < 9 && board[coorY + 1, coorX].state == CellType.Peg && board[coorY + 2, coorX].state == CellType.Open)
                            return true;
                        break;

                        /* There is no default case */
                }
            }
            return false;
        }
        public void makeMovement ( Cell from, Cell dest, Direction dir )
        {
            int coorX = from.coorX;
            int coorY = from.coorY;
            from.state = CellType.Open;
            dest.state = CellType.Peg;
            representedBoard[from.coorY, from.coorX] = 0;
            representedBoard[dest.coorY, dest.coorX] = 1;
            Cell movedCellRef = null;
            if (dir == Direction.Right)
            {
                movedCellRef = board[coorY, coorX + 1];
            }
            else if (dir == Direction.Left)
            {
                movedCellRef = board[coorY, coorX - 1];
            }
            else if (dir == Direction.Up)
            {
                movedCellRef = board[coorY - 1, coorX];
            }
            else if (dir == Direction.Down)
            {
                movedCellRef = board[coorY + 1, coorX];
            }
            movedCellRef.state = CellType.Open;
            representedBoard[movedCellRef.coorY, movedCellRef.coorX] = 0;
            Transform movedTransform = movedCellRef.GetComponent<Transform>();
            var tempForAnimation = Instantiate(pegPrefab, movedTransform.position, Quaternion.identity);
            tempForAnimation.GetComponent<Cell>().state = CellType.Peg;
            Rigidbody rb = tempForAnimation.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = new Vector3(0, 30, 0);
            moveSound.Play();
            Destroy(tempForAnimation,1.0f);
            /*
            Physics.IgnoreCollision(from.GetComponent<Collider>(), dest.GetComponent<Collider>());
            from.GetComponent<Transform>().position = dest.GetComponent<Transform>().position;
            */
            /*
             var movedCellRenderer = movedCell.GetComponent<Renderer>();
            movedCellRenderer.material = openPrefab.GetComponent<Renderer>().material;
            movedCellRenderer.material.SetColor("_Color", Color.clear);
            */
            //String tempAppliedMovement = String.format("%d%d-%s", coorY, coorX, dir);
            //appliedMovement = tempAppliedMovement;
        }
        public bool endGame ( )
        {
            /*
             * Checking all the cells one by one
             * to see if there is any valid move that can be done,
             * if there is no valid move left on the board,
             * the game is over
             */
            bool flag = true;
            for (int i = 0 ; i < 9 && flag == true ; ++i)
            {
                for (int j = 0 ; j < 9 && flag == true ; ++j)
                {

                    for (int k = 0 ; k < 4 && flag == true ; k++)
                    {
                        if (isLegal(i, j, (Direction)k))
                            flag = false;
                    }
                }
            }
            return flag;
        }
        public int boardScore ( )
        {
            int pegCounter = 0;
            for (int i = 0 ; i < 9 ; ++i)
            {
                for (int j = 0 ; j < 9 ; ++j)
                {
                    if (board[i, j].state == CellType.Peg)
                        pegCounter++;
                }
            }
            if (pegCounter == 1)
                return 0;
            return pegCounter;
        }
        public void Save ( )
        {
            Serialization.SaveBoard("Arda",new BoardData(this,Constants.selectedBoard));
            oldClickedCell = null;
            clickedCell = null;
        }
        public void Load ( )
        {
            BoardData data = Serialization.LoadBoard(Application.persistentDataPath + "/saves/Arda.peg") as BoardData;
            representedBoard = data.board.Clone() as int[,];
            justLoaded = true;
            DestroyCurrentBoard();
            Start();
            oldClickedCell = null;
            clickedCell = null;
        }
        public void Auto ( )
        {
            int tCoorY, tCoorX, randomize;
            Direction dir;
            List<string> nextMovesList = nextMoves();
            randomize = Random.Range(0, nextMovesList.Count);
            tCoorY = nextMovesList[randomize][0] - '0';
            tCoorX = nextMovesList[randomize][1] - '0';
            dir = (Direction) (nextMovesList[randomize][3] - '0');
            if(dir == Direction.Right)
            {
                makeMovement(board[tCoorY, tCoorX], board[tCoorY, tCoorX + 2], dir);
            }
            else if (dir == Direction.Left)
            {
                makeMovement(board[tCoorY, tCoorX], board[tCoorY, tCoorX - 2], dir);
            }
            else if(dir == Direction.Up)
            {
                makeMovement(board[tCoorY, tCoorX], board[tCoorY-2, tCoorX], dir);
            }
            else if(dir == Direction.Down)
            {
                makeMovement(board[tCoorY, tCoorX], board[tCoorY+2, tCoorX], dir);
            }
        }
        List<string> nextMoves ( )
        {
            /*
             * for all cells
             * for all direction
             * check is valid
             * if valid add it to the list
             */
            List<string> possibleMoves = new List<string>();
            for (int i = 0 ; i < width ; ++i)
            {
                for (int j = 0 ; j < height ; ++j)
                {

                    for (int k = 0 ; k < 4 ; k++)
                    {
                        if (isLegal(i, j, (Direction) k))
                        {
                            possibleMoves.Add(string.Format("{0}{1}-{2}",i,j,k));
                        }
                    }
                }
            }
            return possibleMoves;
        }
        public void DestroyCurrentBoard ( )
        {
            for (int i = 0 ; i < width ; i++)
            {
                for (int j = 0 ; j < height ; j++)
                {
                    Destroy(board[j, i].gameObject);
                }
            }
        }
    }
}
