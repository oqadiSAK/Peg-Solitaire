using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pegGame
{
    /* Controller class for ui panel*/
    public class UIPanelController : MonoBehaviour
    {
        public GameObject boardMenu;
        public GameObject mainMenu;
        public GameObject transparentBackground;
        public void BackButtonClicked ( )
        {
            SceneManager.LoadScene("Menu");

        }
    }
}
