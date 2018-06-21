using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

}
