using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Tetris
{
    public class GameOver : MonoBehaviour
    {
        public GameObject Panel;
        // Use this for initialization
        void Start()
        {
            Manager.Event.AddListener<GameOverRaws>(GameOverEvent);
        }

        private void GameOverEvent(object sender, GameOverRaws e)
        {
            MainMenuManager.TweenOpenWithScale(Panel.transform);
        }
        public void BackToMenu()
        {
            DestroyImmediate(Manager.Game.gameObject);
            SceneManager.LoadScene("MainMenuwangmeng");
        }
  
        
    }

}