using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[Serializable]
public class OfferViewModel :IOfferViewModel
{
    public ReactiveProperty<Transform> Parent { get; set; }
    public ReactiveProperty<bool> Visible { get; set; }
    public ReactiveProperty<string> UserName { get; set; }
    public ReactiveProperty<Texture2D> UserAvatar { get; set; }
    public ReactiveProperty<int> PlayerExp { get; set; }
    public ReactiveProperty<int> ItemCount { get; set; }
    public ReactiveProperty<int> ItemCost { get; set; }
    public ReactiveProperty<string> ItemName { get; set; }
    public ReactiveProperty<Texture2D> ItemImage { get; set; }

    public OfferViewModel()
    {
        Parent = new ReactiveProperty<Transform>();
        Visible = new ReactiveProperty<bool>();
        UserName = new ReactiveProperty<string>();
        UserAvatar = new ReactiveProperty<Texture2D>();
        PlayerExp = new ReactiveProperty<int>();
        ItemCount = new ReactiveProperty<int>();
        ItemCost = new ReactiveProperty<int>();
        ItemName = new ReactiveProperty<string>();
        ItemImage = new ReactiveProperty<Texture2D>();
    }
}