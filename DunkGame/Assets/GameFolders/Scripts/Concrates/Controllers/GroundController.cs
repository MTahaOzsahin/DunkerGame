using DunkGame.Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class GroundController : MonoBehaviour, IGrounderController
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<BallController>() != null)
            {
                collision.rigidbody.AddForce(new Vector3(0f, 190.6f, 0f));
                Debug.Log("a");
            }
        }
        // This method can be use for bounce any target that hit the ground if wanted. For now above method will be quicker.
        public void Bouncer(Rigidbody targetRigibody) 
        {

        }
    }
}
