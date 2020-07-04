
using UnityEngine;

namespace FSM.StateInfo {
    public class BaseInputStateInfo {
        public virtual float HorizontalInput    => Input.GetAxis(InputNames.Horizontal); 
        public virtual float VerticalInput      => Input.GetAxis(InputNames.Vertical);
        public virtual float SpacebarInput      => Input.GetAxis(InputNames.Jump);
    }
}