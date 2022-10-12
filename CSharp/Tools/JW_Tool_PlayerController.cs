using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JW_Tool_PlayerController : MonoBehaviour
{
    private Vector3 _MoveVector = Vector3.zero;
    private  enum MoveType
    {
        Up = 1,
        Down=2,
        Left=3,
        Right=4,
    }
    private void DetectMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Move(MoveType.Up);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            Move(MoveType.Down);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            Move(MoveType.Left);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            Move(MoveType.Right);
    }
    private void Move(MoveType moveType)
    {
        switch (moveType)
        {
            case MoveType.Up:
                JW_Tool_Logger.Log("Player Move Up");
                _MoveVector.y = 1;
                UpdatePlayer();
                break;
            case MoveType.Down:
                JW_Tool_Logger.Log("Player Move Down");
                _MoveVector.y = -1;
                UpdatePlayer();
                break;
            case MoveType.Left:
                JW_Tool_Logger.Log("Player Move Left");
                _MoveVector.x= -1;
                UpdatePlayer();
                break;
            case MoveType.Right:
                JW_Tool_Logger.Log("Player Move Right");
                _MoveVector.x = 1;
                UpdatePlayer();
                break;
        }
    }
    private void UpdatePlayer()
    {
        transform.localPosition += _MoveVector;
        _MoveVector.x = 0;
        _MoveVector.y = 0;
        _MoveVector.z = 0;
    }
    private void Update()
    {
        DetectMove();
    }
}
