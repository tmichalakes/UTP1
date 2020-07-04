
using FSM.States;
using FSM.StateInfo;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FSM {
    public class ControlStateMachine : StateMachine<PlayerControllerStateInfo>
    {
        public ControlStateMachine(){
            States = new Dictionary<string, ControlState>();
        }

        /**
            SePlayerControllerStateInfoInitialState - does not call OnEnter!
        */
        public void SetInitialState(string stateName){
            if(!States.ContainsKey(stateName))
                throw new ApplicationException($"Unable to set the initial state - the specified state {stateName} does not exist.");

            CurrentState = States[stateName];
        }

        public void AddState(string stateName, ControlState state){
            state.SetChangeState(ChangeState);
            States.Add(stateName, state);
        }

        public void RemoveState(string stateName){
            States.Remove(stateName);
        }

        public void ChangeState(Transform transform, PlayerControllerStateInfo stateInfo, string nextStateName){
            if(States.ContainsKey(nextStateName)){
                CurrentState.OnExit(transform, stateInfo);
                CurrentState = States[nextStateName];
                CurrentState.OnEnter(transform, stateInfo);
            }
            // no-op?
        }

        public void Update(Transform transform, PlayerControllerStateInfo stateInfo, float deltaTime){
            CurrentState.Update(transform, stateInfo, deltaTime);
            CurrentState.CheckTransitions(transform, stateInfo);
        }

        #region properties
        public ControlState CurrentState { get; set; }
        public Dictionary<string, ControlState> States { get; set; }

        public static class StateNames {
            public const string DefaultState = "Default";
            public const string JumpState = "Jump";
        }

        #endregion
    }
}