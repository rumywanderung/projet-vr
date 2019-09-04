using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    public float timeLeft;

    #region TIMER

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            Debug.Log("CHANGE ROOMS");
        }
    }

    #endregion
}
