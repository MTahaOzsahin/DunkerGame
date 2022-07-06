using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class ScoreController : MonoBehaviourSingleton<ScoreController>
    {
        public event System.Action scoreAction;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BallController>() != null && collision.GetContact(0).normal.y < -0.2f)
            {
                scoreAction?.Invoke();
            }
        }
    }
}
