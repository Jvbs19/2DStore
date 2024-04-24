using UnityEngine;
using UnityEngine.InputSystem;

public class StoreNPCBehaviour : InteractiveAction
{
    [SerializeField] ShopBehaviour _shop;

    public override void DoAction(InputAction.CallbackContext obj)
    {
        if (!m_isActionPossible)
            return;
        
        _shop.OnOffShop();
    }
}
