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
        public Player player;

        #region TIMER


        private void Update()
        {

            if (timeLeft < 0) { 
                return;
            }

            timeLeft -= Time.deltaTime; 

            if (timeLeft < 0)
            {
                Debug.Log("CHANGE ROOMS");

                //if (score.points < 14)
                if (score.points == 1)
                {
                    Debug.Log("GAME OVER");
                    player.transform.position = new Vector3(1293, 3, 31);
                }
                else
                {
                    Debug.Log("YOU WIN");
                    //restart
                }
                
            }
        }
    }

    #endregion
}
