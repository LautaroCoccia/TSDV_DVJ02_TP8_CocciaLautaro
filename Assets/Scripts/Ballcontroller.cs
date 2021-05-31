using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float horizontalForce;
    [SerializeField] float verticalForce;
    [SerializeField] float increase;
    [SerializeField] Transform player;
    Rigidbody rb;
    Vector3 lastVelocity;
    enum BallState
    {
        init,
        move
    }
    BallState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BallState.init;
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BallState.init:
                rb.velocity = (Vector3.zero);
                transform.position = new Vector3(player.position.x, player.position.y + 1, 0);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(horizontalForce, verticalForce, 0);
                    state = BallState.move;
                }
                break;
            case BallState.move:
                lastVelocity = rb.velocity;
                if (transform.position.y < 0)
                {
                    state = BallState.init;
                    LevelManager.Get().UpdateLives();
                }
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction;
            direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        if(collision.gameObject.tag == "Player")
        {
            int changerDirection = 0;
            do
            {
                changerDirection = Random.Range(-1, 2);
            } while (changerDirection == 0);
            rb.velocity = new Vector3(direction.x * (speed) * increase  * changerDirection, direction.y  * (speed) *increase);
        }
        else
        {
            rb.velocity = new Vector3(direction.x * (speed) , direction.y  * (speed) );
        }

        if (collision.gameObject.tag == "Brick")
        {
            LevelManager.Get().UpdateObj();
            LevelManager.Get().UpdateScore();
            Destroy( collision.gameObject);
        }
    }
}
