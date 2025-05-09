using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CubeSpawner")]
class CubeSpawner : ScriptableObject
{
    public Cube Prefab => _prefab;
    public CubeNumbers Numbers => _numbers;
    public CubeColors Colors => _colors;

    [SerializeField] private Cube _prefab;
    [SerializeField] private CubeNumbers _numbers;
    [SerializeField] private CubeColors _colors;
}
