using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager_Mono : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject _object;

    private GameObject _instanceReference; 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _object.LoadAssetAsync().Completed += OnAddressableLoaded;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("DELETING");
            _object.ReleaseInstance(_instanceReference);
        }
    }

    private void OnAddressableLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            _instanceReference = Instantiate(handle.Result);
        }
        else
        {
            Debug.LogError("LOADING ASSET FAILED");
        }
    }
    
    
}
