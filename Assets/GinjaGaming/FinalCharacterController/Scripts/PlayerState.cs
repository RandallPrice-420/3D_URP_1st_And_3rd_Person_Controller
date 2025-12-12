using UnityEngine;


namespace GinjaGaming.FinalCharacterController
{
    public class PlayerState : MonoBehaviour
    {
        #region .  Public Properties  .

        [field: SerializeField] public PlayerMovementState CurrentPlayerMovementState { get; private set; } = PlayerMovementState.Idling;

        public enum PlayerMovementState
        {
            Idling    = 0,
            Walking   = 1,
            Running   = 2,
            Sprinting = 3,
            Jumping   = 4,
            Falling   = 5,
            Strafing  = 6
        }

        #endregion


    }// class PlayerState

}   // namespace GinjaGaming.FinalCharacterController