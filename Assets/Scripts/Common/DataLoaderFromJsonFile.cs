using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DataLoaderFromJsonFile : IDataLoader
{
    public ShopUIData LoadData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("ShopUIData");
        return JsonUtility.FromJson<ShopUIData>(jsonFile.text);
    }
}