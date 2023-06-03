using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float fireRate = 1f;
    private bool canShoot = true;
    private void Update() 
    {
        if (Input.GetKey(shootKey) && canShoot)
            StartCoroutine(nameof(Shoot));
    }

    private IEnumerator Shoot()
    {
        if (ammoSlot.GetCurrentAmount() > 0)
        {
            canShoot = false;
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmoAmount();
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }  
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out RaycastHit hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
                target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .2f);
    }

}
