
using UnityEngine;
using FSM.StateInfo;

namespace FSM.States {
    public abstract class State<T> where T : BaseStateInfo
    {
        public abstract void OnEnter(Transform transform, T stateInfo);
        public abstract void OnExit(Transform transform, T stateInfo);
        public abstract void Update(Transform transform, T stateInfo, float deltaTime);
        public abstract void CheckTransitions(Transform transform, T stateInfo);
        public delegate void ChangeStateDelegate(Transform transform, T stateInfo, string nextStateName);

        public void SetChangeState(ChangeStateDelegate changeState){
            ChangeState = changeState;
        }

        protected ChangeStateDelegate ChangeState;
    }
}