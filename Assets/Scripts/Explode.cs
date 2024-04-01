using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] ParticleSystem boomParticles;

    public bool hasExploded;

    public float blastRadius = 25.0f;
    public float blastForce = 700f;

    public Vector3 spawnPosition = new Vector3(-20.21f, 21.04f, 0);
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            if (collision.gameObject.tag == "StartPod") { return; }
            Explosion();
            hasExploded = true;
            Invoke("ActivatePanel", 3f);
        }
    }

    public void ActivatePanel()
    {
        panel.SetActive(true);
    }

    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                //Starting to initialize sphere from the tip of the rocket by adding offset to location.
                Vector3 sphereLocation = transform.position;
                rb.AddExplosionForce(blastForce, sphereLocation, blastRadius);
            }
        }
    }
}
