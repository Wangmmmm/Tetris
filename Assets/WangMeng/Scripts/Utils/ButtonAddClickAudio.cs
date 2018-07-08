using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Tetris{
public class ButtonAddClickAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {



		foreach(Button btn in transform.GetComponentsInChildren<Button>(true))
		{
			btn.
			onClick.
			AddListener(()=>
			Manager.
			Audio.
			PlayUIClick());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}