using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 1;
    [SerializeField] private float jumpDuration = 1;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseSensitivity = 100f;

    private float verticalMovement;
    private float horizontalMovement;
    private float mouseX;
    private float mouseY;

    [SerializeField] Camera fpsCam;

    private float xRotation = 0f;

    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerJump()
    {
        float g = -2 * jumpHeight / (jumpDuration * jumpDuration);

        if (GetComponent<Rigidbody>().velocity.y < 0)
        {
            g *= 4;
        }

        float v = -g * jumpDuration;

        Physics.gravity = new Vector3(0, g, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * v;
        }
    }

    void PlayerMovement()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        fpsCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Vector3 moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        moveDirection.y = 0f;
        moveDirection.Normalize();
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

}
