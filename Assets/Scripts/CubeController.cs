using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour
{
    public event Action<Cube> Detached;

    public float throwForce = 500f;

    [SerializeField] private Transform cubeTransform;
    [SerializeField] private Cube cubeRb;
    [SerializeField] private InputAction touchInput;
    [SerializeField] private InputAction touchPosition;

    private bool isDragging = false;
    private Camera mainCamera;
    private float distanceFromCamera;

    private void OnEnable()
    {
        touchInput.Enable();
        touchPosition.Enable();
    }

    private void OnDisable()
    {
        touchInput.Disable();
        touchPosition.Disable();
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        distanceFromCamera = Mathf.Abs(mainCamera.transform.position.z - cubeTransform.position.z);
    }

    private void Update()
    {
        if (HasTouch())
        {
            if (!isDragging)
            {
                StartDrag();
            }

            DragCube();
        }
        else if (isDragging)
        {
            EndDrag();
        }
    }

    private bool HasTouch()
    {
        return touchInput.ReadValue<float>() > 0f;
    }

    private Vector3 GetTouchWorldPosition()
    {
        Vector2 screenTouchPos = touchPosition.ReadValue<Vector2>();
        Vector3 screenPoint = new Vector3(screenTouchPos.x, screenTouchPos.y, distanceFromCamera);
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(screenPoint);
        return worldPos;
    }

    private void StartDrag()
    {
        isDragging = true;
    }

    private void DragCube()
    {
        Vector3 touchPos = GetTouchWorldPosition();
        Vector3 newPos = cubeTransform.position;
        newPos.x = touchPos.x;

        cubeTransform.position = newPos;
    }
    public void Attach(Cube cube)
    {
        cubeRb = cube;
        cubeTransform = cube.transform;
        cubeRb.EnableKinematic();

    }
    public void EndDrag()
    {
        isDragging = false;
        cubeRb.DisableKinematic();
        cubeRb.Throw(Vector3.forward, throwForce);
        Detached?.Invoke(cubeRb);
    }
}



