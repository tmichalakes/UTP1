


namespace FSM.StateInfo {
    // every element of this class should be virtual
    public class BaseStateInfo {
        public virtual float Acceleration       { get; set; }
        public virtual float Deceleration       { get; set; }
        public virtual float Speed              { get; set; }
        public virtual float MaxSpeed           { get; set; }
        public virtual float MinSpeed           { get; set; }
        public virtual float TurnRate           { get; set; }
        public virtual float MaxTurnRate        { get; set; }
        public virtual float BaseTurnDelta      { get; set; }
        public virtual BaseInputStateInfo Input { get; set; }
        public virtual float BaseTurnRateSpeedAdjustmentConstant { get; set; }
        public virtual float TurnDelta => (Speed / MaxSpeed) * (BaseTurnDelta);
    }
}