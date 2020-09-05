using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ; // same as Quad Scale Y in the background transformation
    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);

        transform.position = Vector3.forward * newPosition;
    }
}
