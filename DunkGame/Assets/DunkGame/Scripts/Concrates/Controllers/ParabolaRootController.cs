using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class ParabolaRootController : MonoBehaviour
    {
        /// <summary>
        /// This script just set to positions of parabola.
        /// First position is always be ball's position.
        /// Last position is always be target position.
        /// Second position will be near to target and a few point higher. This point can be math scripted if wwanted.
        /// </summary>

        SwipeDetection swipeDetection;
        PassController passController;

        [Header("Basket and Ball")]
        [SerializeField] Transform basketTransform;
        [SerializeField] Transform ballTransform;

        [Header("Player to Pass")]
        Transform rightPassTarget;
        Transform leftPassTarget;

        [Header("Parabola Height")]
        [SerializeField] float secondPointHeight = 4f;

        
        private void OnEnable()
        {
            swipeDetection = SwipeDetection.Instance;
            passController = PassController.Instance;
            swipeDetection.OnUpSwipe += SetPositionsToShot;
            swipeDetection.OnRightSwipe += SetPositionsToPassRight;
            swipeDetection.OnLeftUpSwipe += SetPositionsToPassLeft;
        }
        private void OnDisable()
        {
            swipeDetection.OnUpSwipe -= SetPositionsToShot;
            swipeDetection.OnRightSwipe -= SetPositionsToPassRight;
            swipeDetection.OnLeftUpSwipe -= SetPositionsToPassLeft;
        }
        
        /// <summary>
        /// Setting last position to basket himself and making randomize if the ball too far to basket.
        /// </summary>
        void SetPositionsToShot()
        {
            this.gameObject.transform.GetChild(0).position = ballTransform.position;
            this.gameObject.transform.GetChild(1).position = new Vector3((ballTransform.transform.position.x + basketTransform.position.x) / 2,
                Mathf.Max(ballTransform.position.y, basketTransform.position.y) + secondPointHeight,
                (ballTransform.position.z + basketTransform.transform.position.z) / 2f);
            this.gameObject.transform.GetChild(2).position = basketTransform.transform.position;

            if (Mathf.Abs(Vector3.Distance(ballTransform.position, basketTransform.transform.position)) > 20f) // If ball far enough can be basket randomize.
            {
                float randomZOffset = Random.Range(-4f, 4f);
                this.gameObject.transform.GetChild(2).position = new Vector3(basketTransform.transform.position.x, basketTransform.transform.position.y, basketTransform.transform.position.z + randomZOffset);
            }
        }
        void SetPositionsToPassRight()
        {
            rightPassTarget = passController.CheckClosestRight();

            this.gameObject.transform.GetChild(0).position = ballTransform.position;
            this.gameObject.transform.GetChild(1).position = new Vector3((ballTransform.position.x + rightPassTarget.position.x) / 2,
                Mathf.Max(ballTransform.position.y,rightPassTarget.position.y) + secondPointHeight,
                (ballTransform.position.z + rightPassTarget.transform.position.z) / 2f);
            this.gameObject.transform.GetChild(2).position = rightPassTarget.transform.position;
        }
        void SetPositionsToPassLeft()
        {
            leftPassTarget = passController.CheckClosestLeft();

            this.gameObject.transform.GetChild(0).position = ballTransform.position;
            this.gameObject.transform.GetChild(1).position = new Vector3((ballTransform.position.x + leftPassTarget.position.x) / 2,
                Mathf.Max(ballTransform.position.y, leftPassTarget.position.y) + secondPointHeight,
                (ballTransform.position.z + leftPassTarget.transform.position.z) / 2f);
            this.gameObject.transform.GetChild(2).position = leftPassTarget.transform.position;
        }
    }
}
