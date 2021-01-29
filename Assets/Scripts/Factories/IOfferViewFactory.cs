using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOfferViewFactory
{
    IOfferViewModel CreateProduct(GameObject view);
}
