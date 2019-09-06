//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonEffect : MonoBehaviour
    {

        public Player player;
        public Score score;
        public GameObject timerRoom1; //durer durant room 1
        public GameObject timer; //durer durant room 2
        

        public void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.red);
            fromHand.TriggerHapticPulse(1000);

     
            if (this.tag == "introToRoom1")
            {
                //teleporter player from intro to room 1
                player.transform.position = new Vector3(447, 0, 11);
                Destroy(this.gameObject);

            }

            if (this.tag == "inRoom1")
            {
                //teleporter player from intro to room 1
                timerRoom1 = Instantiate(Resources.Load("TIMERroom1", typeof(GameObject))) as GameObject;
                timerRoom1.GetComponent<countdownROOM1>().score = score;
                timerRoom1.GetComponent<countdownROOM1>().player = player;
                Destroy(this.gameObject);

            }

            if (this.tag == "room1ToRoom2")
            {
                //teleporter player from room 1 to room 2
                player.transform.position = new Vector3(848, 0, 11);
                //timer = Instantiate(Resources.Load("TIMER", typeof(GameObject))) as GameObject;
                //timer.GetComponent<countdown>().score = score; 
                Destroy(this.gameObject);
            }

            if (this.tag == "inRoom2")
            {
                timer = Instantiate(Resources.Load("TIMER", typeof(GameObject))) as GameObject;
                timer.GetComponent<countdown>().score = score;
                timer.GetComponent<countdown>().player = player;
                Destroy(this.gameObject);
            }


        }

        public void OnButtonUp(Hand fromHand)
        {
            ColorSelf(Color.white);
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }
    }
}