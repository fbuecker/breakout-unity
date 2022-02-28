using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool ballLaunched = false;
    public Rigidbody2D ballRigidbody;
    public Vector2[] startDirections;
    public int randomNumber;
    public float ballForce;
    public Vector3 startPosition;

    public GameMaster gameMaster;

    private AudioSource hitSFX;
    public AudioClip paddleBounce;
    public AudioClip hitUnbreakable;
    public AudioClip launchBall;
    public AudioClip deathSound;
 

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        hitSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !ballLaunched)
        {
            //launch ball
            randomNumber = Random.Range(0, startDirections.Length);
            ballRigidbody.AddForce(startDirections[randomNumber] * ballForce, ForceMode2D.Impulse);
            ballLaunched = true;
            hitSFX.PlayOneShot(launchBall, 0.4f);
        }
        //ball reset by pressing R cheat
        if (Input.GetKeyDown(KeyCode.R) && ballLaunched)
        {
            ballRigidbody.velocity = Vector3.zero;
            transform.position = startPosition;
            ballLaunched = false;
        }
    }
    //on ball contact with defeat zone, causes the ball to reset and the game master to remove one of the player's lives
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DefeatZone")
        {
            hitSFX.PlayOneShot(deathSound, 0.5f);
            ballRigidbody.velocity = Vector3.zero;
            gameMaster.playerLives = gameMaster.playerLives - 1;
            transform.position = startPosition;
            ballLaunched = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
     if (other.gameObject.tag == "Paddle")
        {
            hitSFX.PlayOneShot(paddleBounce, 0.3f);
        }

     if (other.gameObject.tag == "unbreakable")
        {
            hitSFX.PlayOneShot(hitUnbreakable, 0.1f);
        }
    }
}
