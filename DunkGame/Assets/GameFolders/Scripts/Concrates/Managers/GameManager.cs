using DunkGame.Concrates.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DunkGame.Concrates.Managers
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
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
