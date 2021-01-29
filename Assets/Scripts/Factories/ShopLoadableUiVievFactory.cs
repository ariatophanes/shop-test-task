using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLoadableUiVievFactory : ILoadableUIVievFactory
{
    public ILoadableUIViewModel CreateProduct(GameObject UI)
    {
        IShopUIViewModel viewModel = new ShopUIViewModel();
        IShopUiViewView viewView = UI.AddComponent<ShopUIViewView>();
        IUIViewPresenter presenter = new ShopUIViewPresenter(viewModel, viewView);

        return viewModel;
    }
}
