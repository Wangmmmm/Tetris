using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
    public class ButtonClick : MonoBehaviour
    {
        private int infinite = 1000;
        private float curDropSpeed=1;
        public void Pause()
        {
            if (!Manager.Bricks.IsPause)
            {
                Manager.Bricks.IsPause = true;
                BrickMovement curMovement = Manager.Bricks.curBricks.GetComponent<BrickMovement>();
                curDropSpeed = curMovement.DropSpeed;
                curMovement.DropSpeed = infinite;
            }
            else
            {
                Manager.Bricks.IsPause = false;
                Manager.Bricks.curBricks.GetComponent<BrickMovement>().DropSpeed = curDropSpeed;
            }
        }

        public void Setting()
        {
            
        }
   

    }
}