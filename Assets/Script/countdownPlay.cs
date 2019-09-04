using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdownPlay : MonoBehaviour
{
    public float timeLeftToPlay;

    #region TIMER

    private void Update()
    {
        timeLeftToPlay -= Time.deltaTime;

        if (timeLeftToPlay < 0)
        {
            Debug.Log("END GAME");
        }
    }

    #endregion
}
