using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{
    public class SpawnManager : MonoBehaviour
    {

        public GameObject[] bricks;
        public Vector3 spawnPos;


        public void OnActivate()
        {
            BricksManager.AddDropEvent(SpawnBricks);
            SpawnBricks();
        }

        private void SpawnBricks()
        {
            int index = Random.Range(0, bricks.Length - 1);
            GameObject newBrick = GameObject.Instantiate(bricks[index]);
            newBrick.GetComponent<BrickMovement>().OnActivate();
            Manager.Bricks.curBricks = newBrick.transform;
            newBrick.transform.position = spawnPos;
        }
    }

}