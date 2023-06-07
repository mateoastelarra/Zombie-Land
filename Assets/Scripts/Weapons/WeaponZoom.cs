using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [Header("Zoom")]
    [SerializeField] CinemachineVirtualCamera  virtualCamera;
    [SerializeField] private KeyCode zoomKey = KeyCode.Mouse3;
    [SerializeField] float zoomInValue = 25f;
    [SerializeField] float zoomOutValue = 40f;
    [Header("Mouse Sensibility")]
    [SerializeField] GameObject player;
    [SerializeField] float sensibilityZoomIn = 0.5f;
    [SerializeField] float sensibilityZoomOut = 1f;
    FirstPersonController playerController;
    
    private void Start()
    {
        playerController = player.GetComponent<FirstPersonController>();
    }
    

    private void Update() 
    {
        if (Input.GetKey(zoomKey))
        {
            virtualCamera.m_Lens.FieldOfView = zoomInValue;
            playerController.RotationSpeed = sensibilityZoomIn;
        }
        if (Input.GetKeyUp(zoomKey))
        {
            virtualCamera.m_Lens.FieldOfView = zoomOutValue;
            playerController.RotationSpeed = sensibilityZoomOut;
        }        
    }
}
