using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera  virtualCamera;
    [SerializeField] private KeyCode zoomKey = KeyCode.Mouse3;
    [SerializeField] float zoomInValue = 25f;
    [SerializeField] float zoomOutValue = 40f;
    

    private void Update() 
    {
        if (Input.GetKey(zoomKey))
        {
            virtualCamera.m_Lens.FieldOfView = zoomInValue;
        }
        if (Input.GetKeyUp(zoomKey))
        {
            virtualCamera.m_Lens.FieldOfView = zoomOutValue;
        }        
    }
}
