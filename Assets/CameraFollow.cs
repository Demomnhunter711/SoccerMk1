using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform player;

    public float mouseSensitivity = 200f;
    public float distance = 8f;
    public float height = 5f;

    private float yaw = 0f;
    private float pitch = 20f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate camera based on mouse
        yaw += mouseX * mouseSensitivity * Time.deltaTime;
        pitch -= mouseY * mouseSensitivity * Time.deltaTime;

        // Prevent camera from going upside down
        pitch = Mathf.Clamp(pitch, -10f, 60f);

        // Create camera rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Position camera behind player
        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        transform.position = player.position + offset + Vector3.up * height;

        // Look toward player
        transform.LookAt(player.position + Vector3.up * 1f);
    }
    // public Transform player;
    // public float mouseSensitvitiy = 200f;
    // public float distance = 8f;
    // public float height = 5f;
    // private float rotationY = 0f;

    // void LateUpdate()
    // {
    //     //getting mouse movement
    //     float mouseX = Input.GetAxis("Mouse X");

    //     //rotate camera around player
    //     rotationY += mouseX * mouseSensitvitiy * Time.deltaTime;

    //     //Calculate camera position
    //     Quaternion rotation = Quaternion.Euler(0,rotationY, 0);

    //     Vector3 offset = rotation * new Vector3(0, height, -distance);

    //     transform.position = player.position + offset;

    //     //Look at the Player
    //     transform.LookAt(player.position);
    // }
   // public Transform target;

   // public Vector3 offset = new Vector3(0, 8, -8);

    // void LateUpdate()
    // {
    //     transform.position = target.position + offset;
    // }
}
