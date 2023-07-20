using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Camera
{
    public sealed class CameraBehaviour : MonoBehaviour
    {
        [SerializeField] private  CinemachineFreeLook _freeLookCamera;
        [SerializeField] private float _xAxisSpeed;
        [SerializeField] private float _yAxisSpeed;
    
        private bool _isCameraActive;

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
            if (!_isCameraActive)
            {
                _freeLookCamera.m_XAxis.m_MaxSpeed = _xAxisSpeed;
                _freeLookCamera.m_YAxis.m_MaxSpeed = _yAxisSpeed;
                _isCameraActive = true;
            }
        }

        private void DisableCamera()
        {
            if (_isCameraActive)
            {
                _freeLookCamera.m_XAxis.m_MaxSpeed = 0f;
                _freeLookCamera.m_YAxis.m_MaxSpeed = 0f;
                _isCameraActive = false;
            }
        }
    }
}