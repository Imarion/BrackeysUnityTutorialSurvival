using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CrouchHeight : MonoBehaviour
{
    private CharacterController charController;
    private Transform theTransform;
    private float charHeight; //Initial height

    // Start is called before the first frame update
    void Start()
    {
        theTransform = transform;
        charController = GetComponent<CharacterController>();
        charHeight = charController.height;
    }

    // Update is called once per frame
    void Update()
    {
        var h = charHeight;

        if (Input.GetKey("c"))
        {
            h = charHeight * 0.5f;
        }

        var lastHeight = charController.height; //Stand up/crouch smoothly
        charController.height = Mathf.Lerp(charController.height, h, 5 * Time.deltaTime);
        theTransform.position += new Vector3 (0.0f, (charController.height - lastHeight) / 2f, 0.0f); //Fix vertical position
    }
}
