using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CubeConnection")]
class CubeConnection : ScriptableObject
{
    public CubeNumbers Number => _number;
    public CubeColors Colors => _colors;
    public float PushUpForce => _pushUpForce;
    public float CombineDuration => _combineDuration;

    [Header("References")]
    [SerializeField] private CubeNumbers _number;
    [SerializeField] private CubeColors _colors;
    [Header("Parameters")]
    [SerializeField] private float _pushUpForce;
    [SerializeField] private float _combineDuration;
}
