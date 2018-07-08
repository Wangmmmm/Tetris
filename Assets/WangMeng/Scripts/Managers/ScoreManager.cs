using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
    /// <summary>
    /// 分数管理器，提供了一个分数和历史最高分数管理的计算方法，并且给UI显示分数模块发送信息
    /// </summary>
public class ScoreManager : MonoBehaviour {

    //这个SerializeField让修饰的私有变量也能显示在Inspector视图上
    [SerializeField]
    private int addScoreUnit=10;//该变量表示没消除一格就添加的分数

    //当前的分数
    private int currentScore;

    //历史最高分数
    private int highScore;

    //分数管理器的初始化工作
    public void OnActivate()
    {
        //注册回调函数，该函数将会在方块消失时执行,并传递一个消失行数的统计
        Manager.Event.AddListener<FullRaws>(ClearEvent);

    
        //初始化分数面板
        Init();
    }

    //被注册的回调函数，该函数将会在方块消失时执行,并传递一个消失行数的统计
    public void ClearEvent(object sender,FullRaws f)
	{
		AddScore(f.count);
	}
    

    //分数添加函数，参数是清除的方块行数
    public void AddScore(int clearLineCount)
    {
        //向UI组件传递信息，更新UI的分数面板
        Manager.UI.Score.SetScoreContent(currentScore,clearLineCount*addScoreUnit);

        //计算之后的分数
        currentScore+=clearLineCount*addScoreUnit;

        //计算是否需要更新历史最高分
        if(currentScore>highScore)
        {
            Manager.UI.Score.SetHighScoreContent(highScore,currentScore-highScore);
            highScore=currentScore;
                Manager.DB.UpdateMessage(Tetris.GameManager.username, highScore);
            }
    }
    public void Init()
    {
        currentScore=0;
        highScore=LoadHighScore();

        Manager.UI.Score .SetScoreContent(0,0);


        Manager.UI.Score.SetHighScoreContent(0,LoadHighScore());

    }
    //从数据库或者服务器读取历史最高分
    public int LoadHighScore()
    {
           return Manager.DB.FindScore(Tetris.GameManager.username);
       // return 0;
    }
	
	
}
}