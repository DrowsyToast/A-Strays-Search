using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Rigidbody playerRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    private GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = FindObjectOfType<Camera>().gameObject;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        CursorLock();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            MovePlayer();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
    //Moves the Player with WASD and allows Player to jump by pressing Space
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0) * Vector3.right * speed * horizontalInput);
        playerRb.AddForce(Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0) * Vector3.forward * speed * verticalInput);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
        }
    }
    void CursorLock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
