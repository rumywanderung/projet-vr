//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.Extras;

namespace Valve.VR.InteractionSystem.Sample
{

    public class ObjetPointer : MonoBehaviour
    {
        //public SteamVR_Behaviour_Pose pose;

        public Player player;

        public SteamVR_Action_Boolean grabPinch;
        public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;


        public Color color;
        public float thickness = 0.002f;
        public Color highlightColor = Color.green;
        public GameObject holder;
        public GameObject pointer;
        public bool addRigidBody = false;

        private GameObject touched;
        private GameObject grabed;
        private bool objects_touched;

        public Vector3 origin_offset = new Vector3();
        public float max_distance_to_grab = 1000;

        Transform previousContact = null;

        // everyhting for objects
        private Rigidbody touched_rigibody;
        private Vector3 touched_point;
        public float force = 600;
        public float damping = 6;
        Transform jointTrans;

        public GameObject timerRoom1; //durer durant room 1
        public GameObject timer; //durer durant room 2
        public Score score;

        private void Start()
        {

            objects_touched = false;

            holder = new GameObject();
            holder.transform.parent = this.transform;
            holder.transform.localPosition = Vector3.zero;
            holder.transform.localRotation = Quaternion.identity;

            pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
            pointer.transform.parent = holder.transform;
            pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
            pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
            pointer.transform.localRotation = Quaternion.identity;
            BoxCollider collider = pointer.GetComponent<BoxCollider>();

            if (addRigidBody)
            {
                if (collider)
                {
                    collider.isTrigger = true;
                }
                Rigidbody rigidBody = pointer.AddComponent<Rigidbody>();
                rigidBody.isKinematic = true;
            }
            else
            {
                if (collider)
                {
                    Object.Destroy(collider);
                }
            }
            Material newMaterial = new Material(Shader.Find("Unlit/Color"));
            newMaterial.SetColor("_Color", color);
            pointer.GetComponent<MeshRenderer>().material = newMaterial;
        }

        void OnEnable()
        {
            if (grabPinch != null)
            {
                grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
            }
        }


        private void OnDisable()
        {
            if (grabPinch != null)
            {
                grabPinch.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSource);
            }
        }

      /*  private JointDrive NewJointDrive(float force, float damping)
        {
            JointDrive drive = new JointDrive();
            drive.mode = JointDriveMode.Position;
            drive.positionSpring = force;
            drive.positionDamper = damping;
            drive.maximumForce = Mathf.Infinity;
            return drive;
        }

        Transform AttachJoint(Rigidbody rb, Vector3 attachmentPosition)
        {
            GameObject go = new GameObject("Attachment Point");
            go.hideFlags = HideFlags.HideInHierarchy;
            go.transform.position = attachmentPosition;

            var newRb = go.AddComponent<Rigidbody>();
            newRb.isKinematic = true;

            var joint = go.AddComponent<ConfigurableJoint>();
            joint.connectedBody = rb;
            joint.configuredInWorldSpace = true;
            joint.xDrive = NewJointDrive(force, damping);
            joint.yDrive = NewJointDrive(force, damping);
            joint.zDrive = NewJointDrive(force, damping);
            joint.slerpDrive = NewJointDrive(force, damping);
            joint.rotationDriveMode = RotationDriveMode.Slerp;

            return go.transform;
        }*/

