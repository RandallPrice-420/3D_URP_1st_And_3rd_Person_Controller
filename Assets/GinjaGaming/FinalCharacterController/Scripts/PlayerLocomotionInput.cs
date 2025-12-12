using UnityEngine;
using UnityEngine.InputSystem;


namespace GinjaGaming.FinalCharacterController
{
    [DefaultExecutionOrder(-2)]
    public class PlayerLocomotionInput : MonoBehaviour, PlayerControls.IPlayerLocomotionMapActions
    {
        #region .  Public Properties  .

        public PlayerControls PlayerControls {  get; private set; }
        public Vector2        LookInput      { get; private set; }
        public Vector2        MovementInput  { get; private set; }

        #endregion


        #region .  OnDisable()  .
        private void OnDisable()
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Enable();

            PlayerControls.PlayerLocomotionMap.Disable();
            PlayerControls.PlayerLocomotionMap.RemoveCallbacks(this);

        }   // OnDisable()
        #endregion


        #region .  OnEnable()  .
        private void OnEnable()
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Enable();

            PlayerControls.PlayerLocomotionMap.Enable();
            PlayerControls.PlayerLocomotionMap.SetCallbacks(this);

        }   // OnEnable()
        #endregion


        #region .  OnLook()  .
        public void OnLook(InputAction.CallbackContext context)
        {
            LookInput = context.ReadValue<Vector2>();


        }   // OnLook()
        #endregion


        #region .  OnMovement()  .
        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            
            //print(MovementInput);

        }   // OnMovement()
        #endregion


    }   // class PlayerLocomotionInput

}   // namespace GinjaGaming.FinalCharacterController