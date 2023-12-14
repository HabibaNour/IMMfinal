using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 0.5f;   //how high the player will jump
    public float gravityModifier;
    public bool IsOnGround = true;
    public bool gameOver = false;

    
    public AudioClip bark;
    public AudioClip crash;
    public AudioSource player;
    private SpawnManager spawnManager;
    public GameManager gameManager;

    public bool hasPower;
    public int powerDuration = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   //calling the method in the Rigidbody to control over the force and the gravity
        Physics.gravity *= gravityModifier;    //it will make the player to stay on ground
        //player = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& IsOnGround  && !gameOver)   //when we press the space bar the player will jump
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            IsOnGround = true;
          
        }
        else if (other.gameObject.CompareTag("Fence"))
        {
            gameOver = true;
            player.PlayOneShot(crash, 1.0f);
            player.Stop();
            gameManager.GameOver();

        }
        else if (other.gameObject.CompareTag("Bone"))
        {
            
            player.PlayOneShot(bark, 1.0f);
            
            gameManager.AddScore(-1);
           // gameManager.highScoreUpdate();
           
            Destroy(other.gameObject);

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Bone"))
        {
            Destroy(other.gameObject);
            gameManager.AddScore(-1);

        }
    }
   

}
