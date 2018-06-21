using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Tetris
{

    [System.Serializable]
    public class Col
    {
        public Transform[] raw = new Transform[20];
    }

    public class Vector2Ex
    {
        public static int GetInt(float arg)
        {
            return Mathf.RoundToInt(arg);
        }
    }

    public class BricksManager : MonoBehaviour
    {
        readonly int maxX = 10;
        readonly int maxY = 20;

        public static BricksManager Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        private static BricksManager _instance;
        //当方块无法再下降时的事件
        private static Action StopDropEvent;

        //存储当前界面方块位置
        public Col[] allGrid = new Col[10];
        //当前在移动的方块
        public Transform curBricks;

        public void OnActivate()
        {
            Instance = this;
            AddDropEvent(FullJudge);
        }




        /// <summary>
        /// 移动相关
        /// </summary>
        #region
        /// <summary>
        /// 能否继续下坠
        /// </summary>
        /// <param name="brick">父块</param>
        /// <returns></returns>
        public bool CanDropDown(Transform bricks)
        {
            foreach (Transform brick in bricks)
            {
                if (brick.name == "Anchor")
                    continue;

                int nextY = Vector2Ex.GetInt(brick.position.y) - 1;
                int curX = Vector2Ex.GetInt(brick.position.x);

                if (nextY < 0)
                {
                    Debug.Log("next pos is out border");
                    return false;
                }
                if (allGrid[curX].raw[nextY] != null)
                {
                    Debug.Log("next pos has brick");
                    return false;
                }
            }
            return true;
        }

        public bool CanLeftMove(Transform bricks)
        {
            foreach (Transform brick in bricks)
            {
                if (brick.name == "Anchor")
                    continue;

                int curY = Vector2Ex.GetInt(brick.position.y);
                int nextX = Vector2Ex.GetInt(brick.position.x) - 1;

                if (nextX < 0)
                    return false;
                if (allGrid[nextX].raw[curY] != null)
                    return false;
            }
            return true;
        }

        public bool CanChangeShape(Transform bricks, Vector3 anchor)
        {
            Vector3 prePos = bricks.position;
            Vector3 preRot = bricks.eulerAngles;
            bricks.RotateAround(anchor, Vector3.forward, 90);
            //bricks.position = prePos;

            foreach (Transform brick in bricks)
            {

                if (brick.name == "Anchor")
                    continue;

                int nextY = Vector2Ex.GetInt(brick.position.y);
                int nextX = Vector2Ex.GetInt(brick.position.x);

                if (nextX < 0 || nextY < 0 || nextX >= maxX || nextY > maxY)
                    return false;

                if (allGrid[nextX].raw[nextY] != null)
                    return false;

            }


            return true;
        }

        public bool CanRightMove(Transform bricks)
        {
            foreach (Transform brick in bricks)
            {

                if (brick.name == "Anchor")
                    continue;

                int curY = Vector2Ex.GetInt(brick.position.y);
                int nextX = Vector2Ex.GetInt(brick.position.x) + 1;

                if (nextX < 0 || nextX >= maxX)
                    return false;
                if (allGrid[nextX].raw[curY] != null)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 移动完之后更新存储数组
        /// </summary>
        /// <param name="bricks"></param>
        public void UpdateGrid(Transform bricks)
        {
            foreach (Transform brick in bricks)
            {
                if (brick.name == "Anchor")
                    continue;

                int realX = Vector2Ex.GetInt(brick.position.x);
                int realY = Vector2Ex.GetInt(brick.position.y);
                allGrid[realX].raw[realY] = brick;
            }
        }
        /// <summary>
        /// 方块移动前清除掉原来位置的存储内容
        /// </summary>
        /// <param name="bricks"></param>
        public void ClearPreValue(Transform bricks)
        {
            foreach (Transform brick in bricks)
            {
                if (brick.name == "Anchor")
                    continue;

                int realX = Vector2Ex.GetInt(brick.position.x);
                int realY = Vector2Ex.GetInt(brick.position.y);
                allGrid[realX].raw[realY] = null;
            }
        }
        #endregion

        /// <summary>
        /// 事件添加和调用
        /// </summary>
        #region
        public static void AddDropEvent(Action ac)
        {
            StopDropEvent += ac;
        }

        private static void ClearAction()
        {
            StopDropEvent = null;
        }

        public static void DropEvent()
        {
            if (StopDropEvent != null)
                StopDropEvent();
        }
        #endregion

        /// <summary>
        /// 消除相关
        /// </summary>
        #region
        //消除
        private void FullJudge()
        {
            List<int> fullRaws = IsFull();

            int fullRaw = 0;
            for (int i = 0; i < fullRaws.Count; i++)
            {
                fullRaw = fullRaws[i];
                //消除一行后每一行都向下移一行
                fullRaw -= i;

                ClearWhenFull(fullRaw);
            }
        }

        //返回满了的行数
        private List<int> IsFull()
        {
            List<int> results = new List<int>();

            bool isFull;

            for (int y = 0; y < maxY; y++)
            {
                isFull = true;
                for (int x = 0; x < maxX; x++)
                {
                    if (allGrid[x].raw[y] == null)
                    {
                        isFull = false;
                        break;
                    }
                }
                //存在一行已满
                if (isFull)
                {
                    results.Add(y);
                }

            }
            return results;
        }

        private void ClearWhenFull(int fullRaw)
        {
            for (int x = 0; x < maxX; x++)
            {
                if (allGrid[x].raw[fullRaw] != null)
                    Destroy(allGrid[x].raw[fullRaw].gameObject);
            }
            //满行之上的下移动
            for (int y = fullRaw + 1; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (allGrid[x].raw[y] != null)
                    {
                        allGrid[x].raw[y].position = allGrid[x].raw[y].position - new Vector3(0, 1, 0);
                        allGrid[x].raw[y - 1] = allGrid[x].raw[y];
                        allGrid[x].raw[y] = null;
                    }
                }
            }
        }
    }
    #endregion
}
