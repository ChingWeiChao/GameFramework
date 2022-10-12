using System;
using UnityEngine;

public class JW_Core_AppManager : JW_Base_MonoSingleton<JW_Core_AppManager>
{
    public void Init()
    {
    }

    public string GetHDCode()
    {
        string hdCode = Guid.NewGuid().ToString("N") + DateTime.Now.ToString("yyyyMMddHHmmssffff");

        if (hdCode.Length > 64)
        {
            hdCode = hdCode.Substring(0, 64);
        }

        return hdCode;
    }

    public int GetHDType()
    {
        int HDType = 0;

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXEditor ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            HDType = 3;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            HDType = 2;
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor ||
           Application.platform == RuntimePlatform.WindowsPlayer)
        {
            HDType = 1;
        }

        return HDType;
    }

    public bool IsIOS()
    {
        if ((Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXEditor ||
            Application.platform == RuntimePlatform.OSXPlayer)
            && Application.isEditor == false)
        {
            return true;
        }

        return false;
    }

    public bool IsAndroid()
    {
        if (Application.platform == RuntimePlatform.Android
        && Application.isEditor == false)
        {
            return true;
        }

        return false;
    }

    public bool IsWindows()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor ||
           Application.platform == RuntimePlatform.WindowsPlayer ||
           Application.isEditor == true)
        {
            return true;
        }

        return false;
    }

    public string GetPackageBunldId()
    {
        //     --     if(type(CS.AppDefine.Instance.GetBundleID) == "function") then
        //     --         return CS.AppDefine.Instance.GetBundleID()
        //     --     end
        //     --     if(IsIOS() or IsAndroid()) then
        //     --         return CS.GameSDKInterface.instance:GetPackageBunldId()
        //     --     end
        return Application.identifier;
    }
}