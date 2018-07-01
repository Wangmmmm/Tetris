using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour {

	public void Init()
	{
			ConnectToDatabase();
	}
	public void UnInit()
	{
		DisConnect();
	}

	

	void ConnectToDatabase()
	{
		Debug.Log(" Success to connect!!!!!");
	}

	void DisConnect()
	{
		Debug.Log(" Success to DisConnect!!!!!");
	}
	

}
