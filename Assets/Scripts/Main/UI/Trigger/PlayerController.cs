using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _MoveVector = Vector3.zero;
    private ReactorObject _ReactorObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ReactorObject = collision.gameObject.GetComponent<ReactorObject>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _ReactorObject = null;
    }

    private void Update()
    {
        DetectKeyboard();
    }

    private void DetectKeyboard()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
            Move(MoveType.UpLeft);
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
            Move(MoveType.UpRight);
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
            Move(MoveType.DownLeft);
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            Move(MoveType.DownRight);
        else if (Input.GetKey(KeyCode.UpArrow))
            Move(MoveType.Up);
        else if (Input.GetKey(KeyCode.DownArrow))
            Move(MoveType.Down);
        else if (Input.GetKey(KeyCode.LeftArrow))
            Move(MoveType.Left);
        else if (Input.GetKey(KeyCode.RightArrow))
            Move(MoveType.Right);
       
        if (Input.GetKeyDown(KeyCode.Space))
            RunReactor();
    }
        
    private void RunReactor()
    {
        if (_ReactorObject)
        {
            _ReactorObject.Reactor.Run();
        }
    }

    private void Move(MoveType moveType)
    {
        switch (moveType)
        {
            case MoveType.Up:
                _MoveVector.y = 1 * GameConfig.PlayerMoveBase;
                break;
            case MoveType.Down:
                _MoveVector.y = -1 * GameConfig.PlayerMoveBase;
                break;
            case MoveType.Left:
                _MoveVector.x= -1 * GameConfig.PlayerMoveBase;
                break;
            case MoveType.Right:
                _MoveVector.x = 1 * GameConfig.PlayerMoveBase;
                break;
            case MoveType.UpLeft:
                _MoveVector.x = -1 * GameConfig.PlayerMoveBase;
                _MoveVector.y = 1 * GameConfig.PlayerMoveBase;
                break;
            case MoveType.UpRight:
                _MoveVector.x = 1 * GameConfig.PlayerMoveBase;
                _MoveVector.y = 1 * GameConfig.PlayerMoveBase;
                break;
            case MoveType.DownLeft:
                _MoveVector.x = -1 * GameConfig.PlayerMoveBase;
                _MoveVector.y = -1 * GameConfig.PlayerMoveBase;
                break;
            case MoveType.DownRight:
                _MoveVector.x = 1 * GameConfig.PlayerMoveBase;
                _MoveVector.y = -1 * GameConfig.PlayerMoveBase;
                break;
        }

        transform.localPosition += _MoveVector;
        _MoveVector.x = 0;
        _MoveVector.y = 0;
        _MoveVector.z = 0;
    }

    private enum MoveType
    {
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
    }
}
