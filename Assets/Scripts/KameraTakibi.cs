using UnityEngine;

public class KameraTakibi : MonoBehaviour

{
    public Transform mum;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - mum.position;
    }
    void Update()
    {
        transform.position = mum.position + offset;
    }
}
