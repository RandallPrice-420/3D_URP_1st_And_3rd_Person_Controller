using UnityEngine;


namespace GinjaGaming.FinalCharacterController
{
    [DefaultExecutionOrder(-1)]
    public class PlayerController : MonoBehaviour
    {
        #region .  Public Properties  .

        [Header("Base Movement")]
        public float drag             = 0.1f;
        public float runSpeed         = 4f;
        public float runAcceleration  = 0.25f;

        [Header("Camera Settings")]
        public float LookSensitivityH = 0.1f;
        public float LookSensitivityV = 0.1f;
        public float LookLimitV       = 89f;

        #endregion


        #region .  Private Properties  .

        [Header("Components")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Camera              _playerCamera;

        private PlayerLocomotionInput _playerLocomotionInput;

        private Vector2 _cameraRotation       = Vector2.zero;
        private Vector2 _playerTargetRotation = Vector2.zero;

        #endregion


        #region .  Awake()  .
        private void Awake()
        {
            _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();

        }   // Awake()
        #endregion


        #region .  LateUpdate()  .
        private void LateUpdate()
        {
            _cameraRotation.x += LookSensitivityH * _playerLocomotionInput.LookInput.x;
            _cameraRotation.y  = Mathf.Clamp(_cameraRotation.y - LookSensitivityV * _playerLocomotionInput.LookInput.y, -LookLimitV, LookLimitV);

            _playerTargetRotation.x += transform.eulerAngles.x + LookSensitivityH * _playerLocomotionInput.LookInput.x;
            transform.rotation       = Quaternion.Euler(0f, _playerTargetRotation.x, 0f);

            _playerCamera.transform.rotation = Quaternion.Euler(_cameraRotation.y, _cameraRotation.x, 0f);

        }   // LateUpdate()
        #endregion


        #region .  Update()  .
        private void Update()
        {
            Vector3 cameraForwardXZ = new Vector3(_playerCamera.transform.forward.x, 0f, _playerCamera.transform.forward.z).normalized;
            Vector3 cameraRightXZ   = new Vector3(_playerCamera.transform.right.x,   0f, _playerCamera.transform.right.z).normalized;

            Vector3 movementDirection = cameraRightXZ   * _playerLocomotionInput.MovementInput.x
                                      + cameraForwardXZ * _playerLocomotionInput.MovementInput.y;

            Vector3 movementDelta = movementDirection * runAcceleration * Time.deltaTime;
            Vector3 newVelocity   = _characterController.velocity + movementDelta;

            // Add drag to the player.
            Vector3 currentDrag = newVelocity.normalized * drag * Time.deltaTime;
            newVelocity = (newVelocity.magnitude > drag * Time.deltaTime) ? newVelocity - currentDrag : Vector3.zero;
            newVelocity = Vector3.ClampMagnitude(newVelocity, runSpeed);

            // Move character (Unity suggests only calling this once per frame).
            _characterController.Move(newVelocity * Time.deltaTime);

        }   // Update()
        #endregion


    }   // class PlayerController

}   // namespace GinjaGaming.FinalCharacterController