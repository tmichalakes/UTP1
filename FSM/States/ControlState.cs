
using UnityEngine;
using FSM.StateInfo;

namespace FSM.States {
    public abstract class ControlState
    {
        public abstract void OnEnter(Transform transform, PlayerControllerStateInfo stateInfo);
        public abstract void OnExit(Transform transform, PlayerControllerStateInfo stateInfo);
        public abstract void Update(Transform transform, PlayerControllerStateInfo stateInfo, float deltaTime);
        public abstract void CheckTransitions(Transform transform, PlayerControllerStateInfo stateInfo);
        public delegate void ChangeStateDelegate(Transform transform, PlayerControllerStateInfo stateInfo, string nextStateName);

        public void SetChangeState(ChangeStateDelegate changeState){
            ChangeState = changeState;
        }

        protected ChangeStateDelegate ChangeState;
    }
}