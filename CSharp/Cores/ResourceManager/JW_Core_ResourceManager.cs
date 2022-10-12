using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class  JW_Core_ResourceManager: JW_Base_MonoSingleton<JW_Core_ResourceManager>
{
    public void Init()
    {
    }

    public void LoadAsset<T>(JW_Struct_ResourceInfo resourceInfo)
    {
        StartCoroutine(LoadAssetAsync<T>(resourceInfo));
    }

    private IEnumerator LoadAssetAsync<T>(JW_Struct_ResourceInfo resourceInfo)
    {
        AsyncOperationHandle handle;

        if (resourceInfo.Labels.Count > 0)
        {
            List<object> condition = new List<object>();
            resourceInfo.Labels.ForEach(label => condition.Add(label));

            handle = Addressables.LoadAssetAsync<T>(condition);
        }
        else
        {
            handle = Addressables.LoadAssetAsync<T>(resourceInfo.Name);
        }

        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            resourceInfo.OnLoadFinished(handle.Status.ToString(), handle.Result);
        }
    }
}