using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tiltX;
    public float tiltZ;
    public Boundary boundary;

    public GameObject shotPrefab;
    private GameObject newShot;
    public Transform shotSpawn;
    public float fireDelta = 0.5f;
    private float nextFire = 0.5f;
    private float myTime = 0.0f;

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

    private void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            newShot = Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation) as GameObject;

            // create code here that animates the newShot

            nextFire -= myTime;
            myTime = 0.0f;
        }

    }
}

[Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
