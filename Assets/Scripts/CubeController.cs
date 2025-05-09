using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float throwForce = 500f;
    public float minX = -2.5f;
    public float maxX = 2.5f;

    private Rigidbody rb;
    private bool isDragging = false;
    private bool isThrown = false;

    private Vector2 startTouchPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (isThrown) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ќтримуЇмо позиц≥ю пальц€ у св≥тових координатах
            float zDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
            Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, zDistance));

            // ѕерем≥щенн€ лише по X, обмежене minX та maxX
            float clampedX = Mathf.Clamp(touchWorldPos.x, minX, maxX);
            Vector3 targetPos = new Vector3(clampedX, transform.position.y, transform.position.z);

            // ѕлавне перем≥щенн€ (без ф≥зики)
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

            //  оли палець в≥дпускаЇтьс€ Ч кидаЇмо кубик вперед
            if (touch.phase == TouchPhase.Ended)
            {
                ThrowForward();
            }
        }
    }

    public void ThrowForward()
    {
        isThrown = true;
        rb.isKinematic = false;
        rb.AddForce(Vector3.forward * throwForce);
    }
}
