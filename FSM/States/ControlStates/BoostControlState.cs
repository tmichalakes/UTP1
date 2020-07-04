
using FSM.StateInfo;
using FSM.StateMachines;
using UnityEngine;

namespace FSM.States.ControlStates {
    public class BoostControlState : ControlState
    {
        public override void OnEnter(Transform transform, PlayerControllerStateInfo stateInfo)
        {
            stateInfo.Speed = stateInfo.BoostSpeed;
        }

        public override void OnExit(Transform transform, PlayerControllerStateInfo stateInfo)
        {
            // no-op
        }

        public override void Update(Transform transform, PlayerControllerStateInfo stateInfo, float deltaTime)
        {
            stateInfo.Speed -= stateInfo.BoostDegredation * deltaTime;
            var Velocity = transform.forward * stateInfo.Speed * deltaTime;
            transform.Translate(Velocity, Space.World);
        }

        public override void CheckTransitions(Transform transform, PlayerControllerStateInfo stateInfo){
            if(stateInfo.Speed <= stateInfo.MaxSpeed){
                ChangeState(transform, stateInfo, ControlStateMachine.StateNames.DefaultState);
            }
        }
    }
}