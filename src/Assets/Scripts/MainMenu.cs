using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pegGame {
    /*
     Controller class which controls the scene loading
     */
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame ( int boardType )
        {
            SceneManager.LoadScene("Game");
            Constants.selectedBoard = boardType;
        }
        public void QuitGame ( )
        {
            Application.Quit();
        }
    }
}
