using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class RespawnMenu : MonoBehaviour
{
    public FirstPersonController fpc;
    
    public GameObject MenuPanel;
    public Transform respawnTransform;
    
    public static bool playerIsDead = false;

    private CharacterController charCtrlr;
    private FPSWalkerEnhanced fpsWalk;

    // Start is called before the first frame update
    void Start()
    {
        charCtrlr = GetComponent<CharacterController>();
        fpsWalk = GetComponent<FPSWalkerEnhanced>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDead == true) {
            fpc.enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            charCtrlr.enabled = false;
            fpsWalk.enabled = false;

            MenuPanel.SetActive(true);
        }
    }

    public void RespawnPlayer()
    {
        Debug.Log("RespawnPlayer");

        transform.SetPositionAndRotation(respawnTransform.position, respawnTransform.rotation);
        gameObject.SendMessage("RespawnStats");        
        MenuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        fpc.enabled = true;
        charCtrlr.enabled = true;
        fpsWalk.enabled = true;
        playerIsDead = false;
    }

    public void GoToMainMenu()
    {
        Debug.Log("Return to Menu");
    }
}
