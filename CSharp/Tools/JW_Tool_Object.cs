using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class JW_Tool_Object : MonoBehaviour
{
    [SerializeField]
    private ObjectType _ObjectType;
    public ObjectType ObjectType { get { return _ObjectType; } }
}
