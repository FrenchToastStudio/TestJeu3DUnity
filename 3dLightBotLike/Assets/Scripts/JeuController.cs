using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeuController : MonoBehaviour
{
    public GameObject UIgameplay;
    public GameObject personnage;
    public Animator animateur;

    public float hauteurSaut = 5f;

    public float uniteDeplacement = 1f;

    private float rotation;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;
    Vector3 destination;
    Vector3 positionDepart;

    bool go = false;
    bool mouvementEnCours = false;


    private List<String> sequence = new List<string>();
    private List<IEnumerator> sequenceCoroutine = new List<IEnumerator>();

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

    public void LancerSequence(){
        //go = true;
        //printSequence();
        //update();
        for(int i=0; i<sequence.Count; i++ ){

        }


        foreach (String mouvement in sequence){
                print("mouvement: " + mouvement);

                if(mouvement == "Avance"){
                    StartCoroutine (deplacement (saute()));
                } else if(mouvement == "Saut"){
                    StartCoroutine (saute ());
                } else if(mouvement == "Gauche"){
                    StartCoroutine (tourne (rotationGauche));
                } else if(mouvement == "Droite"){
                    StartCoroutine (tourne (rotationDroite));
                }
            }
    }

    public void printSequence(){
        foreach (String mouvement in sequence){
            print("mouvement ajouté: " + mouvement);
        }
    }

    public IEnumerator deplacement (IEnumerator coroutineSuivante){
        print("init deplacement " + mouvementEnCours);
        positionDepart = personnage.transform.position;
        destination = positionDepart + (personnage.transform.forward * 1);
        yield return new WaitUntil(()=>!mouvementEnCours);

        animateur.SetBool("marche", true);
        mouvementEnCours = true;
        print("Start deplacement " + mouvementEnCours);
        while (personnage.transform.position != destination){
            personnage.transform.position = Vector3.MoveTowards(personnage.transform.position, destination, 0.3f * Time.deltaTime); 
            yield return new WaitForEndOfFrame ();
        }
        
        animateur.SetBool("marche", false);
        mouvementEnCours = false;
        print("deplacement " + mouvementEnCours);
        StartCoroutine(coroutineSuivante);
    }

    public IEnumerator saute (){
        print("init saute " + mouvementEnCours);
        yield return new WaitUntil(()=>!mouvementEnCours);

        mouvementEnCours = true;
        print("Start saute " + mouvementEnCours);
        animateur.SetBool("saute", true);
        animateur.SetBool("estAuSol", false);
        personnage.GetComponent<Rigidbody>().AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
        personnage.GetComponent<Rigidbody>().AddForce(personnage.transform.forward * uniteDeplacement, ForceMode.Impulse);

        yield return new WaitForEndOfFrame ();
        mouvementEnCours = false;
        print("saute " + mouvementEnCours);

    }

    public IEnumerator tourne (float rotation){
        print("init tourne " + mouvementEnCours);
        yield return new WaitUntil(()=>!mouvementEnCours);
        
        mouvementEnCours = true;
        print("Start tourne " + mouvementEnCours);
        personnage.transform.Rotate(Vector3.up, rotation);

        yield return new WaitForEndOfFrame ();
        mouvementEnCours = false;
        positionDepart = personnage.transform.position;
        print("tourne " + mouvementEnCours);
    }




}
