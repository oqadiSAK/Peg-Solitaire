using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pegGame
{
    /*
     Class that represents a cell in the board
     */
    public class Cell : MonoBehaviour
    {
        public Material OpenMaterial;
        public Material PegMaterial;
        public int coorX { get; set; }
        public int coorY { get; set; }
        public CellType state { get; set; }
        private void Start ( )
        {
            var rb = this.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
        private void Update ( )
        {
            var pegRenderer = this.GetComponent<Renderer>();
            if (this.state == CellType.Open)
            {
                pegRenderer.material = OpenMaterial;
            }
            else if (this.state == CellType.Peg)
            {
                pegRenderer.material = PegMaterial;
            }
            else // state == CellType.Empty
            {
                pegRenderer.enabled = false;
            }
        }
        public void init(int _coorX, int _coorY, CellType _state, string _name, Transform _parent)
        {
            coorX = (_coorX);
            coorY = (_coorY);
            state = (_state);
            name = (_name);
            this.transform.SetParent(_parent);
        }   
        /*Method that returns of the direction of the movement*/
        public Nullable<Direction> findDirectionOfMovement(Cell other)
        {
            if (this.coorX == other.coorX)
            {
                if (this.coorY - other.coorY == 2)
                {
                    return Direction.Up;
                }
                else if (this.coorY - other.coorY == -2)
                {
                    return Direction.Down;
                }
            }
            else if (this.coorY == other.coorY)
            {
                if (this.coorX - other.coorX == 2)
                {
                    return Direction.Left;
                }
                else if (this.coorX - other.coorX == -2)
                {
                    return Direction.Right;
                }
            }
            /*
             * It returns null intentionally as it means could not found any possible
             * movement
             */
            return null;
        }
    }
}
