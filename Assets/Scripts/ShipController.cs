using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ShipController : MonoBehaviour {

    public GameObject theShipPrefab;
    public Rigidbody theShip;
    public EnginesController shipEnginesController;
    private Transform startTransform;

    public void Init()
    {
        startTransform = theShipPrefab.transform;
        Debug.Log(startTransform.position +" "+ startTransform.rotation);
    }

    public bool CheckIfPositionReset()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            theShip.gameObject.SetActive(false);
            theShip.transform.position = startTransform.position;
            theShip.transform.rotation = startTransform.rotation;
            theShip.velocity = Vector3.zero;
            theShip.angularVelocity = Vector3.zero;
            theShip.gameObject.SetActive(true);
            return true;
        }
        return false;       

    }

    public void SpawnNewShip()
    {

    }

}
