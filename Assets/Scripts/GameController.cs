using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{

    public MovementController movementController;
    public ShipController shipController;
    public Quest questController;
    public SceneController sceneController;

    private void Start()
    {
        InitControllers();
    }

    private void InitControllers()
    {
        questController.Init();
        shipController.Init();
        sceneController.Init();
        movementController.Init();
    }

    void Update () {
        Movement();
    }

    void FixedUpdate()
    {
        movementController.RigidbodyMovement(shipController.theShip);
        
    }

    private void Movement()
    {
        if (shipController.CheckIfPositionReset())
            movementController.ResetMovementController();

        if (shipController.shipEnginesController == null)
            movementController.Movement();
        else
            movementController.Movement(shipController.shipEnginesController);

    }


}
