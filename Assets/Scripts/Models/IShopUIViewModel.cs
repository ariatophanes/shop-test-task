using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IShopUIViewModel : ILoadableUIViewModel
{ 
    ReactiveProperty<GameObject> ScrollNextButton { get; set; }
    ReactiveProperty<GameObject> ScrollPrevButton { get; set; }
    ReactiveProperty<GameObject> CloseButton { get; set; }
    GameObject SlotsPrefab { get; set; }
    ReactiveProperty<List<IOfferViewModel>> Offers { get; set; }
}
