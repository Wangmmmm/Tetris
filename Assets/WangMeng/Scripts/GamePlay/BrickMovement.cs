using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{
    public class BrickMovement : MonoBehaviour
    {

        public static bool isCooperate;
        public enum ControlState
        {
            player1,
            player2
        }

        private static ControlState _controller;
        public static ControlState Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                if (_controller == ControlState.player1)
                    _controller = ControlState.player2;
                else
                    _controller = ControlState.player1;
            }
        }

        public Transform rotateAnchor;

        [SerializeField, SetProperty("MoveDistance")]
        private int _moveDistance;
        public int MoveDistance { get { return _moveDistance; } set { _moveDistance = value; } }

        private float _dropSpeed;
        public float DropSpeed
        {
            get
            {
                return _dropSpeed;
            }
            set
            {
                _dropSpeed = value;
            }
        }

        [SerializeField, SetProperty("CanDropDown")]
        private bool _canDropDown;
        public bool CanDropDown
        {
            get
            {
                return _canDropDown;
            }
            set
            {
                //不能再下坠
                if (value == false)
                {
                    enabled = false;
                    BricksManager.DropEvent(transform);
                }
                _canDropDown = value;
            }
        }

        private float timer = 0;//下坠计时器
        private float curGameSpeed;

        public void OnActivate()
        {
            rotateAnchor = transform.Find("Anchor");
            BricksManager.AddDropEvent(DestroySelf);
            BricksManager.AddDropEvent((Transform) => { Controller = ControlState.player2; });
            DropSpeed = Manager.Bricks.DropSpeed;
            curGameSpeed = DropSpeed;
        }

        void FreeDropDown()
        {
            timer += Time.deltaTime;
            if (timer > DropSpeed)
            {
                Debug.Log(gameObject.name);
                Manager.Audio.PlayDropSound();
                timer = 0;
                BricksManager.Instance.ClearPreValue(transform);
                if (BricksManager.Instance.CanDropDown(transform))
                {
                    Vector3 nextPos = transform.position - new Vector3(0, 1, 0);
                    transform.position = nextPos;
                    CanDropDown = true;
                    BricksManager.Instance.UpdateGrid(transform);
                }
                else
                {
                    //一下两行代码执行的顺序影响满行的判断，不能更改
                    BricksManager.Instance.UpdateGrid(transform);
                    CanDropDown = false;
                }
            }
        }

        public void OnUpdate()
        {
            if (Manager.Game.IsGameOver)
                return;

            if (!isCooperate)
            {
                Move();
            }
            else
            {
                CooperateMove();
            }
        }

        private void CooperateMove()
        {
            if (Controller == ControlState.player2)
            {
                Move();
            }
            else
            {
                if (Input.GetKeyDown(InputManager.Left_s))
                {
                    BricksManager.Instance.ClearPreValue(transform);

                    if (BricksManager.Instance.CanLeftMove(transform))
                    {
                        Vector3 nextPos = transform.position - new Vector3(1, 0, 0);
                        transform.position = nextPos;
                    }

                    BricksManager.Instance.UpdateGrid(transform);
                }
                else if (Input.GetKeyDown(InputManager.Right_s))
                {
                    BricksManager.Instance.ClearPreValue(transform);

                    if (BricksManager.Instance.CanRightMove(transform))
                    {
                        Vector3 nextPos = transform.position + new Vector3(1, 0, 0);
                        transform.position = nextPos;
                    }

                    BricksManager.Instance.UpdateGrid(transform);
                }

                if (Input.GetKeyDown(InputManager.Down_s))
                {
                    DropSpeed = curGameSpeed * 0.05f;
                }
                else if (Input.GetKeyUp(InputManager.Down_s))
                {
                    DropSpeed = curGameSpeed;
                }
                FreeDropDown();

                if (Input.GetKeyDown(InputManager.ChangeShape_s))
                {
                    BricksManager.Instance.ClearPreValue(transform);

                    Vector3 prePos = transform.position;
                    Vector3 preRot = transform.eulerAngles;

                    if (BricksManager.Instance.CanChangeShape(transform, rotateAnchor.position))
                    {
                        transform.eulerAngles = preRot;
                        transform.position = prePos;
                        ChangeShape();
                    }
                    else
                    {
                        transform.eulerAngles = preRot;
                        transform.position = prePos;
                    }

                    BricksManager.Instance.UpdateGrid(transform);
                }
            }
        }

        private void Move()
        {
            if (Input.GetKeyDown(InputManager.Left))
            {
                BricksManager.Instance.ClearPreValue(transform);

                if (BricksManager.Instance.CanLeftMove(transform))
                {
                    Vector3 nextPos = transform.position - new Vector3(1, 0, 0);
                    transform.position = nextPos;
                }

                BricksManager.Instance.UpdateGrid(transform);
            }
            else if (Input.GetKeyDown(InputManager.Right))
            {
                BricksManager.Instance.ClearPreValue(transform);

                if (BricksManager.Instance.CanRightMove(transform))
                {
                    Vector3 nextPos = transform.position + new Vector3(1, 0, 0);
                    transform.position = nextPos;
                }

                BricksManager.Instance.UpdateGrid(transform);
            }

            if (Input.GetKeyDown(InputManager.Down))
            {
                DropSpeed = curGameSpeed * 0.05f;
            }
            else if (Input.GetKeyUp(InputManager.Down))
            {
                DropSpeed = curGameSpeed;
            }
            FreeDropDown();

            if (Input.GetKeyDown(InputManager.ChangeShape))
            {
                BricksManager.Instance.ClearPreValue(transform);

                Vector3 prePos = transform.position;
                Vector3 preRot = transform.eulerAngles;

                if (BricksManager.Instance.CanChangeShape(transform, rotateAnchor.position))
                {
                    transform.eulerAngles = preRot;
                    transform.position = prePos;
                    ChangeShape();
                }
                else
                {
                    transform.eulerAngles = preRot;
                    transform.position = prePos;
                }

                BricksManager.Instance.UpdateGrid(transform);
            }
        }

        private void ChangeShape()
        {
            Vector3 prePos = transform.position;
            transform.RotateAround(rotateAnchor.position, Vector3.forward, 90);
        }

        private void DestroySelf(Transform trans)
        {
            if (transform.childCount == 0)
                Destroy(gameObject);
        }

    }

}