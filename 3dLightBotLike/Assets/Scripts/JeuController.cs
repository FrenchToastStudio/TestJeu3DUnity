
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeuController : MonoBehaviour
{
    [SerializeField]
    private GameObject UIgameplay;
    [SerializeField]
    private GameObject personnage;
    [SerializeField]
    private Animator animateur;

    [SerializeField]
    private float hauteurSaut = 5f;

    [SerializeField]
    private float uniteDeplacement = 1f;

    private float rotation;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;
    private Vector3 destination;
    private Vector3 positionDepart;

    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    bool enMouvement = false;
    bool go = false;
    bool marche = false;
    bool saute = false;

    private List<String> sequence = new List<string>();

    private List<String> historiqueSequence;

    public void setMouvementGauche(){
        sequence.Add("Gauche");
    }

    public void setMouvementAvance(){
        sequence.Add("Avance");         
    }

    public void setMouvementDroite(){
        sequence.Add("Droite");  
    }

    public void setMouvementSaut(){
        sequence.Add("Saut");  
    }

    void Start()
    {
        rigidbody = personnage.GetComponent<Rigidbody>();
        boxCollider = personnage.GetComponent<BoxCollider>();
        
    }

    void Update(){

        // if(rigidbody.velocity.y < 0){
        //     animateur.SetBool("saute", false);
        // }
            

        if(personnage.transform.position.z == destination.z || personnage.transform.position.x == destination.x){
            animateur.SetBool("marche", false);
            marche = false;
            enMouvement = false;
        }

        if(!enMouvement && sequence.Count > 0 && go){
            Debug.Log("inside if - commande : " + sequence[0]);
            positionDepart = personnage.transform.position;
            enMouvement = true;
            switch(sequence[0]){
                case "Avance":
                    destination = personnage.transform.position + (transform.forward);
                    marche = true;
                    break;
                case "Saut":
                    saut();
                    saute = true;
                    break;
                case "Gauche":
                    tourne(rotationGauche);
                    getPositionPersonnage();
                    enMouvement = false;
                    break;
                case "Droite":
                    tourne(rotationDroite);
                    getPositionPersonnage();
                    enMouvement = false;
                    break;



            }
            sequence.RemoveAt(0);
            
        }



        if (marche){
            animateur.SetBool("marche", true);
            personnage.transform.position = Vector3.MoveTowards(personnage.transform.position, destination, 1f * Time.deltaTime);
        }





    }

    public void getPositionPersonnage(){
        positionDepart = personnage.transform.position;
    }

    public void LancerSequence(){
        if(sequence.Count == 0 && historiqueSequence.Count > 0)
            sequence = copyList(historiqueSequence);
        historiqueSequence = copyList(sequence);
        go =true;
    }

    public void saut(){
        animateur.SetBool("saute", true);
        animateur.SetBool("estAuSol", false);
        personnage.GetComponent<Rigidbody>().AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
        personnage.GetComponent<Rigidbody>().AddForce(personnage.transform.forward * uniteDeplacement, ForceMode.Impulse);
    }

    public void tourne (float rotation){
        personnage.transform.Rotate(Vector3.up, rotation);
    }

    void OnCollisionEnter(Collision collision){
        Debug.Log(saute);
        if(saute){
            animateur.SetBool("estAuSol", true);
            enMouvement = false;
            saute = false;
            Debug.Log("est au sol - mouvement false");
        }
        
        
        if(collision.gameObject.tag == "sol"){
            Time.timeScale = 0;
            //DisplayMessage(textPerdu);
        } else if (collision.gameObject.tag == "fin"){
            Time.timeScale = 0;
            //DisplayMessage(textGagne);
        }     
    }

    private List<String> copyList (List<String> listeOriginale){
        List<String> listeDestination = new List<string>();
        foreach(String valeur in listeOriginale){
            listeDestination.Add(valeur);
        }
        return listeDestination;
    }






}
