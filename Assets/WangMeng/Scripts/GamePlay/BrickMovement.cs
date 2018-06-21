using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{


    public class BrickMovement : MonoBehaviour
    {

        [SerializeField, SetProperty("MoveDistance")]
        private int _moveDistance;
        public int MoveDistance { get { return _moveDistance; } set { _moveDistance = value; } }

        [SerializeField, SetProperty("DropSpeed")]
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
                    BricksManager.DropEvent();
                }
                _canDropDown = value;
            }
        }

        public void OnActivate()
        {
            StartCoroutine(DropDown());
            BricksManager.AddDropEvent(DestroySelf);
        }

        IEnumerator DropDown()
        {
            //Debug.Log(123);
            yield return new WaitForSeconds(DropSpeed);
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
                yield break;
            }

            yield return DropDown();
        }

        public void OnUpdate()
        {
            Move();
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
            if (Input.GetKey(InputManager.Down))
            {
                BricksManager.Instance.AccelerateDown(this, 0.02f);
            }
            else if (Input.GetKeyUp(InputManager.Down))
            {
                BricksManager.Instance.AccelerateDown(this, 1);
            }

            if (Input.GetKeyDown(InputManager.ChangeShape))
            {
                BricksManager.Instance.ClearPreValue(transform);

                Vector3 prePos = transform.position;
                Vector3 preRot = transform.eulerAngles;

                if (BricksManager.Instance.CanChangeShape(transform))
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
            transform.Rotate(Vector3.forward, 90, Space.World);
            transform.position = prePos;
        }

        private void DestroySelf()
        {
            if (transform.childCount == 0)
                Destroy(gameObject);
        }

    }

}