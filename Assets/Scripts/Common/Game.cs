using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Game : MonoBehaviour
{
    [SerializeField] private AssetReference UIReference;
    private ILoadableUIVievFactory loadableUIViewFactory;
    private ILoadableUIViewModel shopUIViewModel;
    private GameObject loadingScreen;
    
    async void Start()
    {
        loadableUIViewFactory = new ShopLoadableUiVievFactory();

        GameObject ui = await Addressables.InstantiateAsync(UIReference).ToUniTask();
        shopUIViewModel = loadableUIViewFactory.CreateProduct(ui);
        shopUIViewModel.Visible.Value = true;
        shopUIViewModel.Parent.Value = transform;
        shopUIViewModel.Load(new DataLoaderFromJsonFile()).ToObservable().Subscribe(_ => transform.Find("Loading Screen").gameObject.SetActive(false));
    }

}
