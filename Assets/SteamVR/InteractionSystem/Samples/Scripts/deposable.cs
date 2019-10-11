using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class deposable : MonoBehaviour
    {
        public Score score_manager;

        private void OnTriggerEnter(Collider other)
        {
            if (this.tag == "dress" && other.gameObject.tag == "Ddress")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
                Debug.Log("dress déposée Trigger");
            }
            if (this.tag == "alteres" && other.gameObject.tag == "Dalteres")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "glass" && other.gameObject.tag == "Dglass")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "fruit" && other.gameObject.tag == "Dfruit")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "trophy" && other.gameObject.tag == "Dtrophy")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "mag" && other.gameObject.tag == "Dmag")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "pic" && other.gameObject.tag == "Dpic")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

        }
        #region COLLISION

        private void OnCollisionEnter(Collision collision)
        {
            if (this.tag == "dress" && collision.gameObject.tag == "Ddress")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
                Debug.Log("dress déposée Coll");
            }

            if (this.tag == "alteres" && collision.gameObject.tag == "Dalteres")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "glass" && collision.gameObject.tag == "Dglass")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "pic" && collision.gameObject.tag == "Dpic")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "trophy" && collision.gameObject.tag == "Dtrophy")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "mag" && collision.gameObject.tag == "Dmag")
            {
                score_manager.points += 1;
                Debug.Log(score_manager.points);
            }
        }

      

        private void OnCollisionExit(Collision collision)
        {
            if (this.tag == "dress" && collision.gameObject.tag == "Ddress")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "alteres" && collision.gameObject.tag == "Dalteres")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "glass" && collision.gameObject.tag == "Dglass")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "fruit" && collision.gameObject.tag == "Dfruit")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "trophy" && collision.gameObject.tag == "Dtrophy")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "mag" && collision.gameObject.tag == "Dmag")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

            if (this.tag == "pic" && collision.gameObject.tag == "Dpic")
            {
                score_manager.points -= 1;
                Debug.Log(score_manager.points);
            }

        }

        #endregion
    }
}