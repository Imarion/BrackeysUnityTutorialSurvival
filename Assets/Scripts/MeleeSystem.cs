using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour
{
    public int TheDamage = 50;
    public float MaxDistance = 1.5f;
    public Animator anim;

    public float Distance; // how far away the ennemy is

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                Distance = hit.distance;
                if (Distance < MaxDistance) {
                    hit.transform.SendMessage("ApplyDamage", TheDamage);
                }
            }
        }
    }
}
