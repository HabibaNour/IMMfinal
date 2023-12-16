using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameManager gameManager;
    public float jumpForce = 3.0f;   //how high the player will jump
    public float gravityModifier = 2.0f;
    public bool IsOnGround = true;
    public bool gameOver = false;
   

    // particles and sounds
    public AudioClip bark;
    public AudioClip crash;
    public AudioSource player;
    public ParticleSystem explosion;
    public ParticleSystem ground;

   

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   //calling the method in the Rigidbody to control over the force and the gravity
          

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& IsOnGround  && !gameOver)   //when we press the space bar the player will jump
        {
           
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
            // makes sure particle stops playiing when in air
            ground.Stop();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            IsOnGround = true;
            ground.Play();
          
        }
        else if (other.gameObject.CompareTag("Fence"))
        {
            gameOver = true;
            player.PlayOneShot(crash, 1.0f);
            explosion.Play();
            player.Stop();
            ground.Stop();
            gameManager.GameOver();


        }
        else if (other.gameObject.CompareTag("Bone"))
        {
            
            player.PlayOneShot(bark, 1.0f);
            
            gameManager.AddScore(1);
            gameManager.finalScoreUpdate();
           
            Destroy(other.gameObject);

        }
        
    }
    // triggers on collision with bone 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Bone"))
        {
            Destroy(other.gameObject);
            gameManager.AddScore(1);
            player.PlayOneShot(bark, 1.0f);

        }
    }
    
 
}
