using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemContentBehaviour : MonoBehaviour
{
    [SerializeField] Image _itemIcon;
    [SerializeField] TMP_Text _itemName;
    [SerializeField] TMP_Text _itemPrice;
    [SerializeField] GameObject _options;

    bool isActive = false;
    Item myItem;
    ShopBehaviour currentShop;

    public void ItemSetup(string name, Sprite icon)
    {
        _itemIcon.sprite = icon;
        _itemName.text = name;
    }
    public void ShopItemSetup(string name, float price, Sprite icon)
    {
        _itemIcon.sprite = icon;
        _itemName.text = name;
        _itemPrice.text = "$"+price;
    }
    public void ItemBehaviour()
    {
        if (!isActive)
            UseItem();
        else
            RemoveItem();
    } 
    public void LinkShop(ShopBehaviour shop)
    {
        currentShop = shop;
    }
    public void LinkItem(Item itn)
    {
        myItem = itn;
    }
    public void SellItem()
    {
        if (!isActive)
        {
            Currency.CalculateMoney(myItem.m_price / 2);
            InventoryBehaviour.Instance.RemoveItem(myItem);
            InventoryBehaviour.Instance.ListItems();
        }
    }
    public void BuyItem()
    {
        if (myItem.m_price > Currency.CheckMoney())
            return;

        Currency.CalculateMoney(-myItem.m_price);
        InventoryBehaviour.Instance.AddItem(myItem);
        InventoryBehaviour.Instance.ListItems();
        currentShop.SellItem(myItem);
    }
    public void UseItem()
    {
        switch (myItem.m_type)
        {
            case Type.Equipable:
                EquipItem(myItem);
                isActive = true;
                break;
            case Type.Consumable:
                break;
            default:
                break;
        }
    }
    public void RemoveItem()
    {
        switch (myItem.m_type)
        {
            case Type.Equipable:
                UnequipItem(myItem);
                isActive = false;
                break;
            case Type.Consumable:
                break;
            default:
                break;
        }
    }
    void EquipItem(Item item)
    {
        EquipamentController.Instance.EquipItem(item);
    }
    void UnequipItem(Item item)
    {
        EquipamentController.Instance.UnequipItem(item);
    }
}
