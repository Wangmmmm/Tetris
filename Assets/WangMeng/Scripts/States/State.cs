using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
public abstract class State  {

	public abstract void OnActivate();
	public abstract void OnDeactivate();
	public abstract void OnUpdate();

	public override string ToString()
	{
		return this.GetType().ToString();
	}
}
}