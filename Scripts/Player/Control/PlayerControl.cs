using UnityEngine;
using Sirenix.OdinInspector;
using Input_Control;

namespace ControlPlayer
{
    [AddComponentMenu("Player/Player Control")]
    [RequireComponent(typeof(InputControl))]
    public sealed class PlayerControl : MonoBehaviour
    {
        [ShowInInspector, BoxGroup("Parameters"), ReadOnly, LabelText("Interface Control")]
        private IPlayerControl _IplayerControl;

        [SerializeField, BoxGroup("Parameters"), Required]
        private PlayerControlConfig _playerControlConfig;


        private void Awake() => CheckMovementType();

        private void Start() => _IplayerControl.Initialization(this.gameObject, _playerControlConfig);

        private void FixedUpdate()
        {
            _IplayerControl.Move();
            _IplayerControl.Rotation();
            _IplayerControl.Zoom();
        }

        private void CheckMovementType()
        {
            if (_playerControlConfig.TypeMovement == PlayerControlConfig.MovementType.Base)
                _IplayerControl = new PlayerControlBase();
            else if (_playerControlConfig.TypeMovement == PlayerControlConfig.MovementType.Space)
                _IplayerControl = new PlayerControlSpace();
        }
    }
}