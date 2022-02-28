using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    public int numberOfHits = 0;
    public int maxHits;
    public SpriteRenderer brickSprite;
    public float brickValue;
    public GameMaster gameMaster;
    public GameObject projectile;

    private AudioSource brickAudio;
    public AudioClip brickHit;
    public AudioClip brickBreak;

    // Start is called before the first frame update
    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();
        gameMaster.GetComponent<GameMaster>();
        brickAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        numberOfHits++;
      
        if (gameObject.tag == "2hitBrick")
        {
            brickSprite.color = new Color32(172, 255, 182, 255);
            brickAudio.PlayOneShot(brickHit, 0.3f);
        } 

        if (gameObject.tag == "enemy_brick")
        {
            brickSprite.color = new Color32(215, 75, 65, 255);
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            brickAudio.PlayOneShot(brickHit, 0.3f);
        }

        if (numberOfHits >= maxHits)
        {
            AudioSource.PlayClipAtPoint(brickBreak, new Vector2(0, 0), 2.0f);
            gameMaster.playerPoints = gameMaster.playerPoints + brickValue;
            Destroy(this.gameObject);
        }

        if (numberOfHits >= maxHits && gameObject.tag == "life brick")
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            Destroy(this.gameObject);
        }

        if (gameObject.tag == "power brick")
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            Destroy(this.gameObject);
        }


    }
}
