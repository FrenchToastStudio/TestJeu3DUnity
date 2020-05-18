﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{

    [SerializeField]
    private float uniteDeplacement;
    [SerializeField]
    private float hauteurSaut;
    [SerializeField]
    private float uniteDeplacementSaut;
    [SerializeField]
    private Animator animateur;

    [SerializeField] private GameObject UIgameplay;

    [SerializeField] private SceneCtrl sceneCtrl;

    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;

    private static int nombreDeCoup;

    private Vector3 positionDebutNiveau;
    private float positionDebutNiveauRotation;
    private Vector3 positionDepart;
    private Vector3 destination;

    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    bool enMouvement = false;
    private static bool go = false;
    bool marche = false;
    bool saute = false;
    private static bool restart = false;

    private static List<String> sequence;

    float timeLeft = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        nombreDeCoup = 0;
        sequence = new List<string>();
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        // Pour initialiser un restart
        positionDebutNiveau = transform.position;
        positionDebutNiveauRotation = transform.rotation.eulerAngles.y;
        destination = transform.position + (transform.forward);

    }

    void Update()
    {

        if(restart == true){
            transform.position = positionDebutNiveau;
            transform.rotation = Quaternion.Euler(0, positionDebutNiveauRotation, 0);
            restart = false;
        }

        if(rigidbody.velocity.y < 0){
            animateur.SetBool("saute", false);
        }


        if(transform.position.z == destination.z && transform.position.x == destination.x){
            animateur.SetBool("marche", false);
            marche = false;
        }

        if(!enMouvement && sequence.Count > 0 && go){
            positionDepart = transform.position;
            enMouvement = true;
            switch(sequence[0]){
                case "Avance":
                    destination = transform.position + (transform.forward);
                    marche = true;
                    timeLeft = 1.5f;
                    break;
                case "Saut":
                    saut();
                    saute = true;
                    timeLeft = 1.0f;
                    break;
                case "Gauche":
                    tourne(rotationGauche);
                    getPositionPersonnage();
                    timeLeft = .5f;
                    break;
                case "Droite":
                    tourne(rotationDroite);
                    getPositionPersonnage();
                    timeLeft = .5f;
                    break;
            }
            sequence.RemoveAt(0);

        }

        // Fonction timer
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
            enMouvement = false;

        //Gestion du déplacement vers l'avant
        if(Input.GetKeyDown(KeyCode.W)){
            destination = transform.position + (transform.forward);
            marche = true;
        }else if(Input.GetKeyDown(KeyCode.X)){
            animateur.SetBool("saute", true);
            animateur.SetBool("estAuSol", false);
            rigidbody.AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
            rigidbody.AddForce(transform.forward * uniteDeplacementSaut, ForceMode.Impulse);

        }else if(Input.GetKeyDown(KeyCode.A))
            transform.Rotate(Vector3.up, rotationGauche);
        else if(Input.GetKeyDown(KeyCode.D))
            transform.Rotate(Vector3.up, rotationDroite);

        if (marche){
            animateur.SetBool("marche", true);
            transform.position = Vector3.MoveTowards(transform.position, destination, 1f * Time.deltaTime);
        }

    }

    void OnCollisionEnter(Collision collision){
        print(collision.gameObject.tag);
        animateur.SetBool("estAuSol", true);
        if(saute){
            //enMouvement = false;
            saute = false;
        }
        if(collision.gameObject.tag == "sol"){
            sceneCtrl.perdu();
            restart = true;
            sequence = new List<string>();
        }
        if(collision.gameObject.tag == "fin"){
            collision.gameObject.GetComponent<FinNiveauCtrl>().lancer(nombreDeCoup);
        }
    }

    public void getPositionPersonnage(){
        positionDepart = transform.position;
    }

    public static void SetSequence (List<String> sequenceMouvement){
        sequence = sequenceMouvement;
        go =true;
        nombreDeCoup = sequence.Count;
    }


    public static void Restart(){
        restart = true;
    }

    private void saut(){
        animateur.SetBool("saute", true);
        animateur.SetBool("estAuSol", false);
        GetComponent<Rigidbody>().AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.forward * uniteDeplacement, ForceMode.Impulse);
    }

    private void tourne (float rotation){
        transform.Rotate(Vector3.up, rotation);
    }

    private List<String> copyList (List<String> listeOriginale){
        List<String> listeDestination = new List<string>();
        foreach(String valeur in listeOriginale){
            listeDestination.Add(valeur);
        }
        return listeDestination;
    }

    public int getNombreDeCoup() {
        return nombreDeCoup;
    }
}
