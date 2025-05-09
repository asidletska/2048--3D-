using UnityEngine;

public class SpawnZoneCube : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CubeSpawner _data;
    [SerializeField] private Transform _spawnPoint;

    public Cube SpawnRandom()
    {
        var randomNumber = _data.Numbers.Generate();
        return Spawn(randomNumber);
    }

    private Cube Spawn(int number)
    {
        var index = _data.Numbers.GetIndex(number);
        var color = _data.Colors.GetColor(index);

        return Spawn(_spawnPoint.position, number, color);
    }
    private Cube Spawn(Vector3 position, int number, Color color)
    {
        var cube = Instantiate(_data.Prefab, position, Quaternion.identity);
        cube.Initialize(number, color);

        return cube;
    }
}
