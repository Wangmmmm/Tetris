using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{
    public class MenuState : State
    {

        public override void OnActivate()
        {
            Manager.Event.OnActivate();
            Manager.UI.OnActivate();
            Manager.Game.SetState(new GamePlayState());
            //Manager.Game.SetState(new CooperateState());

        }
        public override void OnDeactivate()
        {

        }

        public override void OnUpdate()
        {

        }

    }
}