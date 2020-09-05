using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

    private new Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
