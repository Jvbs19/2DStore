using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _shopUI;
    [SerializeField] List<Item> _shopItems = new List<Item>();
    [SerializeField] Transform _itensContent;
    [SerializeField] GameObject _intentoryItem;

    private bool m_isOpen;

    public void OnOffShop()
    {
        bool enable = _shopUI.activeSelf ? false : true;
        _shopUI.SetActive(enable);
        m_isOpen = enable;

        if (enable)
            DisplayShopItems();
    }
    public void AddItem(Item item)
    {
        _shopItems.Add(item);
    }
    public void RemoveItem(Item item)
    {
        _shopItems.Remove(item);
    }
    public void BuyItem(Item item)
    {
        AddItem(item);
        DisplayShopItems();
    }
    public void SellItem(Item item)
    {
        RemoveItem(item);
        DisplayShopItems();
    }
    public void DisplayShopItems()
    {
        foreach (Transform item in _itensContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in _shopItems)
        {
            GameObject obj = Instantiate(_intentoryItem, _itensContent);

            ItemContentBehaviour itn = obj.GetComponent<ItemContentBehaviour>();
            itn.LinkShop(this);
            itn.LinkItem(item);
            itn.ShopItemSetup(item.m_name,item.m_price, item.m_icon);
        }
    }

    public bool IsShopOpen()
    {
        return m_isOpen;
    }

    public void CloseShop()
    {
        _shopUI.SetActive(false);
        m_isOpen = false;
    }

}
