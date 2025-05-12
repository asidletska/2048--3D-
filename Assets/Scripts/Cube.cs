using System;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube, Cube> Collide;
    public ParticleSystem star;
    public new AudioSource audio;
    public bool IsKinematic { get; private set; }

    public int Number
    {
        get => _number;
        set => UpdateNumber(_number = value);
    }
    private int _number;

    public Color Color
    {
        get => _color;
        set => UpdateColor(_color = value);
    }
    private Color _color;

    [Header("Texts")]
    [SerializeField] private TMP_Text[] _textNumbers;

    private Renderer _renderer;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(int number, Color color)
    {
        Number = number;
        Color = color;
    }

    public void Throw(Vector3 direction, float force)
    {
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
    public void Rotate(Vector3 torque)
    {
        _rigidbody.AddTorque(torque, ForceMode.Impulse);
    }

    public void EnableKinematic()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        IsKinematic = true;
    }
    public void DisableKinematic()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        IsKinematic = false;
    }

    private void UpdateColor(Color color)
    {
        _renderer.material.color = color;
    }
    private void UpdateNumber(int number)
    {
        foreach (var textField in _textNumbers)
            textField.text = number.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
            OnCollideWithCube(cube);
    }
    private void OnCollideWithCube(Cube cube)
    {
        if (cube.IsKinematic) return;

        if (cube.Number == Number)
            OnCollideWithSameNumber(cube);
    }
    private void OnCollideWithSameNumber(Cube cube)
    {
        Collide?.Invoke(this, cube);
        star.Play();
        audio.Play();
        ScoreManager.Instance.AddScore(Number);
    }
}
