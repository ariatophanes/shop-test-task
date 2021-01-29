using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class OfferViewPresenter : IOfferViewPresenter
{
    private IOfferViewModel model;
    private IOfferViewView view;

    private CompositeDisposable disposables;

    public OfferViewPresenter(IOfferViewModel model, IOfferViewView view)
    {
        this.model = model;
        this.view = view;
        
        disposables = new CompositeDisposable();
        
        model.UserName.Subscribe(name => SetUserName(name)).AddTo(disposables);
        model.UserAvatar.Subscribe(avatar => SetUserAvatar(avatar)).AddTo(disposables);
        model.PlayerExp.Subscribe(exp => SetPlayerExp(exp.ToString())).AddTo(disposables);
        model.ItemCount.Subscribe(count => SetItemCount(count.ToString())).AddTo(disposables);
        model.ItemCost.Subscribe(cost => SetItemCost(cost.ToString())).AddTo(disposables);
        model.ItemName.Subscribe(name => SetItemName(name)).AddTo(disposables);
        model.ItemImage.Subscribe(image => SetItemImage(image)).AddTo(disposables);
        model.Visible.Skip(1).Subscribe(visible => SetVisibility(visible)).AddTo(disposables);
        model.Parent.Subscribe(parent => SetParent(parent)).AddTo(disposables);
    }
    
    public void SetUserName(string name)
    {
        view.SetUserName(name);
    }

    public void SetUserAvatar(Texture2D texture2D)
    {
        view.SetUserAvatar(texture2D);
    }

    public void SetPlayerExp(string exp)
    {
        view.SetPlayerExp(exp);
    }

    public void SetItemCount(string count)
    {
        view.SetItemCount(count);
    }

    public void SetItemCost(string itemCost)
    {
        view.SetItemCost(itemCost);
    }

    public void SetItemName(string itemName)
    {
        view.SetItemName(itemName);
    }

    public void SetItemImage(Texture2D texture)
    {
        view.SetItemImage(texture);
    }

    public void SetVisibility(bool visible)
    {
        if(!visible) disposables.Clear();
        
        view.SetVisibility(visible);
    }

    private void SetParent(Transform parent)
    {
        view.SetParent(parent);
    }
}
