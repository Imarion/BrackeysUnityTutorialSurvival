using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching02 : MonoBehaviour
{
    public Animator animator;

    public int currentWeapon = 0;
    public int maxWeapons = 2;  // actually 3 -> 0 to 2

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        SelectWeapon(currentWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon + 1 <= maxWeapons)
            {
                currentWeapon++;
            }
            else
            {
                currentWeapon = 0;
            }
            SelectWeapon(currentWeapon);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon - 1 >= 0)
            {
                currentWeapon--;
            }
            else
            {
                currentWeapon = maxWeapons;
            }
            SelectWeapon(currentWeapon);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeapon = 0;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
            SelectWeapon(currentWeapon);
        }
    }

    private void SelectWeapon(int weaponIndex)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // Activate selected weapon
            if (i == weaponIndex)
            {
                if (transform.GetChild(i).name == "Fists")
                {
                    animator.SetBool("WeaponIsOn", false);
                }
                else {
                    animator.SetBool("WeaponIsOn", true);
                }
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}