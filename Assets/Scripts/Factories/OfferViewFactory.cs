using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferViewFactory : IOfferViewFactory
{
    public IOfferViewModel CreateProduct(GameObject viewGO)
    {
        IOfferViewModel model = new OfferViewModel();
        IOfferViewView view = viewGO.AddComponent<OfferViewView>();
        IOfferViewPresenter presenter = new OfferViewPresenter(model, view);

        return model;
    }
}
