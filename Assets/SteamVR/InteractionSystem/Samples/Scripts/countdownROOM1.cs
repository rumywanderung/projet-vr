using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{

    public class countdownROOM1 : MonoBehaviour
    {
        public float timeLeft;
        private AssetBundle myLoadedAssetBundle;
        private string[] scenePaths;


        private void Update()
        {
            if (timeLeft < 0)
            {
                return;
            }

            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                Debug.Log("CHANGE ROOMS");
                SceneManager.LoadScene("Room 2");


            }
        }
    }
}
