using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    #region Singleton
    public static InventoryBehaviour Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] GameObject _inventoryUI;
    [SerializeField] List<Item> _items = new List<Item>();
    [SerializeField] Transform _itensContent;
    [SerializeField] GameObject _intentoryItem;

    public void OnOffInventory()
    {
        bool enable = _inventoryUI.activeSelf ? false : true;
        _inventoryUI.SetActive(enable);
        
        if (enable)
            ListItems();
    }
    public void AddItem(Item item)
    {
        _items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in _itensContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in _items)
        {
            GameObject obj = Instantiate(_intentoryItem, _itensContent);

            ItemContentBehaviour itn = obj.GetComponent<ItemContentBehaviour>();

            itn.LinkItem(item);
            itn.ItemSetup(item.m_name, item.m_icon);
        }
    }
}
