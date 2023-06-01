using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentAmount()
    {
        return ammoAmount;
    }

    public void SetAmmoAmount(int amount)
    {
        ammoAmount = amount;
    }

    public void ReduceAmmoAmount()
    {
        ammoAmount--;
    }
}
