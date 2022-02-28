using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownward : MonoBehaviour
{
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    //if the projectile reaches the defeat zone, destroy it
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DefeatZone")
        {
            Destroy(gameObject);
        }
    }
}
