using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{

    public class INTROButtonEffect : MonoBehaviour
    {
        public float timeLeft;
        private AssetBundle myLoadedAssetBundle;
        private string[] scenePaths;

        void Start()
        {
            SceneManager.LoadScene("Room 1");
        }
    }
}

