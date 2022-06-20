using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pegGame
{
    /* Controller class for texts which appears in screen for 1 seconds*/

    public class TextController : MonoBehaviour
    {
        public void Awake ( )
        {
            Hide();

        }
        public void Show ( )
        {
            gameObject.SetActive(true);
            StartCoroutine(Coroutine());
        }
        public void Hide ( )
        {
            gameObject.SetActive(false);
        }
        IEnumerator Coroutine ( )
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    }
}
