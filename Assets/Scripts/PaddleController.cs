using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float playerInput;
    public float paddleSpeed;
    public BallController ballController;
    public float maxBounceAngle = 75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * paddleSpeed * playerInput);
    }

    //function to handle ball launch angle off paddle (code based on tutorial from https://www.youtube.com/watch?v=RYG8UExRkhA with minor tweaks)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //aquires Vector2 data for paddle position and ball contact point
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            //determines what the offset from the center is for ball collision
            float offset = paddlePosition.x - contactPoint.x;
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            //determines the ball was travelling at on collision, calculates what bounce angle should be, applies force to create new angle while not exceeding max angle (75)
            float currentAngle = Vector2.SignedAngle(Vector2.up, ballController.ballRigidbody.velocity);
            float bounceAngle = (offset / maxOffset) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            //fancy math that makes the angle actually change
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

            //updates the ball rigidbody
            ballController.ballRigidbody.velocity = rotation * Vector2.up * ballController.ballRigidbody.velocity.magnitude;
        }
    }
}
