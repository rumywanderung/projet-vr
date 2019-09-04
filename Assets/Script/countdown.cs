using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    public float timeLeft;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

   

    #region TIMER

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            Debug.Log("CHANGE ROOMS");
            Destroy(this.gameObject);
            SceneManager.LoadScene("Room 2");
        }
    }

    #endregion
}
