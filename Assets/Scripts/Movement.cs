using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationSpeed = 25f;
    public float maxFuel = 100;
    public static float currentFuel;
    public float fuelConsumptionRate = 5f;
    public bool isRocketActive = true;
    public bool isRight, isLeft, isBoost;

    [SerializeField] AudioClip mainAudioEngine;

    [SerializeField] ParticleSystem thrusterParticles;
    [SerializeField] ParticleSystem rightParticles;
    [SerializeField] ParticleSystem leftParticles;


    Rigidbody rb;
    AudioSource m_audio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_audio = GetComponent<AudioSource>();

        //Always Start With Full Fuel
        currentFuel = maxFuel;
    }
    void Update()
    {
        ProcessThrust();
        InputManager();
        AudioManager();
    }

    //Processing rocket boost and movement logic
    void ProcessThrust()
    {
        RocketBoost();
    }

    //Manages Player input for movement
    void InputManager()
    {
        StartThrust();
    }

    //Manages audio sources to be played in the scene
    void AudioManager()
    {
        if (Input.GetKey(KeyCode.Space) && isRocketActive)
        {
            PlayAudio();
        }
        else
        {
            StopAudio();
        }
    }

    void StartThrust()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopParticles();
        }
    }

    private void StopParticles()
    {
        leftParticles.Stop();
        rightParticles.Stop();
    }

    private void RotateRight()
    {
        RotationManager(-rotationSpeed);
        if (!rightParticles.isPlaying)
        {
            rightParticles.Play();
        }
    }

    private void RotateLeft()
    {
        RotationManager(rotationSpeed);
        if (!leftParticles.isPlaying)
        {
            leftParticles.Play();
        }
    }

    void RotationManager(float speed)
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
    
    private void PlayAudio()
    {
        if (!m_audio.isPlaying)
        {
            m_audio.PlayOneShot(mainAudioEngine);
            thrusterParticles.Play();
        }
    }
    private void StopAudio()
    {
        m_audio.Stop();
        thrusterParticles.Stop();
    }

    private void RocketBoost()
    {
        if (Input.GetKey(KeyCode.Space) && isRocketActive)
        {
            ConsumeFuel();
            rb.freezeRotation = true;
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }
    void ConsumeFuel()
    {
        float fuelConsumed = fuelConsumptionRate * Time.deltaTime;
        currentFuel -= fuelConsumed;
        if (currentFuel > 0)
        {
            isRocketActive = true;
        }
        if (currentFuel < 0)
        {
            currentFuel = 0;
            isRocketActive = false;
        }
    }

    /* mobile settings
    public void leftMobile()
    {
        isLeft = true;
    }

    public void noLeft() 
    {
        isLeft = false;
    }

    public void rightMobile()
    {
        isRight = true;
    }

    public void noRight() 
    {
        isRight = false;
    }

    public void isBoostMobile()
    {
        isBoost = true;
    }
    public void noBoost()
    {
        isBoost = false;
    }
    */
}
