using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOfferViewPresenter : IUIViewPresenter
{
    void SetUserName(string name);
    void SetUserAvatar(Texture2D texture2D);
    void SetPlayerExp(string exp);
    void SetItemCount(string count);
    void SetItemCost(string itemCost);
    void SetItemName(string itemName);
    void SetItemImage(Texture2D itemImage);
}
