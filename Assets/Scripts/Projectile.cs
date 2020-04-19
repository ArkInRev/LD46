using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    //public float speed = .1f;

    public float lifetime = 4.0f;
    private float timeAlive = 0f;
    public ParticleSystem impactParticles;

    public float damageCaused = 10f;

    // Start is called before the first frame update
    void Start()
    {
       //this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeAlive += Time.fixedDeltaTime;
        if (timeAlive >= lifetime) Die();
        //rb.MovePosition(rb.transform.forward  * speed * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent <IDamageable>() != null)
        {
            collision.collider.GetComponent<IDamageable>().Damage(damageCaused);
        }
        Instantiate(impactParticles,collision.transform);
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
        return;
    }

}
