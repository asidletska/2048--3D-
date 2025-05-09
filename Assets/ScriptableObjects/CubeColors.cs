using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/CubeColors")]
class CubeColors: ScriptableObject
{
    [SerializeField] private Color32[] _colors;

    public Color32 GetColor(int index)
    {
        var countColors = _colors.Length;

        if (countColors == 0)
            return Color.black;

        if (countColors > index)
            return _colors[index];

        var lastIndex = countColors - 1;
        return _colors[lastIndex];
    }
}
