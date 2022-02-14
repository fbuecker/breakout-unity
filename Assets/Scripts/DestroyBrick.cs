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
    public GameObject enemyProjectile;

    // Start is called before the first frame update
    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();
        gameMaster.GetComponent<GameMaster>();
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
        }

        if (gameObject.tag == "enemy_brick")
        {
            brickSprite.color = new Color32(215, 75, 65, 255);
            Instantiate(enemyProjectile, transform.position, enemyProjectile.transform.rotation);
        }
        
        if (numberOfHits >= maxHits)
        {
            gameMaster.playerPoints = gameMaster.playerPoints + brickValue;
            Destroy(this.gameObject);
        }


    }
}
