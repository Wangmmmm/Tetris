using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Tip : MonoBehaviour {



	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{

		transform.GetComponent<Image>().DOFade(0.5f,0.3f).
		OnComplete(()=>transform.GetComponent<Image>().DOFade(0.5f,1).
		OnComplete(()=>transform.GetComponent<Image>().DOFade(0,1)));
		

		transform.GetComponentInChildren<Text>().DOFade(1f,0.3f).
		OnComplete(()=>transform.GetComponentInChildren<Text>().DOFade(1f,1).
		OnComplete(()=>transform.GetComponentInChildren<Text>().DOFade(0,1).
		OnComplete(()=>Destroy(transform.parent.gameObject))));
	

	
	}

}
