using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DunkGame.Concrates.Managers
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public void StartGame()
        {
            SceneManager.LoadSceneAsync(1);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        public void RestartGame()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        public void MainMenu()
        {
            SceneManager.LoadSceneAsync(0);
        }
        public void SelectLevel(int index)
        {
            SceneManager.LoadSceneAsync(index);
        }
        public void NextLevel()
        {
            StartCoroutine(NextLevelCoroutine());
        }
        IEnumerator NextLevelCoroutine()
        {
            if (SceneManager.GetActiveScene().buildIndex == 6) yield return null;
            yield return new WaitForSeconds(3f);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
