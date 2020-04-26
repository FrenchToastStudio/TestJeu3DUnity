using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{
    private static float uniteDeplacement = 1f;
    private static float hauteurSaut = 4f;
    public GameObject personnage;
    public Animator animateur;
    private float rotation;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;

    static Vector3 positionDepart;
    static Vector3 destination;

    Rigidbody rigidbody;
    BoxCollider boxCollider;

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

        if(positionDepart == destination)
            animateur.SetBool("marche", false);

        // Gestion du déplacement vers l'avant
        if(Input.GetKeyDown(KeyCode.W)){
            destination = positionDepart + (transform.forward * uniteDeplacement);
            animateur.SetBool("marche", true);
            StartCoroutine (deplacement (destination, 0.4f));
        }

        // Gestion d'un saut
        if(Input.GetKeyDown(KeyCode.X)){
            animateur.SetBool("saute", true);
            animateur.SetBool("estAuSol", false);
            rigidbody.AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
            rigidbody.AddForce(transform.forward * uniteDeplacement, ForceMode.Impulse);            
        }

        // Gestion de la rotation du personnage 
        if(Input.GetKeyDown(KeyCode.A))
            rotation = rotationGauche;
        else if(Input.GetKeyDown(KeyCode.D))
            rotation = rotationDroite;

        transform.Rotate(Vector3.up, rotation);

    }

    public IEnumerator deplacement (Vector3 end, float speed){
        while (transform.position != end){
            transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime); 
            yield return new WaitForEndOfFrame ();
        }
    }

    // public static void Saute (GameObject personnage, Animator animateur){
    //     animateur.SetBool("saute", true);
    //     animateur.SetBool("estAuSol", false);
    //     personnage.GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
    //     personnage.GetComponent<Rigidbody>().AddForce(personnage.transform.forward * 1, ForceMode.Impulse);
    // }

    // public static void Avance (GameObject personnage, Animator animateur, Vector3 destination){
    //     //destination = positionDepart + (personnage.transform.forward * uniteDeplacement);
    //     animateur.SetBool("marche", true);
    //     while (personnage.transform.position != destination){
    //         personnage.transform.position = Vector3.MoveTowards(personnage.transform.position, destination, 10f * Time.deltaTime); 
    //     }
    //     animateur.SetBool("marche", false);
    // }

    void OnCollisionEnter(Collision collision){
        animateur.SetBool("estAuSol", true);
    }

    
}
