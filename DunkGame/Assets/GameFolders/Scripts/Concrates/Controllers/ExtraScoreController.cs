using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunkGame.Concrates.Controllers
{
    public class ExtraScoreController : MonoBehaviour
    {
        [SerializeField] GameObject extraScorePanel;
        private void OnTriggerEnter(Collider collider) // Can be added partucle effect here if wanted.
        {
            if (collider.GetComponent<BallController>() != null)
            {
                ScorePanelStarter();
            }
        }
        void ScorePanelStarter()
        {
            StartCoroutine(ScorePanel());
        }
        public IEnumerator ScorePanel()
        {
            extraScorePanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            extraScorePanel.SetActive(false);
            this.gameObject.SetActive(false);

        }
    }
}
