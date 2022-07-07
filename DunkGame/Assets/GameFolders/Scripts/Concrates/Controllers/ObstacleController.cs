using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class ObstacleController : MonoBehaviour
    {
        [Header("Movement Values")]
        [SerializeField] Vector3 direction;
        [SerializeField, Range(0,2)] float moveSpeed;
        [SerializeField, Range(0, 2)] float moveRate;
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponent<BallController>() != null)
            {
                Debug.Log("a");
            }
        }
        private void Start()
        {
            StartCoroutine(MovingObstacle());
        }
        IEnumerator MovingObstacle()
        {
            while (true)
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);
                yield return new WaitForSeconds(moveRate);
                transform.Translate(-direction * moveSpeed * Time.deltaTime);
                yield return new WaitForSeconds(moveRate);
            }
        }
    }
}
