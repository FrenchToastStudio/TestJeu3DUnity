using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{
    public float uniteDeplacement = 1f;
    public float hauteurSaut = 4.5f;
    public float uniteDeplacementSaut = 1.25f;
    public Animator animateur;
    private float rotation;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;

    Vector3 positionDepart;
    Vector3 destination;

    Rigidbody rigidbody;
    BoxCollider boxCollider;

    bool marche = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation = 0;
        positionDepart = transform.position;

        if(rigidbody.velocity.y < 0)
            animateur.SetBool("saute", false);

        if(positionDepart == destination){
            animateur.SetBool("marche", false);
            marche = false;
        }
            

        // Gestion du déplacement vers l'avant
        if(Input.GetKeyDown(KeyCode.W)){
            destination = transform.position + (transform.forward);
            marche = true;
        }

        if (marche){
            animateur.SetBool("marche", true);
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.5f * Time.deltaTime);
            print("marche termine");
        }
            
        // Gestion d'un saut
        if(Input.GetKeyDown(KeyCode.X)){
            animateur.SetBool("saute", true);
            animateur.SetBool("estAuSol", false);
            rigidbody.AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
            rigidbody.AddForce(transform.forward * uniteDeplacementSaut, ForceMode.Impulse);            
        }

        // Gestion de la rotation du personnage 
        if(Input.GetKeyDown(KeyCode.A))
            rotation = rotationGauche;
        else if(Input.GetKeyDown(KeyCode.D))
            rotation = rotationDroite;

        transform.Rotate(Vector3.up, rotation);

    }

    void OnCollisionEnter(Collision collision){
        animateur.SetBool("estAuSol", true);  
    }
}
