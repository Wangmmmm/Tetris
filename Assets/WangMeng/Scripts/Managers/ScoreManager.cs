﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private int addScoreUnit=10;

    private int currentScore;

    private int highScore;
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
	
	
}
}