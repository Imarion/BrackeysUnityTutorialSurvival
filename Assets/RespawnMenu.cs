using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RespawnMenu : MonoBehaviour
{
    public FirstPersonController fpc;

    public static bool playerIsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDead == true) {
            //fpc.enabled = false;
        }
    }

    private void OnGUI()
    {
        if (playerIsDead == true)
        {
            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, 200 - 20, 100, 40), "Restart"))
            {
                RespawnPlayer();
            }

            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, 240, 100, 40), "Menu"))
            {
                Debug.Log("Return to Menu");
            }
        }
    }

    private void RespawnPlayer()
    {
        Debug.Log("RespawnPlayer");
    }
}
