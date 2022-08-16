using DG.Tweening;
using DunkGame.Abstracts;
using DunkGame.Concrates.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class BasketController : MonoBehaviourSingleton<BasketController>, IMoveableObject
    {
        // Main basket controller script. Shake effect and ui can be moved another script if wanted.

        public event System.Action scoreAction;

        [Header("Shake Effect variables")]
        [SerializeField] float duration = 0.5f;
        [SerializeField] float strenght = 0.5f;
        [SerializeField] int vibrato = 10;
        [SerializeField] float randomness = 50f;
        [SerializeField] bool sanpping = true;
        [SerializeField] bool fadeOut = true;

        [SerializeField] GameObject scorePanel;

        [Header("Movement Values")]
        [SerializeField] bool isMove = false;
        [SerializeField] Vector3 direction = new Vector3(0, 0, 1);
        [SerializeField, Range(1f, 10f)] float moveRange;
        [SerializeField] float moveRate = 2f;

        float moveTimer = 0f;

        private void Update()
        {
            MoveObstacle();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BallController>() != null && collision.GetContact(0).normal.y < -0.2f)
            {
                scoreAction?.Invoke();
                BasketScoreEffect();
                ScorePanelStarter();
                GameManager.Instance.NextLevel();
            }
        }
        void BasketScoreEffect()
        {
            transform.DOShakePosition(duration, strenght, vibrato, randomness, sanpping, fadeOut);
        }
        void ScorePanelStarter()
        {
            StartCoroutine(ScorePanel());
        }
        public IEnumerator ScorePanel()
        {
            scorePanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            scorePanel.SetActive(false);
        }

        public void MoveObstacle()
        {
            if (!isMove) return;
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
