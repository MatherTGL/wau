using UnityEngine;
using Input_Control;

namespace ControlPlayer
{
    public sealed class PlayerControlSpace : IPlayerControl
    {
        private float _directionRotateVertical;
        private float _directionRotateHorizontal;

        private float _directionZoom;

        private GameObject _playerObject;

        private PlayerControlConfig _playerControlConfig;


        void IPlayerControl.Initialization(in GameObject playerObject, in PlayerControlConfig playerControlConfig)
        {
            _playerObject = playerObject;
            _playerControlConfig = playerControlConfig;
        }

        void IPlayerControl.Move()
        {
            //Vector3 directionMove = new Vector3(InputControl.AxisMoveHorizontal, 0.0f, InputControl.AxisMoveVertical) * Time.deltaTime;
            //_playerObject.transform.position += directionMove * speedMove;
        }

        void IPlayerControl.Rotation()
        {
            _directionRotateVertical = Mathf.Clamp(_directionRotateVertical, _playerControlConfig.minVerticalAngle, _playerControlConfig.maxVerticalAngle);

            _directionRotateVertical += InputControl.AxisMouseY * InputControl.AxisMouseRightButton * _playerControlConfig.speedRotation * Time.deltaTime;
            _directionRotateHorizontal += InputControl.AxisMouseX * InputControl.AxisMouseRightButton * _playerControlConfig.speedRotation * Time.deltaTime;

            Quaternion currentRotation = _playerObject.transform.parent.localRotation;

            Quaternion targetRotation = Quaternion.Euler(_playerObject.transform.parent.localRotation.x,
                                                         _playerObject.transform.parent.localRotation.y + _directionRotateHorizontal,
                                                         _playerObject.transform.parent.localRotation.z + _directionRotateVertical);

            _playerObject.transform.parent.localRotation = Quaternion.Lerp(currentRotation, targetRotation, _playerControlConfig.timeSpeedRotation);
        }

        void IPlayerControl.Zoom()
        {
            //_directionZoom = Mathf.Clamp(_directionZoom, 1000, 20000);

            _directionZoom += InputControl.AxisScrollWheel * _playerControlConfig.speedZoom;
            Debug.Log(_directionZoom + "L");

            Debug.Log(_directionZoom);
            Debug.Log(InputControl.AxisScrollWheel + "M");

            Vector3 neededPosition = _playerObject.transform.localPosition + new Vector3(_directionZoom, 0.0f, 0.0f);
            _directionZoom = 0.0f;

            Debug.Log($"C {_playerObject.transform.localPosition} N {neededPosition}");

            _playerObject.transform.localPosition = Vector3.Lerp(_playerObject.transform.localPosition, neededPosition, 0.25f * Time.deltaTime);


        }
    }
}