        private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean action_In, SteamVR_Input_Sources sources, bool newstate)
        {
            Debug.Log(newstate);
            Debug.Log(touched);
            Debug.Log("function OnTriggerPress");

            if (newstate && touched != null)
            {
                if (touched.gameObject.tag == "inRoom1")
                {
                    /*timerRoom1 = Instantiate(Resources.Load("TIMERroom1", typeof(GameObject))) as GameObject;
                    timerRoom1.GetComponent<countdownROOM1>().score = score;
                    timerRoom1.GetComponent<countdownROOM1>().player = player;*/
                    player.transform.position = new Vector3(835, 0, 13);
                    timer = Instantiate(Resources.Load("TIMER", typeof(GameObject))) as GameObject;
                    timer.GetComponent<countdown>().score = score;
                    timer.GetComponent<countdown>().player = player;

                    Destroy(touched.GetComponent<PopUp>().canvas);
                    Destroy(touched.gameObject);
                    Debug.Log("inRoom1 trigger pressed");
                    grabed = null;
                }

                else if (touched.gameObject.tag == "introToRoom1")
                {
                    player.transform.position = new Vector3(442, 0, 12);
                    Debug.Log("intro trigger pressed");
                    Destroy(touched.GetComponent<PopUp>().canvas);
                    Destroy(touched.gameObject);
                    grabed = null;
                }

                /*else if (touched.gameObject.tag == "inRoom2")
                {
                    timer = Instantiate(Resources.Load("TIMER", typeof(GameObject))) as GameObject;
                    timer.GetComponent<countdown>().score = score;
                    timer.GetComponent<countdown>().player = player;
                    Destroy(touched.GetComponent<PopUp>().canvas);
                    Destroy(touched.gameObject);
                    Debug.Log("inRoom2 trigger pressed");
                    grabed = null;
                }*/

                else if (touched.gameObject.tag == "dress" || touched.gameObject.tag == "alteres" || touched.gameObject.tag == "mag" || touched.gameObject.tag == "glass" || touched.gameObject.tag == "trophy" || touched.gameObject.tag == "pic" || touched.gameObject.tag == "jeter" && grabed == null)
                {
                    grabed = touched;
                    grabed.transform.SetParent(this.transform);
                    Debug.Log(touched);
                    Debug.Log(grabed);
                }
            }
            else if (!newstate && grabed != null)
            {
                grabed.transform.SetParent(null);
                grabed = null;
                Debug.Log(touched);
                Debug.Log(grabed);
            }
        }

        
        private void Update()
        {

            if (grabed != null && !objects_touched)
            {
                grabed.transform.localPosition = Vector3.zero;
                grabed.transform.localRotation = Quaternion.identity;
                grabed.transform.localPosition = origin_offset;
            }
           /* else if (grabed != null && objects_touched)
            {
                jointTrans.position = this.transform.position + this.transform.rotation * origin_offset;
            }*/


            touched = null;

            float dist = 100f;

            Ray raycast = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            bool bHit = Physics.Raycast(raycast, out hit);

            if (bHit)
            {
                if (hit.distance <= max_distance_to_grab)
                {
                    string tag = hit.transform.gameObject.tag;
                    if ((tag == "introToRoom1" || tag == "inRoom1" || tag == "inRoom2" || tag == "dress" || tag == "alteres" || tag == "mag" || tag == "glass" || tag == "trophy" || tag == "pic" || tag == "jeter") && grabed == null)
                    {
                        touched = hit.transform.gameObject;
                        /*touched_rigibody = hit.rigidbody;
                        touched_point = hit.point;
                        objects_touched = (tag == "dress" || tag == "pizza" || tag == "alteres" || tag == "mag" || tag == "glass" || tag == "fruit" || tag == "trophy" || tag == "jeter");
                        Debug.Log("bhit");*/
                        pointer.GetComponent<MeshRenderer>().material.color = highlightColor;

                        /*if (tag == "introToRoom1")
                        {
                            //Debug.Log("we got here");
                            //player.transform.position = new Vector3(77, -121, -2);
                            //Destroy(touched.gameObject);
                        }*/
                    }

                    
                }
            }

            if (!bHit)
            {
                previousContact = null;
            }
            if (bHit && hit.distance < 100f)
            {
                dist = hit.distance;
            }

            if (touched == null)
            {
                pointer.GetComponent<MeshRenderer>().material.color = color;
            }
            pointer.transform.localPosition = new Vector3(0f, 0f, dist / 2f);
        }
    }

    public struct PointerEventArgs
    {
        public SteamVR_Input_Sources fromInputSource;
        public uint flags;
        public float distance;
        public Transform target;
    }

    public delegate void PointerEventHandler(object sender, PointerEventArgs e);
}