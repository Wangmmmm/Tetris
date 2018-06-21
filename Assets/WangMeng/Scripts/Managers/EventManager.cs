using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEvent;
using System;
public class EventManager : MonoBehaviour {

	private MyEvent.EventSystem eventSystem;
	public void OnActivate()
	{
		eventSystem=new MyEvent.EventSystem();
	}
	public void OnDeactivate ()
	{

	}
	public void AddListener<T>(EventDelegate<T> listener)where T : EventArgs
	{
		eventSystem.AddListener(listener);
	}

	public void RemoveListener<T>(EventDelegate<T> listener) where T : EventArgs
	{
		eventSystem.RemoveListener(listener);
	}
	public void Raise<T>(object sender,T e) where T : EventArgs
	{
		eventSystem.Raise(sender,e);
	}
	
}
