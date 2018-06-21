using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
/// <summary>
/// 控制游戏的状态的抽象基类
/// </summary>
public abstract class State  {

	//一个状态的进入
	public abstract void OnActivate();

	//一个状态的离开
	public abstract void OnDeactivate();

	//一个状态的逐帧进行
	public abstract void OnUpdate();

	public override string ToString()
	{
		return this.GetType().ToString();
	}
}
}