using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(((Input.GetAxis("Horizontal") * movementSpeed) * Time.deltaTime), 0, 0));
    }
}
