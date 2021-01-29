using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ShopUIViewModel : IShopUIViewModel
{
    public ReactiveProperty<bool> Visible { get; set; }
    public ReactiveProperty<Transform> Parent { get; set; }
    public ReactiveProperty<GameObject> ScrollNextButton { get; set; }
    public ReactiveProperty<GameObject> ScrollPrevButton { get; set; }
    public ReactiveProperty<GameObject> CloseButton { get; set; }
    public ReactiveProperty<List<IOfferViewModel>> Offers { get; set; }

    private IOfferViewFactory offerViewFactory;
    public GameObject SlotsPrefab { get; set; }

    private Texture2D loadingAvatarTexture2D;
    
    public ShopUIViewModel()
    {
        Visible = new ReactiveProperty<bool>(false);
        Parent = new ReactiveProperty<Transform>();
        ScrollNextButton =  new ReactiveProperty<GameObject>();
        ScrollPrevButton = new ReactiveProperty<GameObject>();
        CloseButton = new ReactiveProperty<GameObject>();
        Offers = new ReactiveProperty<List<IOfferViewModel>>();

        offerViewFactory = new OfferViewFactory();
    }

    public async UniTask Load(IDataLoader dataLoader)
    {
        ShopUIData data = dataLoader.LoadData();

        // await LoadScrollNextButton(data);
        // await LoadScrollPrevButton(data);
        // await LoadCloseButton(data);
        // await LoadSlotsPrefab();
        // await LoadLoadingAvatarTexture();
        // await LoadOffers(data);

        await UniTask.WhenAll(
            LoadScrollNextButton(data),
            LoadScrollPrevButton(data),
            LoadCloseButton(data),
            LoadSlotsPrefab(),
            LoadLoadingAvatarTexture(),
            LoadOffers(data));
    }

    private async UniTask LoadScrollNextButton(ShopUIData data)
    {
        ScrollNextButton.Value = await Addressables.InstantiateAsync(data.scrollNextButtonAssetPath).ToUniTask();
    }
    
    public async UniTask LoadScrollPrevButton(ShopUIData data)
    {
        ScrollPrevButton.Value = await Addressables.InstantiateAsync(data.scrollPrevButtonAssetPath).ToUniTask();
    }

    private async UniTask LoadCloseButton(ShopUIData data)
    {
        CloseButton.Value = await Addressables.InstantiateAsync(data.closeButtonAssetPath).ToUniTask();
    }

    private async UniTask LoadSlotsPrefab()
    {
        SlotsPrefab = await Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Views/Slots.prefab").ToUniTask();
    }

    private async UniTask LoadLoadingAvatarTexture()
    {
        loadingAvatarTexture2D = await Addressables.LoadAssetAsync<Texture2D>("Assets/Graphics/Images/Loading.png").ToUniTask();
    }

    public async UniTask LoadOffers(ShopUIData data)
    {
        List<IOfferViewModel> result = new List<IOfferViewModel>();

        foreach (OfferData model in data.offers)
        {
            GameObject offerViewGO = await Addressables.InstantiateAsync("Assets/Prefabs/Views/Offer View.prefab").ToUniTask();
            
            IOfferViewModel offerViewModel = offerViewFactory.CreateProduct(offerViewGO);
            offerViewModel.Visible.Value = true;
            offerViewModel.UserName.Value = model.userName;
            offerViewModel.ItemCount.Value = model.itemCount;
            offerViewModel.ItemCost.Value = model.itemCost * model.itemCount;
            offerViewModel.ItemName.Value = model.itemName;
            offerViewModel.PlayerExp.Value = model.playerExp;
            offerViewModel.UserAvatar.Value = loadingAvatarTexture2D;

            offerViewModel.ItemImage.Value =
                await Addressables.LoadAssetAsync<Texture2D>(model.itemImagePath).ToUniTask();
            
            UnityWebRequest loader = UnityWebRequestTexture.GetTexture(model.userAvatarURL);
            loader.SendWebRequest().completed += (op) =>
                offerViewModel.UserAvatar.Value = DownloadHandlerTexture.GetContent(loader);

            result.Add(offerViewModel);
        }

        Offers.Value = result;
    }
}
