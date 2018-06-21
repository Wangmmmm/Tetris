using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
public class TetrisShape : MonoBehaviour {

	[SerializeField, SetProperty ("TetrisColor")]
	private Color m_color;

	public Color TetrisColor{
		set{
			m_color=value;
			//Debug.Log(23);
			InitColor( value);
		}
		get{
			return m_color;
		}
	}

	// Use this for initialization
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		//InitColor();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitColor(Color col)
	{
		Debug.Log(23);
		SpriteRenderer[] rends=GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer rend in rends)
		{
			rend.color=col;
		}
	}
}
}