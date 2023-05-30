using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    private void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private void Shoot()
    {
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out RaycastHit hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
                target.TakeDamage(damage);
        }
        else
        {
            return;
        }
            
    }
}
