using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject Weapon01, Weapon02;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            SwapWeapons();
        }
    }

    void SwapWeapons() {
        if (Weapon01.activeSelf == true)
        {
            Weapon01.SetActive(false);
            Weapon02.SetActive(true);
        }
        else {
            Weapon01.SetActive(true);
            Weapon02.SetActive(false);
        }
    }
}
