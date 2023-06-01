using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera  virtualCamera;
    [SerializeField] private KeyCode zoomKey = KeyCode.Mouse3;
    

    private void Update() 
    {
        if (Input.GetKey(zoomKey))
        {
            virtualCamera.m_Lens.FieldOfView = 30;
        }
        if (Input.GetKeyUp(zoomKey))
        {
            virtualCamera.m_Lens.FieldOfView = 40;
        }        
    }
}
