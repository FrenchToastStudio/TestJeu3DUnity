
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

    

    void Start()
    {
        rigidbody = personnage.GetComponent<Rigidbody>();
        boxCollider = personnage.GetComponent<BoxCollider>();
        
    }

    void Update(){

        




    }

    






}
