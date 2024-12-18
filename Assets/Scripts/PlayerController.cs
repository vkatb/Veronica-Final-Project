using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PLAYER ONLY VARIABLES/OBJECTS
    private GameObject playerParts;
    private Rigidbody playerRb;
    //private AudioSource playerAudio;

    private float horizontalInput;
    private float speed = 8;
    private float jumpForce = 125;
    private float bounceForce = 200;
    private float gravityModifier = 1.6f;

    private bool isOnGround = true;

    // VARIABLES FOR CAMERA CONTROL
    private float cameraSpeed = 10;
    private float cameraReturnSpeed = 5;
    private float cameraBoundsZ = 3;
    private float cameraDefaultZ = -1.4f;

    // RECEIVED VARIABLES/OBJECTS
    private LevelManager levelManager; // LevelManager code
    
    // VARIABLES/OBJECTS ASSIGNED IN UNITY
    public GameObject mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerParts = transform.GetChild(0).gameObject;
        // playerAudio = GetComponent<AudioSource>();

        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();

        Physics.gravity *= gravityModifier;

    } // Start ends

    // Update is called once per frame
    void Update()
    {
        if (levelManager.isGameActive) // Prevents motion when game over
        {
            // Horizontal Movement:
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            // Jump:
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                // playerAudio.PlayOneShot(jumpSound1, 1.0f);
            }

            // Move Camera Up And Down:
            
            
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // When pressing up
            {
                if (mainCamera.transform.localPosition.z > -cameraBoundsZ) { // if in bounds, move
                    mainCamera.transform.Translate(Vector3.up * Time.deltaTime * cameraSpeed);
                }
                else if (mainCamera.transform.localPosition.z < -cameraBoundsZ) { //if not in bounds, go to limit
                    mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, -cameraBoundsZ);
                }
            }
            
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // When pressing down (prioritizes pressing up, so you can't do both at once)
            {
                if (mainCamera.transform.localPosition.z < cameraBoundsZ) { // if in bounds, move
                    mainCamera.transform.Translate(Vector3.down * Time.deltaTime * cameraSpeed);
                }
                else if (mainCamera.transform.localPosition.z > cameraBoundsZ) { //if not in bounds, go to limit
                    mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, cameraBoundsZ);
                }
            }

            else // When not pressing
            {
                if (mainCamera.transform.localPosition.z != cameraDefaultZ) { // if not at default, set to default
                    mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, cameraDefaultZ);
                }
            }

        }

    } // Update ends

    private void OnTriggerEnter(Collider other)
    {
        // Compare Tags for different reactions to objects:
        if (other.gameObject.CompareTag("Carrot"))
        {
            Destroy(other.gameObject);
            levelManager.UpdateScore(1);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            levelManager.LevelComplete();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            levelManager.LevelFailed();
        }

    } // OnTriggerEnter ends

    private void OnCollisionEnter(Collision collision)
    {
        // Track if on ground:
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Bouncepad"))
        {
             playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
             isOnGround = false;
        }

    } // OnCollisionEnter ends




}
