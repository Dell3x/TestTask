using UnityEngine;

namespace Game.Unit
{
    public abstract class UnitBaseState : MonoBehaviour
    {
        private protected CharacterController _characterController;

        protected virtual void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
    }
}