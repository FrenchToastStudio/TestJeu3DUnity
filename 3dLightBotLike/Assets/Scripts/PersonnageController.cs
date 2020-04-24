using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{
    public float vitesse = 5;
    public float uniteDeplacement = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") == 1)
            transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
