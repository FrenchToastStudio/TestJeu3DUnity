﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetRésolutionCtrl : MonoBehaviour
{
    private bool compléterNiveau = false;
    private int nombreDeCoup = 0;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;

    private Vector3 destination;
    private Vector3 positionDepart;

    private bool enMarche;
    private bool enMouvement = false;
    private int itérateur = 0;
    private float uniteDeplacement;
    private float hauteurSaut;
    private float uniteDeplacementSaut;

    void Update() {
        if(enMouvement) {
            enMouvement= false;
            enMarche = false;
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "sol") {
            Debug.Log("touche le sol");
            if (enMarche) {
                this.transform.position = positionDepart;
                enMarche = false;
                sauter();
            } else {
                Destroy(this);
            }
        }
        if(collision.gameObject.tag == "fin") { 
            compléterNiveau = true;
        }
    }

    public bool getCompléterNiveau() {
        return compléterNiveau;
    }

    public int getNombreDeCoup() { 
        return nombreDeCoup;
    }

    public void ajouterCoup() {
        nombreDeCoup += 1;
    }

    public void avancer() {
        enMouvement = true;
        enMarche = true;
        positionDepart = this.transform.position;
        destination = transform.position + (transform.forward);
        this.transform.position = destination;
    }

    public void tournerGauche() { 
        tourne(rotationGauche);
        avancer();
    }

    public void tournerDroite() { 
        tourne(rotationGauche);
        avancer();
    }

    public void sauter() {
        enMarche = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.forward * uniteDeplacement, ForceMode.Impulse);

    }

    public void sauterGauche() {
        tourne(rotationGauche);
        sauter();
    }

    public void sauterDroite() {
        tourne(rotationDroite);
        sauter();
    }

    public void tourne (float rotation){
        transform.Rotate(Vector3.up, rotation);
    }

    public void setUniteDeplacement(float unFloat) {
        uniteDeplacement = unFloat;
    }

    public void setHauteurSaut(float unFloat) {
        hauteurSaut = unFloat;
    }


    public void setUniteDeplacementSaut(float unFloat) {
        uniteDeplacementSaut = unFloat;
    }

    public bool getEnMouvement() {
        return enMouvement;
    }

}
