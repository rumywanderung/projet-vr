using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{

    public class CleanUpYourRoom : MonoBehaviour
    {
        //private bool present = false;
        public Score score_manager;

        //private void OnTriggerStay(Collider other)
        //{
        //    if (other.tag == "trash" && !present)
        //    {
        //        score_manager.points -= 1;
        //        present = true;
        //    }
        //}

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "jeter")
            {
                score_manager.points += 1;
                Destroy(other.gameObject);
                Debug.Log(score_manager.points);
                Debug.Log("Objet jeté!");
            }

            else if (other.tag == "dress" || other.tag == "alteres" || other.tag == "mag" || other.tag == "glass" || other.tag == "trophy" || other.tag == "pic")
            {
                
                Destroy(other.gameObject);
                Debug.Log("MAUVAIS OBJET DETRUIT NOOOOOOOO");
            }
        }
    }
}
