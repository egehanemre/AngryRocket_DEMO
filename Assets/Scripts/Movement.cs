using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationSpeed = 25f;
    [SerializeField] AudioClip mainAudioEngine;
    [SerializeField] ParticleSystem thrusterParticles;


    Rigidbody rb;
    AudioSource m_audio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        ProcessThrust();
        InputManager();
        AudioManager();
    }

    void InputManager()
    {
        if(Input.GetKey(KeyCode.A)) 
        {
            RotationManager(rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotationManager(-rotationSpeed);
        }
    }
    void RotationManager(float speed)
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            rb.freezeRotation = true;
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }

    void AudioManager()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!m_audio.isPlaying)
            {
                m_audio.PlayOneShot(mainAudioEngine);
                thrusterParticles.Play();
            }
        }
        else
        {
            m_audio.Stop();
            thrusterParticles.Stop();
        }
    }
}
