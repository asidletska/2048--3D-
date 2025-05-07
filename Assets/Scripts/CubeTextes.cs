using TMPro;
using UnityEngine;

public class CubeTextes : MonoBehaviour
{
    private static string[] _textes =
        { "2", "4", "8", "16", "32", "64", "128", "256", "512", "1024", "2048", "4096", "8192", "16384", "32768"
    };

    private TMP_Text[] _text => GetComponentsInChildren<TMP_Text>();

    public void Chancetextes (int value, Color color)
    {
        foreach (TMP_Text text in _text)
        {
            text.color = color;
            text.text = _textes[value];
        }
    }
}
