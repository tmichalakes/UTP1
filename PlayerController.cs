using UnityEngine;
using FSM.StateInfo;
using FSM.States.ControlStates;
using FSM.StateMachines;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VelocityUnit = Vector3.forward;
        // attach the properties of the PlayerController to a StateInfoObject
        StateInfo = new PlayerControllerStateInfo {
            Acceleration        = GasAcceleration,
            Deceleration        = BreakAcceleration,
            Speed               = Speed,
            MaxSpeed            = MaxSpeed,
            MinSpeed            = 0f,
            MaxTurnRate         = MaxTurnRate,
            BaseTurnDelta       = BaseTurnDelta,
            Input               = new BaseInputStateInfo(),
            BoostSpeed          = BoostSpeed,
            BoostDegredation    = BoostDegredation,
            BaseTurnRateSpeedAdjustmentConstant = BaseTurnRateSpeedAdjustmentConstant
        };

        ControlStateMachine = new ControlStateMachine();
        ControlStateMachine.AddState(ControlStateMachine.StateNames.DefaultState, new MovementControlState());
        ControlStateMachine.AddState(ControlStateMachine.StateNames.JumpState, new BoostControlState());
        ControlStateMachine.SetInitialState(ControlStateMachine.StateNames.DefaultState);
    }

    void FixedUpdate() {
        SetViewables();
        ControlStateMachine.Update(transform, StateInfo, Time.fixedDeltaTime);
    }

    public void SetViewables(){
        if(debug){
            ViewableSpeed = StateInfo.Speed;
            ViewableHInput = StateInfo.Input.HorizontalInput;
            ViewableJInput = StateInfo.Input.SpacebarInput;
            ViewableVInput = StateInfo.Input.VerticalInput;
        }
    }

    #region properties
    public bool debug => true;
    public PlayerControllerStateInfo StateInfo;
    public ControlStateMachine ControlStateMachine;
    public string Flag;
    public float horizontalInput;
    public float verticalInput;
    public float GasAcceleration = 10f;
    public float BreakAcceleration = 25f;
    public float Speed = 0f;
    public float TurnRate = 0f;
    public Vector3 VelocityUnit {
        get => transform.forward;
        set => transform.forward = value;
    }
    public float MaxSpeed = 25f;
    public float MaxTurnRate = 10f;
    public float BaseTurnDelta = 0.1f;
    public float BoostSpeed = 50;
    public float BoostDegredation = 25;
    public float BaseTurnRateSpeedAdjustmentConstant = 5.0f;
    public float TurnDelta => BaseTurnDelta - BaseTurnRateSpeedAdjustmentConstant * (Speed / MaxSpeed);

    public float ViewableSpeed;
    public float ViewableHInput;
    public float ViewableVInput;
    public float ViewableJInput;
    #endregion
}
