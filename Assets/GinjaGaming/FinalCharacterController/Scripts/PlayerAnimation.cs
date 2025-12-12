using UnityEngine;


namespace GinjaGaming.FinalCharacterController
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region .  Private Properties  .

        [SerializeField] private Animator _animator;

        private PlayerLocomotionInput _playerLocomotionInput;

        private static int inputXHash = Animator.StringToHash("inputX");
        private static int inputYHash = Animator.StringToHash("inputY");

        #endregion


        #region .  Awake()  .
        private void Awake()
        {
            _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();

        }   // Awake()
        #endregion


        #region .  Update()  .
        private void Update()
        {
            UpdateAnimationState();

        }   // Update()
        #endregion


        #region .  UpdateAnimationState()  .
        private void UpdateAnimationState()
        {
            Vector2 inputTarget = _playerLocomotionInput.MovementInput;

            _animator.SetFloat(inputXHash, inputTarget.x);
            _animator.SetFloat(inputYHash, inputTarget.y);

        }   // UpdateAnimationState()
        #endregion


    }// class PlayerAnimation

}   // namespace GinjaGaming.FinalCharacterController
