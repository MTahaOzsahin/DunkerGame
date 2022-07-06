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
        /// Last position is always be basket position.
        /// Second position will be near to basket and a few point higher. This point can be math scripted if wwanted.
        /// </summary>

        [SerializeField] Collider basketCollider;
        [SerializeField] Transform ballTransform;

        [SerializeField] float lerpValue = 0.5f;
        [SerializeField] float secondPointHeight = 4f;

        private void Update()
        {
            SetPositions();
        }
        void SetPositions()
        {
            this.gameObject.transform.GetChild(0).position = ballTransform.position;
            this.gameObject.transform.GetChild(1).position = new Vector3(this.gameObject.transform.GetChild(1).position.x, secondPointHeight
                , Vector3.Slerp(ballTransform.position, basketCollider.transform.position, lerpValue).z);
            this.gameObject.transform.GetChild(2).position = basketCollider.transform.position;

            
            
            if (Mathf.Abs(Vector3.Distance(ballTransform.position,basketCollider.transform.position)) > 20f) // If ball far enough can be basket randomize.
            {
                float randomZOffset = Random.Range(-4f, 4f);
                this.gameObject.transform.GetChild(2).position =new Vector3(basketCollider.transform.position.x,basketCollider.transform.position.y,basketCollider.transform.position.z + randomZOffset);
            }
        }
    }
}
