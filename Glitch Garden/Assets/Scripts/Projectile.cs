using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;
    //[SerializeField] [Range(360f, 7200f)]
    float rotation = 1000f;
    void Update()
    {
        //transform.Rotate(Vector3.forward* -rotation * Time.deltaTime,Space.World);
        //transform.Translate(Vector3.right * speed * Time.deltaTime,Space.World);
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
      
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacher>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
            
        }
      
        
    }
}

