using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherobejct = otherCollider.gameObject;

        if (otherobejct.GetComponent<Defender>())
        {
            GetComponent<Attacher>().Attack(otherobejct);
        }
    }

}
