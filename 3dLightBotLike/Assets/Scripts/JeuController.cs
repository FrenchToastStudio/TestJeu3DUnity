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

    private List<String> sequence = new List<string>();

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

    void Update(){
        positionDepart = personnage.transform.position;
    }

    public void LancerSequence(){

        foreach (String mouvement in sequence){
                print("mouvement: " + mouvement);

                if(mouvement == "Avance"){
                    StartCoroutine (deplacement ());
                } else if(mouvement == "Saut"){
                    StartCoroutine (saute ());
                } else if(mouvement == "Gauche"){
                    StartCoroutine (tourne (rotationGauche));
                } else if(mouvement == "Droite"){
                    StartCoroutine (tourne (rotationDroite));
                }
            }
    }

    public IEnumerator deplacement (){
       destination = positionDepart + (personnage.transform.forward * 1);
        
        animateur.SetBool("marche", true);
        print("Start deplacement ");
        while (personnage.transform.position.x != destination.x){
            personnage.transform.position = Vector3.MoveTowards(personnage.transform.position, destination, 0.3f * Time.deltaTime); 
            yield return new WaitForEndOfFrame ();
        }
        
        //animateur.SetBool("marche", false);
        print("deplacement ");        
    }

    public IEnumerator saute (){
        print("init saute ");
        
        print("Start saute ");
        animateur.SetBool("saute", true);
        animateur.SetBool("estAuSol", false);
        personnage.GetComponent<Rigidbody>().AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
        personnage.GetComponent<Rigidbody>().AddForce(personnage.transform.forward * uniteDeplacement, ForceMode.Impulse);

        yield return new WaitForEndOfFrame ();
        print("saute ");
    }

    public IEnumerator tourne (float rotation){
        print("init tourne ");
        
        print("Start tourne ");
        personnage.transform.Rotate(Vector3.up, rotation);

        yield return new WaitForEndOfFrame ();
        positionDepart = personnage.transform.position;
        print("tourne ");
        Update();
    }




}
