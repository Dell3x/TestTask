using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private  CinemachineFreeLook freeLookCamera;
    [SerializeField] private float _xAxisSpeed;
    [SerializeField] private float _yAxisSpeed;
    
    private bool isCameraActive;

    private void Update()
    {
        bool isInputActive = false;

        if (Mouse.current != null)
        {
            isInputActive = Mouse.current.rightButton.isPressed;
        }
        else if (Touchscreen.current != null)
        {
            isInputActive = Touchscreen.current.primaryTouch.press.isPressed;
        }

        if (isInputActive)
        {
            EnableCamera();
        }
        else
        {
            DisableCamera();
        }

    }

    private void EnableCamera()
    {
        if (!isCameraActive)
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = _xAxisSpeed;
            freeLookCamera.m_YAxis.m_MaxSpeed = _yAxisSpeed;
            isCameraActive = true;
        }
    }

    private void DisableCamera()
    {
        if (isCameraActive)
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = 0f;
            freeLookCamera.m_YAxis.m_MaxSpeed = 0f;
            isCameraActive = false;
        }
    }
}
