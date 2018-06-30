using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
    public class BlockState : State
    {
        public override void OnActivate()
        {
            BlockManager.IsBlock=true;
            Manager.Spawn.OnActivate();
            Manager.Bricks.OnActivate();
            Manager.Score.OnActivate(); ;
        }

        public override void OnDeactivate()
        {
      
        }

        public override void OnUpdate()
        {
            Manager.Bricks.curBricks.GetComponent<BrickMovement>().OnUpdate();
        }
    }
}