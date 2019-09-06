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
        public Player player;
        public Score score;
        public GameObject timer; //durer durant room 2



        private void Update()
        {
            if (timeLeft < 0)
            {
                return;
            }

            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                player.transform.position = new Vector3(848, 0, 11);
                timer = Instantiate(Resources.Load("TIMER", typeof(GameObject))) as GameObject;
                timer.GetComponent<ButtonEffect>().score = score; // FONCTIONNE PAS ENCORE


            }
        }
    }
}
