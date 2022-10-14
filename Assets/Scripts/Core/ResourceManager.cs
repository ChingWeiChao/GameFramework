using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace JWCore
{
    public class ResourceManager:MonoBehaviour
    {
        public void Init() { }

        public void LoadAsset<T>(ResourceInfo resourceInfo)
        {
            StartCoroutine(LoadAssetAsync<T>(resourceInfo));
        }

        private IEnumerator LoadAssetAsync<T>(ResourceInfo resourceInfo)
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
    public class ResourceInfo
    {
        public string Name;
        public List<string> Labels;
        public System.Action<string, object> OnLoadFinished;
    }
}