using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private int addScoreUnit=10;

    private int currentScore;

    private int highScore;
    public void OnActivate()
    {

        Manager.Event.AddListener<FullRaws>(ClearEvent);
        Init();
    }
    public void ClearEvent(object sender,FullRaws f)
	{
		AddScore(f.count);
	}
    public void AddScore(int clearLineCount)
    {
        Manager.UI.Score.SetScoreContent(currentScore,clearLineCount*addScoreUnit);
        currentScore+=clearLineCount*addScoreUnit;
        if(currentScore>highScore)
        {
            Manager.UI.Score.SetHighScoreContent(highScore,currentScore-highScore);
            highScore=currentScore;
        }
    }
    public void Init()
    {
         currentScore=highScore=0;
         Manager.
         UI
         .Score
         .SetScoreContent(0,0);
         Manager.UI.Score.SetHighScoreContent(0,LoadHighScore());

    }
    public int LoadHighScore()
    {
        return 0;
    }
	
	
}
}