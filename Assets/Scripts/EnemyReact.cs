using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReact : MonoBehaviour
{
    public float health;
    public GameObject self;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Score.scoreCount += 100;
            Destroy(self);
        }
    }

    private void OnCollisionEnter(Collision collInfo)
    {
        //Debug.Log(collInfo.relativeVelocity.magnitude);
        if (collInfo.relativeVelocity.magnitude >= 3) //If the amount of force on the pig passes a certain threshold, the relative velocity is subtracted from the pig's health as damage.
        {
            health -= collInfo.relativeVelocity.magnitude;
        }
    }
}
