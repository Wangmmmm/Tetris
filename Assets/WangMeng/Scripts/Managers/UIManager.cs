using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace Tetris{
	/// <summary>
	/// UI管理器
	/// </summary>
public class UIManager : MonoBehaviour {

	//所有UI组件都在一个Canvas(画布下),是它的子物体，所以想要找到这些组件，可以通过Canvas物体来找
	public GameObject Canvas;


	public GameObject Tip;

	//游戏一开始就执行，找到画布
	public void OnActivate()
	{
		Canvas=GameObject.Find("Canvas");

		//将score引用到游戏中的ScoreBoard组件上
		score= Canvas.transform.GetComponentInChildren<ScoreBoard>();

         
                OpenSourceImg.SetActive(Manager.Audio.IsOpen);
                CloseSourceImg.SetActive(!Manager.Audio.IsOpen);

         
        
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


	public void AddTips(string text)
	{
		if(text==null||text=="")return;
		var tip=Instantiate(Tip) as GameObject;

		tip.GetComponentInChildren<Text>().text=text;

	}
        public GameObject pauseImg;
        public GameObject continueImg;
    public void PauseBtn()
    {   
            
            
            Time.timeScale = 1 - Time.timeScale;

            if (Time.timeScale == 1)
            {
                pauseImg.SetActive(true);
                continueImg.SetActive(false);
            }
            else
            {
                pauseImg.SetActive(false);
                continueImg.SetActive(true);
            }

    }
        public GameObject OpenSourceImg;
        public GameObject CloseSourceImg;
        public void SourceBtn()
        {
            OpenSourceImg.SetActive(!Manager.Audio.IsOpen);
            CloseSourceImg.SetActive(Manager.Audio.IsOpen);
            Manager.Audio.SetAudioSwitch(!Manager.Audio.IsOpen);


        }
        public GameObject RankBtn;
        public GameObject CloseRankBtn;
        public GameObject RankBoard;
        public void OnRankBtn()
        {
            Time.timeScale = 0;
            pauseImg.transform.parent.GetComponent<Button>().interactable = false;
            MainMenuManager. TweenOpenWithScale(RankBoard.transform);
            RankBtn.gameObject.SetActive(false);
            CloseRankBtn.gameObject.SetActive(true);
        }
        public void OnRankCloseBtn()
        {
            pauseImg.transform.parent.GetComponent<Button>().interactable = true;
            Time.timeScale = 1;
            MainMenuManager.TweenCloseWithScale(RankBoard.transform);
            RankBtn.gameObject.SetActive(true);
            CloseRankBtn.gameObject.SetActive(false);
        }
    }
}