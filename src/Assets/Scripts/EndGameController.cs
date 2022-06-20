using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pegGame
{
    /*
     Controller class which controls the end game panel
     */
    public class EndGameController : MonoBehaviour
    {
        public void Awake ( )
        {
            hide();
        }
        public void okButtonClicked ( )
        {
            hide();
            SceneManager.LoadScene("Menu");
        }
        public void show ( )
        {
            gameObject.SetActive(true);
        }
        public void hide ( )
        {
            gameObject.SetActive(false);
        }
    }
}
