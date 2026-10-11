using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f; // Tốc độ di chuyển

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        // Khởi tạo các thành phần
        floorMask = LayerMask.GetMask("Floor"); // Lấy layer mặt sàn để xoay người
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Lấy nút bấm di chuyển (A, D, W, S hoặc mũi tên)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        // Tính toán hướng di chuyển
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // Tính toán hướng xoay người theo con trỏ chuột
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        // Nếu có bấm nút di chuyển thì chạy hoạt ảnh IsWalking
        bool walking = h != 0f || v != 0f;
        if(anim != null) {
            anim.SetBool("IsWalking", walking);
        }
    }
}
