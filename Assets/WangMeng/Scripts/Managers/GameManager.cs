using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
namespace Tetris{
/// <summary>
/// 游戏流程控制器
/// </summary>
public class GameManager : MonoBehaviour {

	//游戏逻辑所持有的状态机
	private State state;
	public State GameState{
		get {
			return state;
		}
	}

	//切换状态的方法
	public void SetState(State s)
	{
		if(state!=null)
		{
			state.OnDeactivate();
			
		}
		state=s;
		if (state != null)
		{
			state.OnActivate();
		}
	}

	//游戏一开始就自动执行一次，将状态初始化为MenuState
	void Start()
	{
		SetState(new MenuState());
	}

	// 游戏会逐帧自动调用，用来更新状态
	void Update () {
		state.OnUpdate();
	}
	
}
=======
namespace Tetris
{
    public class GameManager : MonoBehaviour
    {

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
        void Start()
        {
            SetState(new MenuState());
            Manager.Event.AddListener<GameOverRaws>(GameOver);
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
>>>>>>> 3e1a5b27959d9bc746c5d532952cea46db015501

}
