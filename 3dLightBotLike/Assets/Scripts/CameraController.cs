using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject personnage;

    private Vector3 offset = new Vector3(0, 2 , -3);
    
    // Update is called once per frame
    void Update()
    {
        transform.position = personnage.transform.position + offset;

    }
}
