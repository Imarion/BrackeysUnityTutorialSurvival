using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour
{
    public int TheDamage = 50;
    public float MaxDistance = 1.5f;
    public Animator anim;
    public Transform TheSystem;

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
            // Attack animation
            anim.SetTrigger("Attack");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.CrossFade("Sprint", 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.CrossFade("Idle", 0);
        }
    }

    public void AttackDamage()
    {
        RaycastHit hit;
        if (Physics.Raycast(TheSystem.transform.position, TheSystem.transform.TransformDirection(Vector3.forward), out hit))
        {
            Distance = hit.distance;
            if (Distance < MaxDistance)
            {
                hit.transform.SendMessage("ApplyDamage", TheDamage);
            }
        }
    }
}
