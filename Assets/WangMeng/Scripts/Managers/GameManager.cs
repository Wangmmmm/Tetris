using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{
    public class GameManager : MonoBehaviour
    {
        public GameObject Menu;
        public GameObject Game;

        public static string username;
        // Use this for initialization
        private State state;
        public State GameState
        {
            get
            {
                return state;
            }
        }


        private bool _isGameOver;
        public bool IsGameOver
        {
            get
            {
                return _isGameOver;
            }
            set
            {
                _isGameOver = value;
            }
        }

        public void SetState(State s)
        {
            if (state != null)
            {
                state.OnDeactivate();

            }
            state = s;
            if (state != null)
            {
                state.OnActivate();
            }
        }
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        public void OnActivate()
        {
            
           Manager.Event.AddListener<GameOverRaws>(GameOver);
           SetState(new MenuState());
        }
        // Update is called once per frame
        void Update()
        {
            state.OnUpdate();
        }

        private void GameOver(object o,GameOverRaws g)
        {
            IsGameOver = true;
        }

    }

}
