using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // Mục tiêu để camera đi theo (nhân vật)
    public float smoothing = 5f;        // Độ mượt khi di chuyển camera

    Vector3 offset;                     // Khoảng cách ban đầu giữa camera và nhân vật

    void Start()
    {
        // Tính khoảng cách ban đầu
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Vị trí camera cần đi tới
            Vector3 targetCamPos = target.position + offset;

            // Di chuyển camera mượt mà
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}