using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow1 : MonoBehaviour
{
    public Transform target;
    private float smoothSpeed = 5f;
    private Vector3 offset = new Vector3(0, 2, -10);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired rotation based on the player's rotation
            Quaternion rotation = Quaternion.Euler(11, target.eulerAngles.y, 0);

            // Calculate the desired position relative to the player's position
            Vector3 desiredPosition = target.position + rotation * offset;

            // Smoothly move and rotate the camera towards the desired position and rotation
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, smoothSpeed * Time.deltaTime);
        }
    }
}
