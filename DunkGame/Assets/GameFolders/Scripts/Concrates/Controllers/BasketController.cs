using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class BasketController : MonoBehaviourSingleton<BasketController>
    {
        public event System.Action scoreAction;

        [Header("Shake Effect variables")]
        [SerializeField] float duration = 0.5f;
        [SerializeField] float strenght = 0.5f;
        [SerializeField] int vibrato = 10;
        [SerializeField] float randomness = 50f;
        [SerializeField] bool sanpping = true;
        [SerializeField] bool fadeOut = true;

        [SerializeField] GameObject scorePanel;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BallController>() != null && collision.GetContact(0).normal.y < -0.2f)
            {
                scoreAction?.Invoke();
                BasketScoreEffect();
                ScorePanelStarter();
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
    }
}
