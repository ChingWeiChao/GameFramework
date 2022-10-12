using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JW_Core_GameManager : JW_Base_MonoSingleton<JW_Core_GameManager>
{
    private void Start()
    {

        JW_Core_AppManager.Instance.Init();
        JW_Core_ResourceManager.Instance.Init();
        JW_Core_StateManager.Instance.Init(new LoginMachine());

        JW_Core_StateManager.Instance.Run();
    }


    private void Update()
    {

    }
}