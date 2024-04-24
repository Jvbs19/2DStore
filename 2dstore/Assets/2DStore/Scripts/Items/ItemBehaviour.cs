using UnityEngine;
using UnityEngine.InputSystem;

public class ItemBehaviour : InteractiveAction
{
    [SerializeField] Item item;
    
    public override void DoAction(InputAction.CallbackContext obj)
    {
        if (!m_isActionPossible)
            return;

        CheckType();
    }
    void CheckType()
    {
        switch (item.m_type)
        {
            case Type.Equipable:
                PickItem();
                break;
            case Type.Consumable:
                PickItem();
                break;
            case Type.Coin:
                PickCoin();
                break;
            default:
                break;
        }
    }
    void PickItem()
    {
        InventoryBehaviour.Instance.AddItem(item);
        Destroy(gameObject);
    }
    void PickCoin()
    {
        Currency.CalculateMoney(item.m_price);
        Destroy(gameObject);
    }
    public string GetItemName()
    {
        return item.m_name;
    }
    public Sprite GetItemIcon()
    {
        return item.m_icon;
    }
}
