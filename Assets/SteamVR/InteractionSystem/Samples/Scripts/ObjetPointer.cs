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
        private bool ragdoll_touched;

        public Vector3 origin_offset = new Vector3();
        public float max_distance_to_grab = 1000;

        Transform previousContact = null;

        // everyhting for ragdoll
        private Rigidbody touched_rigibody;
        private Vector3 touched_point;
        public float force = 600;
        public float damping = 6;
        Transform jointTrans;

        private void Start()
        {

            ragdoll_touched = false;

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

        private JointDrive NewJointDrive(float force, float damping)
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
        }


        private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean action_In, SteamVR_Input_Sources sources, bool newstate)
        {
            if (newstate && touched != null)
            {
                grabed = touched;
                if (!ragdoll_touched)
                {
                    grabed.transform.SetParent(this.transform);
                }
                else
                {
                    jointTrans = AttachJoint(touched_rigibody, touched_point);
                }
            }
            else if (!newstate && grabed != null)
            {
                if (!ragdoll_touched)
                {
                    grabed.transform.SetParent(null);
                }
                else
                {
                    Destroy(jointTrans.gameObject);
                }
                grabed = null;
            }
        }



        private void Update()
        {


            if (grabed != null && !ragdoll_touched)
            {
                grabed.transform.localPosition = Vector3.zero;
                grabed.transform.localRotation = Quaternion.identity;
                grabed.transform.localPosition = origin_offset;
            }
            else if (grabed != null && ragdoll_touched)
            {
                jointTrans.position = this.transform.position + this.transform.rotation * origin_offset;
            }


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
                    if ((tag == "dress" || tag == "pizza" || tag == "alteres" || tag == "mag" || tag == "glass" || tag == "fruit" || tag == "trophy" || tag == "jeter") && grabed == null)
                    {
                        touched = hit.transform.gameObject;
                        touched_rigibody = hit.rigidbody;
                        touched_point = hit.point;
                        ragdoll_touched = (tag == "dress" || tag == "pizza" || tag == "alteres" || tag == "mag" || tag == "glass" || tag == "fruit" || tag == "trophy" || tag == "jeter");
                        Debug.Log(ragdoll_touched);
                        pointer.GetComponent<MeshRenderer>().material.color = highlightColor;
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