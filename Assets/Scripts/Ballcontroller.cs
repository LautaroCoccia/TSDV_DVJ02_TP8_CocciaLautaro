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
                    state = BallState.init;
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction;
        if(collision.gameObject.tag == "Player")
        {
            int i;
            do
            {
                i = Random.Range(-1, 1);
            } while (i == 0);
            direction = Vector3.Reflect(lastVelocity.normalized * i, collision.contacts[0].normal);
        }
        else
        {
            direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        }
        rb.velocity = new Vector3( direction.x * Mathf.Max(speed, 0f) + increase, direction.y * Mathf.Max(speed, 0f) + increase);
    }
}
