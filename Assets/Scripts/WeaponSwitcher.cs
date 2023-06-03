using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] private KeyCode changeWeaponKey = KeyCode.Mouse3;
    [SerializeField] private float changingWeaponRate = 0.1f;
    private int actualWeapon = 0;
    private bool changingWeapon;

    private void Start()
    {
        weapons[actualWeapon].SetActive(true); 
    }

    private void Update() 
    {
        if (Input.GetKey(changeWeaponKey) && !changingWeapon)
            StartCoroutine(nameof(ChangeWeapon));
    }

    private IEnumerator ChangeWeapon()
    {
        changingWeapon = true;
        int nextWeapon = (actualWeapon + 1) % (weapons.Length);
        Debug.Log(nextWeapon);
        weapons[actualWeapon].SetActive(false);
        yield return new WaitForSeconds(changingWeaponRate);
        weapons[nextWeapon].SetActive(true); 
        actualWeapon = nextWeapon; 
        changingWeapon = false;
    }
}
