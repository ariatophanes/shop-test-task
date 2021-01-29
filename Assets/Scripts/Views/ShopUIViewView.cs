using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DanielLochner.Assets.SimpleScrollSnap;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ShopUIViewView : MonoBehaviour, IShopUiViewView
{
    private SimpleScrollSnap scrollSnap;
    private GameObject loadingView;

    private void Awake()
    {
        scrollSnap = GetComponentInChildren<SimpleScrollSnap>();
        scrollSnap.enabled = false;
    }

    public void SetVisibility(bool visible)
    {
        //TODO: releasing addressables if visible == false
        gameObject.SetActive(visible);
    }

    public void UpdateScrollNextButton(GameObject go)
    {
        if (!go) return;

        GameObject buttonGO = GameObject.Instantiate(go);
        Transform buttonParent = transform.Find("Buttons/Scroll Next Button Parent");
        buttonGO.transform.SetParent(buttonParent, false);

        scrollSnap.nextButton = buttonGO.GetComponent<Button>();
        
        Addressables.Release(go);
    }

    public void UpdateScrollPrevButton(GameObject go)
    {
        if (!go) return;

        GameObject buttonGO = GameObject.Instantiate(go);
        Transform buttonParent = transform.Find("Buttons/Scroll Prev Button Parent");
        buttonGO.transform.SetParent(buttonParent, false);
        
        scrollSnap.previousButton = buttonGO.GetComponent<Button>();

        Addressables.Release(go);
    }

    public void UpdateCloseButton(GameObject go)
    {
        if (!go) return;

        GameObject buttonGO = GameObject.Instantiate(go);
        Transform buttonParent = transform.Find("Buttons/Close Button Parent");
        buttonGO.transform.SetParent(buttonParent, false);

        Addressables.Release(go);
    }

    public void UpdateOffers(List<IOfferViewModel> offers, GameObject slotsPrefab)
    {
        if (offers?.Any() == false) return;
        
        Transform slotsTransform = null;

        for (int i = 0; i < offers.Count; i++)
        {
            if (i % 6 == 0 || i == 0)
            {

                slotsTransform = GameObject.Instantiate(slotsPrefab).transform;
                slotsTransform.SetParent(scrollSnap.transform.Find("Viewport/Content"), false);
            }

            offers[i].Parent.Value = slotsTransform.transform.Find("Grid");
        }

        scrollSnap.enabled = true;
        
        Addressables.Release(slotsPrefab);
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }
}