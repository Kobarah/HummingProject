using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float range = 90;
    private float rotationDegrees = 0;
    public float rotationIntensity = 1;
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rotationDegrees += moveHorizontal;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationDegrees * rotationIntensity);
    }
}