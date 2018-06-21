using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
/// <summary>
/// 游戏开始玩时的状态
/// </summary>
public class GamePlayState : State {

	//游戏开始玩时要做的事情，比如准备好方块生成器，以及游戏逻辑控制器，以及分数管理器
	public override void OnActivate ()
	{
		Manager.Spawn.OnActivate();
		Manager.Bricks.OnActivate();
		Manager.Score.OnActivate();
		
	}
	//游玩结束时要做的事情，比如暂停方块生成等，目前还没完成
	public override void OnDeactivate ()
	{
      
	}

	//游戏开始玩时要逐帧调用的事件，在本例就是控制当前的方块的逐帧移动
	public override void OnUpdate ()
	{
      Manager.Bricks.curBricks.GetComponent<BrickMovement>().OnUpdate();
	}
}

}