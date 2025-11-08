using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionAsset actionAsset;
    [SerializeField] float speed = 2;
    [SerializeField] float cameraSpeed = 2;
    Rigidbody rb;
    InputAction moveAction;
    InputAction cameraAction;
    InputAction camLockAction;
    Vector2 moveInput;
    float cameraInput;
    bool camLocked = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        moveAction = actionAsset.FindActionMap("Player").FindAction("Move");
        cameraAction = actionAsset.FindActionMap("Player").FindAction("Look");
        camLockAction = actionAsset.FindActionMap("Player").FindAction("ToggleCamLock");
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamLocked();
        if (camLocked)
        {
            MoveInput();
            CameraInput();
        }
    }

    private void HandleCamLocked()
    {
        if (camLockAction.WasPressedThisFrame())
        {
            camLocked = !camLocked;
        }
        if (camLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void MoveInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = (transform.forward * speed * moveInput.y) + (transform.right * speed * moveInput.x);
    }

    private void CameraInput()
    {
        cameraInput = cameraAction.ReadValue<Vector2>().x;
        transform.localEulerAngles += new Vector3(0, cameraInput * cameraSpeed) * Time.deltaTime;
        //transform.rotation += Quaternion.Euler(new Vector3(0, cameraInput * cameraSpeed));

    }
}
