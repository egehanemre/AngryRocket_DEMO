using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] ParticleSystem boomParticles;

    bool hasExploded;
    public float blastRadius = 25.0f;
    public float blastForce = 700f;
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            if (collision.gameObject.tag == "StartPod") { return; }
            Explosion();
            hasExploded = true;
        }
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
