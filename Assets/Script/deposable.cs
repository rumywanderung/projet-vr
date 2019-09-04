using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deposable : MonoBehaviour
{
    private int points = 0;
   

    #region COLLISION

    private void OnCollisionEnter(Collision collision)
    {
        if (this.tag == "deposer" && collision.gameObject.tag == "deposer")
        {
            points += 5;
            Debug.Log(points);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (this.tag == "deposer" && collision.gameObject.tag == "deposer")
        {
            points -= 5;
            Debug.Log(points);
        }
    }

    #endregion
}
