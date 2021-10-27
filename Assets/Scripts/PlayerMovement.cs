﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Movement")]


public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float gravity = -9.8f;
    public AudioClip _footsteps;

    private CharacterController _charController;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        if (_charController.velocity == Vector3.zero)
        {
            source.Play();
        }

    }
}
