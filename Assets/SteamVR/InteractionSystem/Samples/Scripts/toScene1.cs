using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{

    public class toScene1 : MonoBehaviour
    {
        private int nextSceneToLoad;

        private void Start()
        {
            nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        }


        private void OnTriggerEnter()
        {

        }
    }
}
