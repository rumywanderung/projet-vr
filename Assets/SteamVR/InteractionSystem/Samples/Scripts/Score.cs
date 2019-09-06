using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem.Sample
{
    public class Score : MonoBehaviour
    {
        public int points;
        GUIStyle myStyle = new GUIStyle();
        public Font myFont;

        void Start()
        {
            Font myFont = (Font)Resources.Load("/fonts/digital-7", typeof(Font));
            myStyle.font = myFont;
            myStyle.normal.textColor = Color.green;
        }

        void OnGUI()
        {
            GUI.Label(new Rect(500, 20, 300, 300), "SCORE : " + points.ToString() + "/14", myStyle);
        }
    }
}
