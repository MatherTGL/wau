using UnityEngine;
using Sirenix.OdinInspector;

namespace Input_Control
{
    [AddComponentMenu("Player/Input/Input Control")]
    public sealed class InputControl : MonoBehaviour
    {
        [BoxGroup("Input")]
        [ShowInInspector, ReadOnly, BoxGroup("Input/Move")]
        private static float _axisMoveVertical;
        public static float AxisMoveVertical => _axisMoveVertical;

        [ShowInInspector, ReadOnly, BoxGroup("Input/Move")]
        private static float _axisMoveHorizontal;
        public static float AxisMoveHorizontal => _axisMoveHorizontal;

        [ShowInInspector, ReadOnly, BoxGroup("Input/Rotation")]
        private static float _axisRotation;
        public static float AxisRotation => _axisRotation;

        [ShowInInspector, ReadOnly, BoxGroup("Input/Mouse/Scroll Wheel (Zoom)")]
        private static float _axisScrollWheel;
        public static float AxisScrollWheel => _axisScrollWheel;

        [ShowInInspector, ReadOnly, BoxGroup("Input/Mouse")]
        private static float _axisMouseX;
        public static float AxisMouseX => _axisMouseX;

        [ShowInInspector, ReadOnly, BoxGroup("Input/Mouse")]
        private static float _axisMouseY;
        public static float AxisMouseY => _axisMouseY;

        [ShowInInspector, ReadOnly, BoxGroup("Input/Mouse")]
        private static float _axisMouseAverage;
        public static float AxisMouseAverage => _axisMouseAverage;

        [ShowInInspector, ReadOnly, BoxGroup("Input/Mouse")]
        private static float _axisMouseRightButton;
        public static float AxisMouseRightButton => _axisMouseRightButton;


        private void Update() => DetectInput();

        private void DetectInput()
        {
            _axisMoveVertical = Input.GetAxis("Vertical");
            _axisMoveHorizontal = Input.GetAxis("Horizontal");

            _axisRotation = Input.GetAxisRaw("Rotation");

            _axisScrollWheel = Mathf.SmoothStep(0.0f, Input.GetAxis("Mouse ScrollWheel"), 0.25f);

            _axisMouseX = Input.GetAxis("Mouse X");
            _axisMouseY = Input.GetAxis("Mouse Y");

            _axisMouseAverage = Input.GetAxisRaw("Mouse2");
            _axisMouseRightButton = Input.GetAxisRaw("Mouse1");
        }
    }
}