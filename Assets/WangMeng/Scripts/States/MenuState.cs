using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{
    public class MenuState : State
    {

        public override void OnActivate()
        {
            
           // Manager.Game.SetState(new GamePlayState());
          
            //Manager.Game.SetState(new CooperateState());
            //Manager.Game.SetState(new BlockState());
        }
        public override void OnDeactivate()
        {
            Manager.Game.Menu.SetActive(false);
        }

        public override void OnUpdate()
        {

        }

    }
}