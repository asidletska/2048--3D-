using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnZoneCube spawnPoint;
    [SerializeField] private CubeConnectionCheck connectCheck;
    [SerializeField] private CubeController _controller;

    private void Start()
    {
        NewGame();
    }
    public void NewGame()
    {

        _controller.Detached += OnCubeDetach;
        connectCheck.Combined += OnCubeCombined;

        SpawnNewCube();
    }
    private void OnDisable()
    {
        _controller.Detached -= OnCubeDetach;
        connectCheck.Combined -= OnCubeCombined;
    }

    private void OnCubeDetach(Cube cube)
    {
        cube.Collide += OnCubeCollide;

        SpawnNewCube();
    }
    private void SpawnNewCube()
    {
        var cube = spawnPoint.SpawnRandom();
        _controller.Attach(cube);
    }

    private void OnCubeCollide(Cube cube1, Cube cube2)
    {
        connectCheck.Combine(cube1, cube2);

        cube1.Collide -= OnCubeCollide;
        cube2.Collide -= OnCubeCollide;
    }
    private void OnCubeCombined(Cube cube)
    {
        cube.Collide += OnCubeCollide;
    }
}

