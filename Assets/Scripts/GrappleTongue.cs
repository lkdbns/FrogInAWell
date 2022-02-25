using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicCharacterController.Examples {
    public class GrappleTongue : MonoBehaviour
    {
        /*
        public LineRenderer lr;
        private Vector3 grapplePoint;
        private SpringJoint joint;

        public LayerMask grappleable;
        public Transform mouth;
        public Transform camera;
        public GameObject player;
        public ExampleCharacterController Character;
        public float maxDistance = 100f;
        public float jointMaxDist = 0.8f;
        public float jointMinDist = 0.25f;
        public float springiness = 420f;
        public float dampnening = 7f;
        public float mass = 4.5f;
        

        void Awake() {
            lr = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update() {
            if(Input.GetMouseButtonDown(0)) {
                startGrapple();
            }
            else if(Input.GetMouseButtonUp(0)) {
                stopGrapple();
            }
        }

        void LateUpdate() {
            drawRope();
        }

        void startGrapple() {
            RaycastHit hit;
            if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, grappleable)) {
                player.GetComponent<KinematicCharacterMotor>().enabled = false;
                Debug.Log(hit.point);
                grapplePoint = hit.point;
                joint = player.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(player.transform.position, grapplePoint);

                joint.maxDistance = distanceFromPoint * jointMaxDist;
                joint.minDistance = distanceFromPoint * jointMinDist;

                joint.spring = springiness;
                joint.damper = dampnening;
                joint.massScale = mass;
            }
            // if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, grappleable)) {
            //     grapplePoint = hit.point;
            //     Character.zipTo(grapplePoint);
            // }
        }

        void drawRope() {
            if(!joint) return;

            lr.SetPosition(0, mouth.position);
            lr.SetPosition(1, grapplePoint);

            // if(!Character.isGrappling) return;

            // lr.SetPosition(0, mouth.position);
            // lr.SetPosition(1, grapplePoint);
        }

        void stopGrapple() {
            player.GetComponent<KinematicCharacterMotor>().enabled = false;
            lr.positionCount = 0;
            Destroy(joint);
        }
        */
    }
}