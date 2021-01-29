using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferViewView : MonoBehaviour, IOfferViewView
{
    public void SetVisibility(bool visible)
    {
        gameObject.SetActive(visible);
    }

    public void SetUserName(string name)
    {
        transform.Find("User Name").GetComponent<TextMeshProUGUI>().text = name;
    }

    public void SetUserAvatar(Texture2D texture2D)
    {
        transform.Find("User Avatar").GetComponent<RawImage>().texture = texture2D;
    }

    public void SetPlayerExp(string exp)
    {
        transform.Find("Exp Image/Exp Text").GetComponent<TextMeshProUGUI>().text = exp;
    }

    public void SetItemCount(string count)
    {
        transform.Find("Item Count").GetComponent<TextMeshProUGUI>().text = "x" + count;
    }

    public void SetItemCost(string itemCost)
    {
        transform.Find("Item Cost").GetComponent<TextMeshProUGUI>().text = itemCost;
    }

    public void SetItemName(string itemName)
    {
        transform.Find("Item Name").GetComponent<TextMeshProUGUI>().text = itemName;
    }

    public void SetItemImage(Texture2D itemImage)
    {
        transform.Find("Item Image").GetComponent<RawImage>().texture = itemImage;
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent, false);
    }
}
