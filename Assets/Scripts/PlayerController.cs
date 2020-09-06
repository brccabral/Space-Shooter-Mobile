﻿using System;
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

    private Quaternion calibrationQuaternion;

    private new Rigidbody rigidbody;
    private new AudioSource audio;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        CalibrateAccellerometer();
    }

    private void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Vector3 accelerationRaw = Input.acceleration;
        Vector3 acceleration = FixAcceleration(accelerationRaw);

        Vector3 movement = new Vector3(acceleration.x, 0.0f, acceleration.y);
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
            newShot = Instantiate(shotPrefab, shotSpawn.position, Quaternion.identity) as GameObject;

            // create code here that animates the newShot

            nextFire -= myTime;
            myTime = 0.0f;
            audio.Play();
        }

    }

    //Used to calibrate the Input.acceleration input
    void CalibrateAccellerometer()
    {
        Vector3 accelarationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelarationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    //Get the 'calibrated' value from the Input
    Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }
}

[Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
