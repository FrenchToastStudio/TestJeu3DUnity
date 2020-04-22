using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{
    public float uniteDeplacement = 50.0f;
    private float rotation;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = 0;

        if(Input.GetKeyDown(KeyCode.W))
            transform.Translate(Vector3.forward * uniteDeplacement);
        if(Input.GetKeyDown(KeyCode.A))
            rotation = rotationGauche;
        else if(Input.GetKeyDown(KeyCode.D))
            rotation = rotationDroite;

        transform.Rotate(Vector3.up, rotation);

    }
}
