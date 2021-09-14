﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.ArtificialBased;
using VRTK.Examples;

public class PushButton : MonoBehaviour
{
    private ControllableReactor controllableReactor;
    private bool isOncollision;
    private GameObject currentHand;
    private float distacetohand;
    // Start is called before the first frame update
    void Start()
    {
        controllableReactor = GetComponent<ControllableReactor>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHand)
        {
            distacetohand = Vector3.Distance(this.gameObject.transform.position, currentHand.transform.position);
        }

        if (!isOncollision && controllableReactor.controllable.gameObject.GetComponent<VRTK_ArtificialPusher>().stayPressed && distacetohand >0.065f)
        {
            controllableReactor.controllable.gameObject.GetComponent<VRTK_ArtificialPusher>().stayPressed = false;
            controllableReactor.controllable.gameObject.GetComponent<VRTK_ArtificialPusher>().SetToRestingPosition();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        currentHand = other.gameObject;
        isOncollision = true;

    }

    private void OnCollisionExit(Collision other)
    {

        isOncollision = false;

    }
}