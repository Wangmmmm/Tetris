using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Tetris{
	/// <summary>
	/// UI管理器
	/// </summary>
public class UIManager : MonoBehaviour {

	//所有UI组件都在一个Canvas(画布下),是它的子物体，所以想要找到这些组件，可以通过Canvas物体来找
	public GameObject Canvas;

	//游戏一开始就执行，找到画布
	public void OnActivate()
	{
		Canvas=GameObject.Find("Canvas");

		//将score引用到游戏中的ScoreBoard组件上
		score= Canvas.transform.GetComponentInChildren<ScoreBoard>();
	}
	

	//专门管理分数板UI的变量
	private ScoreBoard score;
	public ScoreBoard Score{
		get{
			return score;
		}
	}

	public void OnDeactive()
	{

	}
	
}
}