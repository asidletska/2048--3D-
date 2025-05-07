using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _value;

    public int Value
    {
        get => _value; set { _value = value; _show.Change(_value); }
    }

    [SerializeField]
    private int _initialValue;

    private CubeShow _show;

    private void Start()
    {
        _show = GetComponent<CubeShow>();
        Value = _initialValue;
    }
}
