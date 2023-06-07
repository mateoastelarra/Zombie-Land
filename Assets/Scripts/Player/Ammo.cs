using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmount(AmmoType ammoType)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        if (slot == null) return -1;
        return slot.ammoAmount;
    }

    public void IncreaseAmmoAmount(AmmoType ammoType, int amount)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        if (slot == null) return;
        slot.ammoAmount += amount;
    }

    public void ReduceAmmoAmount(AmmoType ammoType)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        if (slot == null) return;
        slot.ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammotype)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammotype)
            {
                return slot;
            }
        }
        return null;
    }
}
