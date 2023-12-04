using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 50;
    private float turnSpeed = 40;

    public AudioClip moveSound;  
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to the player
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        // Play or stop the audio based on player movement
        if (Mathf.Abs(verticalInput) > 0.1f || Mathf.Abs(horizontalInput) > 0.1f)
        {
            // Player is moving, play the audio
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(moveSound);
            }
        }
        else
        {
            // Player is not moving, stop the audio
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "PowerUp" tag
        if (other.CompareTag("PowerUp"))
        {
            // Increase player speed by 5
            speed += 5;
            Destroy(other.gameObject);
        }
    }
}
