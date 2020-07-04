
using UnityEngine;
using FSM.StateInfo;

namespace FSM.States {
    public class MovementControlState : ControlState
    {
        public override void OnEnter(Transform transform, PlayerControllerStateInfo stateInfo)
        {
            // no-op
        }

        public override void OnExit(Transform transform, PlayerControllerStateInfo stateInfo)
        {
            // no-op
        }

        public override void Update(Transform transform, PlayerControllerStateInfo stateInfo, float deltaTime)
        {
            UpdateVelocityUnit(stateInfo, Time.fixedDeltaTime);
            var Velocity = transform.forward * stateInfo.Speed * deltaTime;
            transform.Translate(Velocity, Space.World);
            transform.Rotate(transform.up, stateInfo.TurnRate, Space.World);
        }

        public override void CheckTransitions(Transform transform, PlayerControllerStateInfo stateInfo){
            if(stateInfo.Input.SpacebarInput > 0){
                ChangeState(transform, stateInfo, ControlStateMachine.StateNames.JumpState);
            }
        }

        void UpdateVelocityUnit(PlayerControllerStateInfo stateInfo, float deltaTime){
            if(stateInfo.Input.VerticalInput > 0){
                stateInfo.Speed += stateInfo.Acceleration * Time.fixedDeltaTime * stateInfo.Input.VerticalInput;
                stateInfo.Speed = Mathf.Min(stateInfo.Speed, stateInfo.MaxSpeed);
            } else if (stateInfo.Input.VerticalInput < 0){
                stateInfo.Speed += stateInfo.Deceleration * Time.fixedDeltaTime * stateInfo.Input.VerticalInput;
                stateInfo.Speed = Mathf.Max(stateInfo.Speed, 0f);
            }
            if(stateInfo.Input.HorizontalInput > 0){
                stateInfo.TurnRate = Mathf.Min(stateInfo.TurnRate + (stateInfo.TurnDelta * deltaTime * stateInfo.Input.HorizontalInput), stateInfo.MaxTurnRate);
            }
            else if(stateInfo.Input.HorizontalInput < 0){
                stateInfo.TurnRate = Mathf.Max(stateInfo.TurnRate + (stateInfo.TurnDelta * deltaTime * stateInfo.Input.HorizontalInput), stateInfo.MaxTurnRate * -1);
            }
            else { // no input - Turn Rate should go to zero
                stateInfo.TurnRate = stateInfo.TurnRate > 0 ? 
                    Mathf.Min(stateInfo.TurnRate + stateInfo.TurnDelta * deltaTime * stateInfo.Input.HorizontalInput, 0f):
                    Mathf.Max(stateInfo.TurnRate - stateInfo.TurnDelta * deltaTime * stateInfo.Input.HorizontalInput, 0f);
            }   
        }
    }
}