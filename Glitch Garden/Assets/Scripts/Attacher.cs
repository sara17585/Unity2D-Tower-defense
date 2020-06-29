using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacher : MonoBehaviour
{

  
    //[Range(0f,5f)][SerializeField] float walkSpeed = 1f;
    float currentSpeed = 1f;
    GameObject currentTarget;

    // Animator contorller;
    // Start is called before the first frame update


    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }


    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.Attackerkilled();
        }
    }

    void Start()
    {

       // contorller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (contorller.GetCurrentAnimatorStateInfo(0).IsName("Lizard Walk"))
            transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

   public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;

    }


    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);

        }
    }

}
