using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int Speed = 60;
    public int MaxDamage = 10;

    private Vector3 startVelocity;

    void Start()
    {
        // Add velocity to the bullet
        startVelocity = this.gameObject.GetComponent<Rigidbody>().velocity = this.transform.forward * Speed;

        // Destroy the bullet after 5 seconds
        //Destroy(this.gameObject, 1 * 60);
    }

    void OnCollisionEnter(Collision collision)
    {    
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();

        var currentMagnitude = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        if (health != null && (currentMagnitude > (startVelocity.magnitude / 3)))
        {
            health.TakeDamage(Mathf.CeilToInt((currentMagnitude / startVelocity.magnitude) * MaxDamage));
        }
    }
}