﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Tetris
{
    /// <summary>
    /// 方块生成器
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {

        //已经做好的预制体
        public GameObject[] bricks;

        //发射的位置坐标
        public Vector3 spawnPos;

        private bool _isSpawn;
        public bool IsSpawn
        {
            get
            {
                return _isSpawn;
            }
            set
            {
                _isSpawn = value;
            }
        }

        //生成器一但激活要做的事情
        public void OnActivate()
        {
            //向游戏逻辑管理器添加一个回调函数，当方块不能再下落时就执行该回调函数
            BricksManager.AddDropEvent(SpawnBricks);
<<<<<<< HEAD
            //一开始先执行一下，生成一个方块
            SpawnBricks();
        }
        
        
        //方块生成函数，随机实例化一个预制体
        private void SpawnBricks()
=======
            IsSpawn = true;
            Manager.Event.AddListener<GameOverRaws>(StopSpawn);
            SpawnBricks(Manager.Bricks.curBricks);
        }
        
        

        private void SpawnBricks(Transform trans)
>>>>>>> 3e1a5b27959d9bc746c5d532952cea46db015501
        {
            if (!IsSpawn)
                return;

            int index = UnityEngine.Random.Range(0, bricks.Length - 1);
            GameObject newBrick = GameObject.Instantiate(bricks[index]);
            newBrick.GetComponent<BrickMovement>().OnActivate();
            Manager.Bricks.curBricks = newBrick.transform;
            newBrick.transform.position = spawnPos;
        }

        private void StopSpawn(object o,GameOverRaws r)
        {
            IsSpawn = false;
        }

}


  
  

}