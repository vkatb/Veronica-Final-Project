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
    private float jumpForce = 100;
    private float gravityModifier = 1.5f;

    private bool isOnGround = true;

    // PASSED VARIABLES/OBJECTS


    // RECEIVED VARIABLES/OBJECTS
    private LevelManager levelManager; // LevelManager code


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

    } // OnCollisionEnter ends




}
