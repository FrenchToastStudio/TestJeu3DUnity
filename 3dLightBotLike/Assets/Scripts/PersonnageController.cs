﻿using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{
    
    [SerializeField]
    private float uniteDeplacement = 1f;
    [SerializeField]
    private float hauteurSaut = 4f;
    [SerializeField]
    private float uniteDeplacementSaut = 1.50f;
    [SerializeField]
    private Animator animateur;

    [SerializeField]
    private GameObject UIgameplay;

    [SerializeField]
    private GameObject textPerdu;
    
    private float rotation;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;

    private Vector3 positionDebutNiveau;
    private Vector3 positionDepart;
    private Vector3 destination;

    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    private bool marche = false;
    private bool enMouvement = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        positionDebutNiveau = transform.position;

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
        if(Input.GetKeyDown(KeyCode.W) && enMouvement == false){
            destination = transform.position + (transform.forward);
            marche = true;
            StartCoroutine(Attendre());
        }else if(Input.GetKeyDown(KeyCode.X) && enMouvement == false){
            
            animateur.SetBool("saute", true);
            animateur.SetBool("estAuSol", false);
            rigidbody.AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
            rigidbody.AddForce(transform.forward * uniteDeplacementSaut, ForceMode.VelocityChange);            
            StartCoroutine(Attendre());
        }else if(Input.GetKeyDown(KeyCode.A) && enMouvement == false)
            rotation = rotationGauche;
        else if(Input.GetKeyDown(KeyCode.D) && enMouvement == false)
            rotation = rotationDroite;

        transform.Rotate(Vector3.up, rotation);

        if (marche){
            animateur.SetBool("marche", true);
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.5f * Time.deltaTime);
        } else {
            animateur.SetBool("marche", false);
        }        

    }

    void OnCollisionEnter(Collision collision){
        animateur.SetBool("estAuSol", true);
        if(collision.gameObject.tag == "sol"){
            print("perdu");
            Time.timeScale = 0;
            GameObject message = Instantiate(textPerdu) as GameObject;
            message.transform.SetParent(UIgameplay.transform, false);
            message.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,0,0);
            message.GetComponent<RectTransform>().localScale = new Vector3(4,5,1);
        }
              
    }

    IEnumerator Attendre(){
        enMouvement = true;
        yield return new WaitForSeconds(2.0f);
        enMouvement = false;
    }
}
