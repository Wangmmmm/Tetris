using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Tetris{
public class UIManager : MonoBehaviour {

	public GameObject Canvas;
	public void OnActivate()
	{
		Canvas=GameObject.Find("Canvas");
		score= Canvas.transform.GetComponentInChildren<ScoreBoard>();
	}

	private ScoreBoard score;
	public ScoreBoard Score{
		get{
			return score;
		}
	}
	public void PauseButtonEvent()
	{
		Time.timeScale=1-Time.timeScale;
	}
	public void OnDeactive()
	{

	}
	
}
}