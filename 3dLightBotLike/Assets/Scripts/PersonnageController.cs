using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{
    private float uniteDeplacement = 40.0f;
    public Animator animateur;
    private float rotation;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;

    Vector3 positionDepart;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = 0;
        positionDepart = transform.position;

        if(positionDepart == destination)
            animateur.SetBool("marche", false);

        if(Input.GetKeyDown(KeyCode.W)){
            destination = positionDepart + (transform.forward * uniteDeplacement * Time.deltaTime);
            animateur.SetBool("marche", true);
            StartCoroutine (deplacement (destination, 0.4f));
        }
            
        if(Input.GetKeyDown(KeyCode.A))
            rotation = rotationGauche;
        else if(Input.GetKeyDown(KeyCode.D))
            rotation = rotationDroite;

        transform.Rotate(Vector3.up, rotation);

    }

    public IEnumerator deplacement (Vector3 end, float speed){
     while (transform.position != end)
     {
        transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime); 
        yield return new WaitForEndOfFrame ();
     }
 }
}
