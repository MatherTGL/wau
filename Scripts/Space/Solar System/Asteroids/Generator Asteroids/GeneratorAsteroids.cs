using UnityEngine;
using Sirenix.OdinInspector;
using Planet;

#if UNITY_EDITOR
[ExecuteInEditMode]
public sealed class GeneratorAsteroids : MonoBehaviour
{
    [SerializeField, Required, BoxGroup("Parameters")]
    private GameObject[] _meshAsteroid;

    [SerializeField, Required, BoxGroup("Parameters")]
    private GameObject _parentGeneratedObjects;

    [EnumToggleButtons]
    private enum TypeAsteroids
    {
        S, C, M, B
    }

    [SerializeField, BoxGroup("Parameters")]
    private TypeAsteroids _typeAsteroids;


    [Button("Generate", ButtonSizes.Large, ButtonStyle.Box)]
    [BoxGroup("Parameters")]
    private void GenerateAsteroid()
    {
        if (_meshAsteroid is not null)
        {
            #region Rotation Object
            float rotationObjectX = Random.Range(0.0f, 360.0f);
            float rotationObjectY = Random.Range(0.0f, 360.0f);
            float rotationObjectZ = Random.Range(0.0f, 360.0f);

            Vector3 rotationObject = new Vector3(rotationObjectX, rotationObjectY, rotationObjectZ);
            #endregion

            GameObject generatedObject = Instantiate(_meshAsteroid[Random.Range(0,
                _meshAsteroid.Length)], transform.position, Quaternion.Euler(rotationObject), _parentGeneratedObjects.transform);

            #region Add Components
            generatedObject.AddComponent<TrailRenderer>();
            generatedObject.AddComponent<RotationPlanets>();
            generatedObject.AddComponent<MovementPlanetOrbit>();
            generatedObject.AddComponent<PlanetConditionsData>();
            generatedObject.AddComponent<PlanetResourcesData>();
            #endregion

            generatedObject.name = $"DO(Space_Obj/Asteroids)_{_typeAsteroids}_{Random.Range(1, 9999)}";
        }           
    }
}
#endif