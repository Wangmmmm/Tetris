using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
public class GamePlayState : State {

	public override void OnActivate ()
	{
		Manager.Spawn.OnActivate();
		Manager.Bricks.OnActivate();
		//Manager.Bricks.curBricks.GetComponent<BrickMovement>().OnActivate();
	}
	public override void OnDeactivate ()
	{
      
	}

	public override void OnUpdate ()
	{
      Manager.
	  Bricks.
	  curBricks.
	  GetComponent<BrickMovement>().
	  OnUpdate();
	}
}

}