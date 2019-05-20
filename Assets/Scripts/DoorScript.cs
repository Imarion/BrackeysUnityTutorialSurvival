using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform theDoor;

    private bool drawGUI = false;
    private bool doorIsClosed = true;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = theDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((drawGUI == true) && (Input.GetKeyDown(KeyCode.E))) {
            changeDoorState();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            drawGUI = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            drawGUI = false;
        }
    }

    private void OnGUI()
    {
        if (drawGUI == true)
        {
            GUI.Box(new Rect(Screen.width * 0.5f - 51.0f, 200, 102, 22), "Press E to open");
        }
    }

    private void changeDoorState()
    {
        if (doorIsClosed == true)
        {
            Debug.Log("Start coroutine");
            StartCoroutine(animDoor());
            Debug.Log("return from coroutine");
        }
    }

    private IEnumerator animDoor() {
        //anim.CrossFade("opendoor");
        anim.SetTrigger("Open");
        doorIsClosed = false;
        yield return new WaitForSeconds(2.0f);
        //anim.CrossFade("closedoor");
        anim.SetTrigger("Close");
        doorIsClosed = true;
    }
}
