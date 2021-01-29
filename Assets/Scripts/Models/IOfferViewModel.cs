using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IOfferViewModel : IUIViewModel
{ 
    ReactiveProperty<string> UserName { get; set; }
    ReactiveProperty<Texture2D> UserAvatar { get; set; }
    ReactiveProperty<int> PlayerExp { get; set; }
    ReactiveProperty<int> ItemCount { get; set; }
    ReactiveProperty<int> ItemCost { get; set; }
    ReactiveProperty<string> ItemName { get; set; } 
    ReactiveProperty<Texture2D> ItemImage { get; set; }
}
