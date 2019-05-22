using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class RespawnMenu : MonoBehaviour
{
    public FirstPersonController fpc;
    public GameObject MenuPanel;

    public static bool playerIsDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDead == true) {
            fpc.enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            MenuPanel.SetActive(true);
        }
    }

    public void RespawnPlayer()
    {
        Debug.Log("RespawnPlayer");
    }

    public void GoToMainMenu()
    {
        Debug.Log("Return to Menu");
    }
}
