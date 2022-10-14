using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class ReactorObject : MonoBehaviour
{
    //物件外觀
    [SerializeField]
    private AppearanceEnum _AppearanceType = AppearanceEnum.None;

    //腳本類型
    [SerializeField]
    private ReactorEnum _ReactorType = ReactorEnum.None;

    //腳本
    private ReactorBase _Reactor;
    public ReactorBase Reactor { get { return _Reactor; } }

    //接觸提示
    private Image _ImgCollisionHint;

    public void Awake()
    {
        _Reactor = System.Activator.CreateInstance(System.Type.GetType(_ReactorType.ToString())) as ReactorBase;
        CreateCollisionHint();
    }

    private void CreateCollisionHint()
    {
        if (GameConfig.EnableCollisionHint == false) return;

        GameObject goCollisionHint = new GameObject();
        goCollisionHint.name = "CollisionHint";
        goCollisionHint.transform.SetParent(transform);

        RectTransform rectTransform = goCollisionHint.AddComponent<RectTransform>();
        rectTransform.sizeDelta = transform.GetComponent<RectTransform>().sizeDelta;

        goCollisionHint.transform.localScale = Vector3.one;
        goCollisionHint.transform.localPosition = Vector3.zero;

        _ImgCollisionHint = goCollisionHint.AddComponent<Image>();
        _ImgCollisionHint.color = new Color(116,233,107,(float)34/255);
        _ImgCollisionHint.enabled = false;
    }

    private void EnableCollisionHint(bool isEnabled)
    {
        if (GameConfig.EnableCollisionHint == false) return;
        _ImgCollisionHint.enabled = isEnabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnableCollisionHint(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        EnableCollisionHint(false);
    }
}
