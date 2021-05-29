using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float direction = Input.GetAxis("Horizontal");
        if(CollisionChecker(direction))
            transform.Translate(new Vector3(((direction * movementSpeed) * Time.deltaTime), 0, 0)) ; 
    }

    bool CollisionChecker(float direction)
    {
        RaycastHit hit;
        return !(Physics.Raycast(transform.position, new Vector3(direction, 0, 0), transform.localScale.x/2));
        
    }
}
