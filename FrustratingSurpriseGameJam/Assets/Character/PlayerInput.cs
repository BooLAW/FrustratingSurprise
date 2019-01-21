﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour {

    private PlayerController controller;
    private int jump = 0;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (jump == 0)
        {
            // Read the jump input in Update so button presses aren't missed.
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
                jump = 1;

        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        bool climb = Input.GetKey(KeyCode.LeftShift);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");

        if (CrossPlatformInputManager.GetAxis("Vertical") > 0 && jump == 1)
            jump = 2;

        controller.Move(h, crouch, jump,climb);
        jump = 0;
    }
}
