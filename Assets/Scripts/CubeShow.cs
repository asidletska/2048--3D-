using UnityEngine;

public class CubeShow : MonoBehaviour
{
    private const float BIAS = 0.12f;
    private const float MULTIPLIER = 0.14f;
    private CubeTextes textes => GetComponentInChildren<CubeTextes>();

    private Material material => GetComponentInChildren<MeshRenderer>().material;
    public void Change(int value)
    {
        textes.Chancetextes(value, material.color = CalculateColur(value));
    }
    private Color CalculateColur(int value)
    {
        float processedValue = value * MULTIPLIER + BIAS;
        float hue = processedValue - Mathf.Floor(processedValue);
        return Color.HSVToRGB(hue, 0.6f, 0.5f);
    }
}
