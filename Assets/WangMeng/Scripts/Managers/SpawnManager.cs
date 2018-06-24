using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Tetris
{
    public class SpawnManager : MonoBehaviour
    {

        public GameObject[] bricks;
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

        public void OnActivate()
        {
            BricksManager.AddDropEvent(SpawnBricks);
            IsSpawn = true;
            Manager.Event.AddListener<GameOverRaws>(StopSpawn);
            SpawnBricks(Manager.Bricks.curBricks);
        }
        
        

        private void SpawnBricks(Transform trans)
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