using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ShopUIViewPresenter : IUIViewPresenter
{
    private IShopUIViewModel model;
    private IShopUiViewView view;

    private CompositeDisposable disposables;

    public ShopUIViewPresenter(IShopUIViewModel model, IShopUiViewView view)
    {
        this.model = model;
        this.view = view;
        
        disposables = new CompositeDisposable();

        model.Visible.Skip(1).Subscribe(visible => SetVisibility(visible)).AddTo(disposables);
        model.Parent.Subscribe(parent => view.SetParent(parent));
        model.ScrollNextButton.Subscribe(go => view.UpdateScrollNextButton(go));
        model.ScrollPrevButton.Subscribe(go => view.UpdateScrollPrevButton(go));
        model.CloseButton.Subscribe(go => view.UpdateCloseButton(go));
        model.Offers.Where(offers => offers!=null).Subscribe(offers => view.UpdateOffers(offers, model.SlotsPrefab));
    }

    public void SetVisibility(bool visible)
    {
        if(!visible) disposables.Clear();
        
        view.SetVisibility(visible);
    }
}
