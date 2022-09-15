using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Planet
{
    [AddComponentMenu("Planet/Planet Movement")]
    [RequireComponent(typeof(RotationPlanets)), ExecuteAlways]
    public sealed class MovementPlanetOrbit : MonoBehaviour
    {
        [SerializeField, BoxGroup("Parameters"), Required]
        private MovementPlanetOrbitConfig _movementPlanetOrbitConfig;


        private void Awake() => _movementPlanetOrbitConfig.rigidbody = GetComponent<Rigidbody>();

        private void Start()
        {
            _movementPlanetOrbitConfig.currentSpeedPlanet = _movementPlanetOrbitConfig.defaultSpeedPlanet;

            if (_movementPlanetOrbitConfig.typeMovementPlanet == MovementPlanetOrbitConfig.TypeMovementPlanet.Physics)
                _movementPlanetOrbitConfig.rigidbody.AddForce(-_movementPlanetOrbitConfig.startVelocity, ForceMode.Impulse);
        }

        private void FixedUpdate()
        {
            MovePlanet();
            PhysicsMovePlanet(); 
        }

        private void PhysicsMovePlanet()
        {
            if (_movementPlanetOrbitConfig.typeMovementPlanet == MovementPlanetOrbitConfig.TypeMovementPlanet.Physics)
                _movementPlanetOrbitConfig.rigidbody.AddForce(CalculateForce(), ForceMode.Impulse);
        }

        private void MovePlanet()
        {
            if (_movementPlanetOrbitConfig.pointRotatePlanet is not null)
            {
                if (_movementPlanetOrbitConfig.typeMovementPlanet == MovementPlanetOrbitConfig.TypeMovementPlanet.NonPhysics)
                {
                    if (_movementPlanetOrbitConfig.centerRotation == MovementPlanetOrbitConfig.CenterRotation.Zero)
                    {
                        if (_movementPlanetOrbitConfig.isUseOffsetCenter)
                            _movementPlanetOrbitConfig.pointRotatePlanet.transform.position = Vector3.zero + _movementPlanetOrbitConfig.offsetCenter;
                        else
                            _movementPlanetOrbitConfig.pointRotatePlanet.transform.position = Vector3.zero;

                        _movementPlanetOrbitConfig.pointRotatePlanet.transform.Rotate(_movementPlanetOrbitConfig.directionRotate
                                                            * (float)_movementPlanetOrbitConfig.currentSpeedPlanet
                                                            * Time.deltaTime, Space.Self);                     
                    }
                    else
                    {
                        _movementPlanetOrbitConfig.pointRotatePlanet.transform.position = gameObject.transform.parent.position + _movementPlanetOrbitConfig.offsetCenter;
                        transform.RotateAround(_movementPlanetOrbitConfig.pointRotatePlanet.transform.position,
                                               _movementPlanetOrbitConfig.directionRotate * (float)_movementPlanetOrbitConfig.currentSpeedPlanet * Time.deltaTime,
                                               (float)_movementPlanetOrbitConfig.currentSpeedPlanet);
                    }
                }
            } 
        }

        private Vector3 CalculateForce()
        {
            float distance = Vector3.Distance(_movementPlanetOrbitConfig.parentPhysicsPlanet.transform.position, transform.position);
            float gravitationalConstant = 6.67f * Mathf.Pow(10, -11);
            float force = gravitationalConstant * _movementPlanetOrbitConfig.parentPhysicsPlanet.GetComponent<Rigidbody>().mass * _movementPlanetOrbitConfig.rigidbody.mass / distance * distance;
            Vector3 forceWithDirection = (force * (_movementPlanetOrbitConfig.parentPhysicsPlanet.transform.position - transform.position));
            _movementPlanetOrbitConfig.currentVelocity = _movementPlanetOrbitConfig.rigidbody.velocity;
            return forceWithDirection;
        }

#if UNITY_EDITOR

        private static bool _isUseDebug;

        #region Debug

        private static bool _isDebugName;
        private static bool _isDebugTypeMovement;

        #endregion


        private void Update() => MovePlanet();

        private void OnDrawGizmos()
        {
            if (_isUseDebug)
            {
                if (_isDebugName)
                    Handles.Label(transform.position, $"{gameObject.name} / {_movementPlanetOrbitConfig.defaultSpeedPlanet} kmh/s");

                Gizmos.color = Color.red;

                if (_isDebugTypeMovement)
                    Handles.Label(transform.position + Vector3.down * 2.0f, $"Type Move ({_movementPlanetOrbitConfig.typeMovementPlanet})");
            } 
        }

        #region Editor Functions

        public void ChangeSpeedPlanet(in int speed)
        {
            _movementPlanetOrbitConfig.currentSpeedPlanet = _movementPlanetOrbitConfig.defaultSpeedPlanet * speed;
        }

        public static void ActiveDebug(in bool state) => _isUseDebug = state;

        public static void ActiveDebugName(in bool state) => _isDebugName = state;

        public static void ActiveDebugTypeMove(in bool state) => _isDebugTypeMovement = state;

        #endregion
#endif
    }
}