using UnityEngine;
using Input_Control;

namespace ControlPlayer
{
    public sealed class PlayerControlBase : IPlayerControl
    {
        private GameObject _playerObject;

        private PlayerControlConfig _playerControlConfig;


        void IPlayerControl.Initialization(in GameObject playerObject, in PlayerControlConfig playerControlConfig)
        {
            _playerObject = playerObject;
            _playerControlConfig = playerControlConfig;
        }

        void IPlayerControl.Move()
        {
            Vector3 directionMove = new Vector3(InputControl.AxisMoveHorizontal, 0.0f, InputControl.AxisMoveVertical) * Time.deltaTime;
            _playerObject.transform.position += directionMove * _playerControlConfig.speedMove;
        }

        void IPlayerControl.Rotation()
        {

        }

        void IPlayerControl.Zoom()
        {

        }
    }
}