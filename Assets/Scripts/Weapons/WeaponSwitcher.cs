using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private bool canChangeWeapon => Input.GetKey(changeWeaponKey) && !changingWeapon;
    [SerializeField] GameObject[] weapons;
    [SerializeField] private KeyCode changeWeaponKey = KeyCode.Mouse3;
    [SerializeField] private float changingWeaponRate = 0.1f;
    private int currentWeapon = 0;
    private bool changingWeapon;
    private Quaternion currentRotation;

    private void Start()
    {
        weapons[currentWeapon].SetActive(true); 
    }

    private void Update() 
    {
        if (canChangeWeapon)
            StartCoroutine(ChangeWeapon(0));
        ProcessScrollWheel();
    }

    private IEnumerator ChangeWeapon(int downward)
    {
        changingWeapon = true;
        weapons[currentWeapon].SetActive(false);
        currentWeapon = (currentWeapon + 1 + 2 * downward - downward * (weapons.Length)) % (weapons.Length);
        Debug.Log(currentWeapon);
        yield return new WaitForSeconds(changingWeaponRate);
        weapons[currentWeapon].SetActive(true);
        changingWeapon = false;
    }

    void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !changingWeapon)
        {
            StartCoroutine(ChangeWeapon(-1));
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && !changingWeapon)
        {
            StartCoroutine(ChangeWeapon(0));
        }
    }
}
