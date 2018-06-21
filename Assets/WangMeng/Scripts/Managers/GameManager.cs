using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
public class GameManager : MonoBehaviour {

	// Use this for initialization
	private State state;
	public State GameState{
		get {
			return state;
		}
	}

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
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		SetState(new GamePlayState());
	}
	// Update is called once per frame
	void Update () {
		state.OnUpdate();
	}
	
}

}
