using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem.Sample
{

    public class GUIScreen : MonoBehaviour
    {
        private Text guiscore;
        private string leScore;
        public GameObject score_manager;

        GUIStyle myStyle = new GUIStyle();
        public Font myFont;

        private void Start()
        {
            myStyle.font = myFont;
            myStyle.normal.textColor = Color.green;
        }

        private void Update()
        {
            leScore = score_manager.GetComponent<Score>().points.ToString();
            guiscore.text = leScore;
        }

    }

}
