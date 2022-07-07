using DunkGame.Abstracts;
using DunkGame.Concrates.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class ObstacleController : MonoBehaviourSingleton<ObstacleController>, IMoveableObject
    {

        [Header("Movement Values")]
        [SerializeField] Vector3 direction = new Vector3(0,0,1);
        [SerializeField,Range(1f,10f)] float moveRange;
        [SerializeField] float moveRate = 2f;

        float moveTimer = 0f;
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponent<BallController>() != null)
            {
                GameManager.Instance.RestartGame();
            }
        }
        private void Update()
        {
            MoveObstacle();
        }
        public void MoveObstacle()
        {
            moveTimer += Time.deltaTime;
            if (moveTimer > moveRate)
            {
                transform.Translate(moveRange * Time.deltaTime * direction);
                if (moveTimer > moveRate * 2)
                {
                    transform.Translate(moveRange * Time.deltaTime * -direction * 2);
                    if (moveTimer > moveRate * 3)
                    {
                        moveTimer = 0f;
                    }
                }
            }
        }
    }
}
