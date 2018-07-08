using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Tetris
{
    public class BlockState : State
    {
        public override void OnActivate()
        {
                 SceneManager.LoadScene("GamePlay");

            BlockManager.IsBlock=true;
            Manager.UI.OnActivate();
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