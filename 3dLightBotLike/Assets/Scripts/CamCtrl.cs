using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject personnage;

    private Vector3 offset = new Vector3(3, 4 , 0);
    private Vector3 offsetAngle = new Vector3(40, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = personnage.transform.eulerAngles + offsetAngle;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = personnage.transform.position + offset;


    }
}
