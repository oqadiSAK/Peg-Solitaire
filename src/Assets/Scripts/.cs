using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pegGame
{
    public class PegSolitaire
    {
        public class Cell 
        {
            private int coorX;
            private int coorY;
            private CellType state;

            public Cell(int _coorX, int _coorY, CellType _state)
            {
                setCoorX(_coorX);
                setCoorY(_coorY);
                setState(_state);
            }

            public Cell(CellType _state)
                : this(-1, -1, _state)
            {
                /*Intentionally empty*/
            }

            public int getCoorX()
            {
                return coorX;
            }

            public void setCoorX(int _coorX)
            {
                coorX = _coorX;
            }

            public int getCoorY()
            {
                return coorY;
            }

            public void setCoorY(int _coorY)
            {
                coorY = _coorY;
            }

            public CellType getState()
            {
                return state;
            }

            public void setState(CellType _state)
            {
                state = _state;
            }

            public Nullable<Direction> findDirectionOfMovement(Cell other)
            {
                if (this.coorX == other.getCoorX())
                {
                    if (this.coorY - other.getCoorY() == 2)
                    {
                        return Direction.Up;
                    }
                    else if (this.coorY - other.getCoorY() == -2)
                    {
                        return Direction.Down;
                    }
                }
                else if (this.coorY == other.getCoorY())
                {
                    if (this.coorX - other.getCoorX() == 2)
                    {
                        return Direction.Left;
                    }
                    else if (this.coorX - other.getCoorX() == -2)
                    {
                        return Direction.Right;
                    }
                }
                /*
                 * It returns null intentionally null means could not found any possible
                 * movement
                 */
                return null;
            }
        }
        private Cell[,] board;
        private int boardType;

        public PegSolitaire(int _boardType)
        {
            if (_boardType < 1 || _boardType > 5)
                boardType = 1;
            else
            {
                boardType = _boardType;
            }
            initialize();
        }
        public PegSolitaire()
            : this(1)
        {
            /*Intentionally empty*/
        }
        public void initialize()
        {
            switch (boardType)
            {
                case 1:
                    board = new Cell[9,9] {
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Open), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) }
                };
                    break;
                case 2:
                    board = new Cell[9, 9] {
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg) },
                        { new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Open), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg) },
                        { new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) } };
                    break;
                case 3:
                    board = new Cell[9, 9] {
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty) },
                        { new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Open), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty) },
                        { new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) } };
                    break;
                case 4:
                    board = new Cell[9, 9] {
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Open), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) } };
                    break;
                case 5:
                    board = new Cell[9, 9] {
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty) },
                        { new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Open), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg) },
                        { new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Peg), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Peg), new Cell(CellType.Peg), new Cell(CellType.Peg),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) },
                        { new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Peg), new Cell(CellType.Empty),
                                new Cell(CellType.Empty), new Cell(CellType.Empty), new Cell(CellType.Empty) } };
                    break;
                default:
                    /* There is no default case board type already checked */
                    break;
            }
            Console.WriteLine("Board length : " + 9);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine("Board(i) length : " + 9);

                    board[i,j].setCoorX(j);
                    board[i,j].setCoorY(i);
                }
            }
        }
        public bool play(int coorY, int coorX, Direction dir)
        {
            /* Check if entered movement is legal */
            if (isLegal(coorY, coorX, dir))
            {
                makeMovement(coorY, coorX, dir);
                return true;
            }
            return false;
        }
        public bool isLegal(int coorY, int coorX, Direction dir)
        {
            /* Checking bounds */
            if (coorY >= 0 && coorY < 9 && coorX >= 0 && coorX < board.GetLength(coorY))
            {
                /* Checking if it is a Peg cell or not */
                if (board[coorY,coorX].getState() == CellType.Peg)
                {
                    switch (dir)
                    {
                        case Direction.Right:
                            /* Checking right bounds */
                            if (coorX + 2 < board.GetLength(coorY))
                            {
                                if (board[coorY,coorX + 1].getState() == CellType.Peg
                                        && board[coorY,coorX + 2].getState() == CellType.Open)
                                    return true;
                            }
                            break;
                        case Direction.Left:
                            /* Checking left bounds */
                            if (coorX - 2 >= 0)
                            {
                                if (board[coorY,coorX - 1].getState() == CellType.Peg
                                        && board[coorY,coorX - 2].getState() == CellType.Open)
                                    return true;
                            }
                            break;

                        case Direction.Up:
                            /* Checking upward bounds */
                            if (coorY - 2 >= 0)
                            {
                                if (board[coorY - 1,coorX].getState() == CellType.Peg
                                        && board[coorY - 2,coorX].getState() == CellType.Open)
                                    return true;
                            }
                            break;
                        case Direction.Down:
                            /* Checking downward bounds */
                            if (coorY + 2 < 9)
                            {
                                if (board[coorY + 1,coorX].getState() == CellType.Peg
                                        && board[coorY + 2,coorX].getState() == CellType.Open)
                                    return true;
                            }
                            break;
                        default:
                            /* There is no default case */
                            break;
                    }
                }
            }
            return false;
        }
        public void makeMovement(int coorY, int coorX, Direction dir)
        {
            /*
             * Checking the direction in a switch case
             * and assigning new empty and new peg cells
             */
            switch (dir)
            {
                case Direction.Right:

                    board[coorY,coorX + 2].setState(CellType.Peg);
                    board[coorY,coorX].setState(CellType.Open);
                    board[coorY,coorX + 1].setState(CellType.Open);
                    break;
                case Direction.Left:

                    board[coorY,coorX - 2].setState(CellType.Peg);
                    board[coorY,coorX].setState(CellType.Open);
                    board[coorY,coorX - 1].setState(CellType.Open);
                    break;
                case Direction.Up:

                    board[coorY - 2,coorX].setState(CellType.Peg);
                    board[coorY,coorX].setState(CellType.Open);
                    board[coorY - 1,coorX].setState(CellType.Open);
                    break;
                case Direction.Down:
                    board[coorY + 2,coorX].setState(CellType.Peg);
                    board[coorY,coorX].setState(CellType.Open);
                    board[coorY + 1,coorX].setState(CellType.Open);
                    break;
                default:
                    /* There is no default case */
                    break;
            }
            //String tempAppliedMovement = String.format("%d%d-%s", coorY, coorX, dir);
            //appliedMovement = tempAppliedMovement;
        }
        public bool endGame()
        {
            /*
             * Checking all the cells one by one
             * to see if there is any valid move that can be done,
             * if there is no valid move left on the board,
             * the game is over
             */
            bool flag = true;
            for (int i = 0; i < 9 && flag == true; ++i)
            {
                for (int j = 0; j < 9 && flag == true; ++j)
                {

                    for (int k = 0; k < 4 && flag == true; k++)
                    {
                        //if (isLegal(i, j, Direction.fromInteger(k)))
                        flag = false;
                    }
                }
            }
            return flag;
        }
        public int boardScore()
        {
            int pegCounter = 0;
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    if (board[i,j].getState() == CellType.Peg)
                        pegCounter++;
                }
            }
            if (pegCounter == 1)
                return 0;
            return pegCounter;
        }
        public int getSizeRow()
        {
            return 9;
        }

        public int getSizeColumn(int row)
        {
            if (row >= 0 && row < getSizeRow())
            {
                // exception handle
            }
            return board.GetLength(row);
        }

        public Cell getCell(int i, int j)
        {
            return board[i,j];
        }
        public void printBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
 
    }
    
    
}
