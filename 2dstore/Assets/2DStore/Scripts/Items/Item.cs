using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Scriptable/Item/Create New Item")]
public class Item : ScriptableObject
{
    public Type m_type;
    public EquipType m_equipType;
    public string m_name;
    public Sprite m_icon;
    public float m_price;
}

public enum Type
{
    Equipable,
    Consumable,
    Coin
}
public enum EquipType
{
    None,
    Face,
    Head,
    Body,
    Weapons,
}