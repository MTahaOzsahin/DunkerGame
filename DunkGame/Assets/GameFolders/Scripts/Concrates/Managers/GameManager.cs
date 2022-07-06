using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DunkGame.Concrates.Managers
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        [SerializeField] GameObject scorePanel;

        private void OnEnable()
        {
            ScoreController.Instance.scoreAction += ScorePanelStarter;
        }
        private void OnDisable()
        {
            ScoreController.Instance.scoreAction -= ScorePanelStarter;
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
        public void QuitGame()
        {
            Application.Quit();
        }
        public void RestartGame()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
