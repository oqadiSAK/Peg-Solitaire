using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pegGame
{
    /*
     Class that stores the constant variables
     */
    public class Constants
    {
        public static int selectedBoard = 0;
        public static List<int[,]> boards = new List<int[,]>
        {
            new int[,]
            {
                { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 },
                { -1, -1, 1, 1, 1, 1, 1, -1, -1 },
                { -1, 1, 1, 1, 1, 1, 1, 1, -1 },
                { -1, 1, 1, 1, 0, 1, 1, 1, -1 },
                { -1, 1, 1, 1, 1, 1, 1, 1, -1, },
                { -1, -1, 1, 1, 1, 1, 1, -1, -1, },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1, },
                { -1, -1, -1, -1, -1, -1, -1, -1, -1 }
            },
            new int[,]
            {
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 0, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 }
            },
            new int[,]
            {
                { -1, -1, 1, 1, 1, -1, -1, -1, -1 },
                { -1, -1, 1, 1, 1, -1, -1, -1, -1 },
                { -1, -1, 1, 1, 1, -1, -1, -1, -1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, -1 },
                { 1, 1, 1, 1, 0, 1, 1, 1, -1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, -1 },
                { -1, -1, 1, 1, 1, -1, -1, -1, -1 },
                { -1, -1, 1, 1, 1, -1, -1, -1, -1 },
                { -1, -1, 1, 1, 1, -1, -1, -1, -1 }
            },
            new int[,]
            {
                { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1, },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1, },
                { -1, 1, 1, 1, 1, 1, 1, 1, -1, },
                { -1, 1, 1, 1, 0, 1, 1, 1, -1, },
                { -1, 1, 1, 1, 1, 1, 1, 1, -1, },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1, },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1, },
                { -1, -1, -1, -1, -1, -1, -1, -1, -1 }
            },
            new int[,]
            {
                { -1, -1, -1, -1, 1, -1, -1, -1, -1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 },
                { -1, -1, 1, 1, 1, 1, 1, -1, -1 },
                { -1, 1, 1, 1, 1, 1, 1, 1, -1 },
                { 1, 1, 1, 1, 0, 1, 1, 1, 1 },
                { -1, 1, 1, 1, 1, 1, 1, 1, -1 },
                { -1, -1, 1, 1, 1, 1, 1, -1, -1 },
                { -1, -1, -1, 1, 1, 1, -1, -1, -1 },
                { -1, -1, -1, -1, 1, -1, -1, -1, -1 }
            }
        };
    }
}