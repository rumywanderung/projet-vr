using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deposable : MonoBehaviour
{
    public Score score_manager;

    #region COLLISION

    private void OnCollisionEnter(Collision collision)
    {
        if (this.tag == "deposer" && collision.gameObject.tag == "deposer")
        {
            score_manager.points += 1;
            Debug.Log(score_manager.points);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (this.tag == "deposer" && collision.gameObject.tag == "deposer")
        {
            score_manager.points -= 1;
            Debug.Log(score_manager.points);
        }
    }

    #endregion
}
