using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] float platformSpeed = 0.5f;
    [SerializeField] float destructionTime;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        transform.position += new Vector3(platformSpeed, 0, 0);
    }
}
