using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
/// <summary>
/// 菜单栏状态
/// </summary>
public class MenuState : State {

	//该状态一旦进入，就把事件管理器和UI管理器，以及后期会添加的声音管理器，这些管理器是一开始就要用到的
	public override void OnActivate ()
	{
		Manager.Event.OnActivate();
		Manager.UI.OnActivate();


		//目前还未写菜单的逻辑，因此菜单状态一开始就进入GamePlay状态
		Manager.Game.SetState(new GamePlayState());
	}


	
	//在这里写菜单界面结束后要执行的逻辑，比如菜单栏UI关闭等，目前还未参加
	public override void OnDeactivate ()
	{
      
	}

	
	public override void OnUpdate ()
	{
      
	}
	
}
}