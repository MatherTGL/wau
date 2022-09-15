using UnityEditor;
using UnityEditor.SceneManagement;

public sealed class LoadingScenesEditor : Editor
{
    [MenuItem("Open Scene/Solar System")]
    private static void OpenSceneSolarSystem()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Main/SpaceSolarSystem.unity");
    }

    [MenuItem("Open Scene/Earth Launch Complex")]
    private static void OpenSceneEarthLaunchComplex()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Earth Station/EarthLaunchComplex.unity");
    }

    [MenuItem("Open Scene/Loading/Templates/In Develop")]
    private static void LoadingTemplateSceneObjects()
    {
        
    }

    #region Planets

    [MenuItem("Open Scene/Planets/Mercury")]
    private static void OpenScenePlanetMercury()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetMercury.unity");
    }

    [MenuItem("Open Scene/Planets/Venus")]
    private static void OpenScenePlanetVenus()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetVenus.unity");
    }

    [MenuItem("Open Scene/Planets/Earth")]
    private static void OpenScenePlanetEarth()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetEarth.unity");
    }

    [MenuItem("Open Scene/Planets/Mars")]
    private static void OpenScenePlanetMars()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetMars.unity");
    }

    [MenuItem("Open Scene/Planets/Jupiter")]
    private static void OpenScenePlanetJupiter()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetJupiter.unity");
    }

    [MenuItem("Open Scene/Planets/Saturn")]
    private static void OpenScenePlanetSaturn()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetSaturn.unity");
    }

    [MenuItem("Open Scene/Planets/Uranus")]
    private static void OpenScenePlanetUranus()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetUranus.unity");
    }

    [MenuItem("Open Scene/Planets/Neptune")]
    private static void OpenScenePlanetNeptune()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetNeptune.unity");
    }

    [MenuItem("Open Scene/Planets/Pluto")]
    private static void OpenScenePlanetPluto()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Planets/ScenePlanetPluto.unity");
    }

    #endregion

    #region Satellite

    [MenuItem("Open Scene/Satellite/Moon")]
    private static void OpenSceneSatelliteMoon()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Satellite/SceneSatelliteMoon.unity");
    }

    #endregion

    #region Asteroids

    [MenuItem("Open Scene/Asteroids/Ceres")]
    private static void OpenSceneAsteroidCeres()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Asteroids/SceneAsteroidCeres.unity");
    }

    [MenuItem("Open Scene/Asteroids/Vesta")]
    private static void OpenSceneAsteroidVesta()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Asteroids/SceneAsteroidVesta.unity");
    }

    #endregion
}
