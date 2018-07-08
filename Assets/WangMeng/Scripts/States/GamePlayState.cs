using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Tetris
{
    public class GamePlayState : State
    {

        public override void OnActivate()
        {
             SceneManager.LoadScene("GamePlay");
            Manager.UI.OnActivate();
            Manager.Spawn.OnActivate();
            Manager.Bricks.OnActivate();
            Manager.Score.OnActivate();

            //Manager.Bricks.curBricks.GetComponent<BrickMovement>().OnActivate();
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