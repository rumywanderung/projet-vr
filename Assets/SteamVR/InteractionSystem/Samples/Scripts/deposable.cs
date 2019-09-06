﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class deposable : MonoBehaviour
    {
        public Score score_manager;

        #region COLLISION

        private void OnCollisionEnter(Collision collision)
        {
            if (this.tag == "dress" && collision.gameObject.tag == "dress")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "alteres" && collision.gameObject.tag == "alteres")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "glass" && collision.gameObject.tag == "glass")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "fruit" && collision.gameObject.tag == "fruit")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "trophy" && collision.gameObject.tag == "trophy")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "mag" && collision.gameObject.tag == "mag")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }
        }

      

        private void OnCollisionExit(Collision collision)
        {
            if (this.tag == "dress" && collision.gameObject.tag == "dress")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "alteres" && collision.gameObject.tag == "alteres")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "glass" && collision.gameObject.tag == "glass")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "fruit" && collision.gameObject.tag == "fruit")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "trophy" && collision.gameObject.tag == "trophy")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "mag" && collision.gameObject.tag == "mag")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }
        
    }

        #endregion
    }
}