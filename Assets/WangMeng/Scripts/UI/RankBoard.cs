using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Tetris{
public class RankBoard : MonoBehaviour {

	// Use this for initialization

	public GameObject[] RankElement;

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		List<PlayerInfo> listInfo=Manager.DB.GetAllMsg();

		if(listInfo==null) Manager.UI.AddTips("读取数据库失败");
		int count=  listInfo.Count<10 ? (listInfo.Count) : 10 ;

		for(int i=0;i<count;i++)
		{
			RankElement[i].transform.Find("name").GetComponent<Text>().text=listInfo[i].name;

			RankElement[i].transform.Find("Score").GetComponent<Text>().text=listInfo[i].score.ToString();
		}
	}
}
}