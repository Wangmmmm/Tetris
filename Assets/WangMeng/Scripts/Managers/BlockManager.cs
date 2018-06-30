using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
    public class BlockManager : MonoBehaviour
    {

        public Transform Grids;
        private Transform[] allGridsBG;
        public int randomCount = 1;

        void Start()
        {
            SpawnBlock();
        }

        void SpawnBlock()
        {
            allGridsBG = Grids.GetComponentsInChildren<Transform>();
            int x, y;
            int randomIndex;

            for (int i = 0; i < randomCount; i++)
            {
                do
                {
                    randomIndex = Random.Range(0, allGridsBG.Length);
                    x = (int)allGridsBG[randomIndex].transform.position.x;
                    y = (int)allGridsBG[randomIndex].transform.position.y;
                } while (y > 10);

                allGridsBG[randomIndex].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject newBlock = new GameObject("Block");
                newBlock.tag = AllString.Tags.Block;
                Manager.Bricks.allGrid[x].raw[y] = newBlock.transform;
            }
        }
    }
}