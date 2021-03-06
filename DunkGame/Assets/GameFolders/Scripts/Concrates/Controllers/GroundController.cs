using DunkGame.Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class GroundController : MonoBehaviour, IGrounderController
    {
        //This script makes fake gravity to ball for better feeling
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<BallController>() != null)
            {
                collision.rigidbody.AddForce(new Vector3(0f, 890.6f, 0f));
            }
        }
        // This method can be use for bounce any target that hit the ground if wanted. For now above method will be quicker.
        public void Bouncer(Rigidbody targetRigibody) 
        {

        }
    }
}
