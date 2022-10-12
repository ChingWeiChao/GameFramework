using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class JW_Tool_PlayerEventTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        JW_Tool_Logger.Log(gameObject.name + "Collision Hit 2D");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        JW_Tool_Logger.Log(gameObject.name + "Trigger Hit 2D");
        TriggerEvent(collision.gameObject.GetComponent<JW_Tool_Object>());
    }
    private void TriggerEvent(JW_Tool_Object  obj)
    {
        switch (obj.ObjectType)
        {
            case ObjectType.SolidItem:
                break;
        }
    }
}
