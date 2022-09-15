using UnityEngine;
using Sirenix.OdinInspector;

namespace Planet
{
    [AddComponentMenu("Planet/Planet Rotation")]
    public sealed class RotationPlanets : MonoBehaviour
    {
        [SerializeField, BoxGroup("Parameters"), Required, LabelText("Config")]
        private MovementPlanetOrbitConfig _movementPlanetOrbitConfig;


        private void FixedUpdate() => RotatePlanet();

        private void RotatePlanet()
        {
            transform.Rotate(Vector3.up * _movementPlanetOrbitConfig.speedRotation * Time.deltaTime, (Space)_movementPlanetOrbitConfig.typeSpaceRotate);
        }
    }
}