using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class PassableObjectsController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BallController>() != null)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<BallController>() != null)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
