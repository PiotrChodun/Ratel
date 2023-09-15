using Unity.Entities;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.InputSystem;

using Ratel.CharacterController;

namespace Ratel
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    partial class InputGatheringSystem : SystemBase, InputActions.ICharacterControllerActions
    {
#pragma warning disable 649
        Vector2 m_CharacterMovement;
#pragma warning restore 649

        InputActions m_InputActions;
        protected override void OnStartRunning() => m_InputActions.Enable();
        protected override void OnStopRunning() => m_InputActions.Disable();

        void InputActions.ICharacterControllerActions.OnMove(InputAction.CallbackContext context) => m_CharacterMovement = context.ReadValue<Vector2>();

        protected override void OnCreate()
        {
            m_InputActions = new InputActions();
            m_InputActions.CharacterController.SetCallbacks(this);
        }

        protected override void OnUpdate()
        {
            foreach (var playerInput in SystemAPI.Query<RefRW<CharacterControllerInput>>().WithAll<GhostOwnerIsLocal>())
            {
                playerInput.ValueRW.Movement = m_CharacterMovement;
            }
        }
    }
}