using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    public class countdown : MonoBehaviour
    {
        public float timeLeft;
        private AssetBundle myLoadedAssetBundle;
        private string[] scenePaths;
        public Score score;
        private float delay;

        #region TIMER

        private void Start()
        {
            delay = timeLeft;
        }

        private void Update()
        {

            if (delay < 0) { 
                return;
            }

            delay -= Time.deltaTime;
            Debug.Log(delay);
            Debug.Log(score);

            if (delay < 0)
            {
                Debug.Log("CHANGE ROOMS");

                if (score.points < 14)
                {
                    Debug.Log("GAME OVER");
                    Destroy(this.gameObject);
                    // restart game
                }
                else
                {
                    Debug.Log("YOU WIN");
                    Destroy(this.gameObject);
                    //restart
                }
                
            }
        }
    }

    #endregion
}
