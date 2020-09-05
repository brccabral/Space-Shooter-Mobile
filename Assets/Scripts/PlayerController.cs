using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tiltX;
    public float tiltZ;
    public Boundary boundary;
    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax));

        rigidbody.rotation = Quaternion.Euler(rigidbody.velocity.z * tiltX, 0.0f, rigidbody.velocity.x * -tiltZ);
    }
}

[Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
