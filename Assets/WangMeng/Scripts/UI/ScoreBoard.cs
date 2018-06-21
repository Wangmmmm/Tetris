using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Tetris{
public class ScoreBoard : MonoBehaviour {

	[SerializeField]
	private GameObject Score;
	[SerializeField]
	private GameObject HighScore;
	[SerializeField]
	private GameObject ScoreContent;
	[SerializeField]
	private GameObject HighScoreContent;

	
	public void SetScoreContent(int currentScore,int addScore)
	{
		ScoreContent.GetComponent<Text>().text=(currentScore+addScore).ToString();

	}
	public void SetHighScoreContent(int currentScore,int addScore)
	{
		HighScoreContent.GetComponent<Text>().text=(currentScore+addScore).ToString();
	}




}

}