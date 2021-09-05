using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnwe : MonoBehaviour
{
    [SerializeField] GameObject newPlatform;

    private void Start()
    {
        Instantiate(newPlatform, transform.position, transform.rotation);
    }
}
