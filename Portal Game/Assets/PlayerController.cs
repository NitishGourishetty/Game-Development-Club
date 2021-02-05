using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float sensitivity;
    public float gravity;
    public float jumpForce;
    public Camera camera;
    public bool isSprinting;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        float moveDirectionY = moveDirection.y;

        isSprinting = Input.GetKey(KeyCode.LeftShift);

        moveDirection = transform.right * xMove + transform.forward * zMove;

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            moveDirection.y = jumpForce;
        }
        else
        {
            moveDirection.y = moveDirectionY;
        }

        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        float speed = (isSprinting) ? runSpeed : walkSpeed;
        controller.Move(moveDirection * speed * Time.deltaTime);
        
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -45f, 45f);
        camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        float rotationY = Input.GetAxis("Mouse X") * sensitivity;
        transform.rotation *= Quaternion.Euler(0, rotationY, 0);
    }
}
