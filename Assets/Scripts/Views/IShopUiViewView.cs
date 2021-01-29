using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IShopUiViewView : IUIViewView
{
    void UpdateScrollNextButton(GameObject go);
    void UpdateScrollPrevButton(GameObject go);
    void UpdateCloseButton(GameObject go);
    void UpdateOffers(List<IOfferViewModel> offers,GameObject slotsPrefab);
}
