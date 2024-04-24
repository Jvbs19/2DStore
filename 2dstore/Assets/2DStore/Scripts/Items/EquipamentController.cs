using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipamentController : MonoBehaviour
{
    #region Singleton
    public static EquipamentController Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] SpriteRenderer _faceSlot;
    [SerializeField] SpriteRenderer _headSlot;
    [SerializeField] SpriteRenderer _bodySlot;
    [SerializeField] SpriteRenderer _weaponsSlot;

    [SerializeField] Sprite[] _defaultCostume = new Sprite[4];
    public void EquipItem(Item item)
    {
        switch (item.m_equipType)
        {
            case EquipType.Face:
                EquipFaceSlot(item);
                break;
            case EquipType.Head:
                EquipHeadSlot(item);
                break;
            case EquipType.Body:
                EquipBodySlot(item);
                break;
            case EquipType.Weapons:
                EquipWeaponsSlot(item);
                break;
            default:
                break;
        }
    }
    public void UnequipItem(Item item)
    {
        switch (item.m_equipType)
        {
            case EquipType.Face:
                EquipDefault(0);
                break;
            case EquipType.Head:
                EquipDefault(1);
                break;
            case EquipType.Body:
                EquipDefault(2);
                break;
            case EquipType.Weapons:
                EquipDefault(3);
                break;
            default:
                break;
        }
    }
    void EquipFaceSlot(Item item)
    {
        _faceSlot.sprite = item.m_icon;
    }
    void EquipHeadSlot(Item item)
    {
        _headSlot.sprite = item.m_icon;
    }
    void EquipBodySlot(Item item)
    {
        _bodySlot.sprite = item.m_icon;
    }
    void EquipWeaponsSlot(Item item)
    {
        _weaponsSlot.sprite = item.m_icon;
    }
    void EquipDefault(int i)
    {
        switch (i)
        {
            case 0:
                _faceSlot.sprite = _defaultCostume[i];
                break;
            case 1:
                _headSlot.sprite = _defaultCostume[i];
                break;
            case 2:
                _bodySlot.sprite = _defaultCostume[i];
                break;
            case 3:
                _weaponsSlot.sprite = _defaultCostume[i];
                break;
            default:
                break;
        }
    }
}
