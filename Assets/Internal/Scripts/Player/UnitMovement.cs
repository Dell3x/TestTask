using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Unit
{
    public class UnitMovement : UnitBaseState
    {
        [SerializeField] private Animator _unitAnimator;
        [SerializeField] private Transform _camera;
        
        [Header("Parameters")] 
        [SerializeField] private float _moveSpeed;
        
        private const string _IsWalking = "isWalking";

        private Vector2 _playerInput;
        private float angleSmoothVelocity;
        private float angleSmoothTime = 0.1f;

        private void Update()   
        {
            MovePlayer();
        }

        public void Move(InputAction.CallbackContext _callbackContext)
        {
            _playerInput = _callbackContext.ReadValue<Vector2>();
        }

        private void MovePlayer()
        {
            var direction = new Vector3(_playerInput.x, 0f, _playerInput.y).normalized;
            
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref angleSmoothVelocity,
                angleSmoothTime);

            var moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            if (direction != Vector3.zero)
            {
                _unitAnimator.SetBool(_IsWalking, true);
                _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);
                gameObject.transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            }
            else
            {
                _unitAnimator.SetBool(_IsWalking, false);
            }
        }
    }
}