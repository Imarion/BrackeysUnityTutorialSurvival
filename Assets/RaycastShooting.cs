using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    public Transform Effect;
    public int TheDamage = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit, 100)) {
                Transform effectClone = Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effectClone.gameObject, 2);
                hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
