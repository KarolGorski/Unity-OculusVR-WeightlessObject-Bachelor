using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovementController : MonoBehaviour {


    [Header("Filter")]
    public Filter filter;

    [Header("Multipliers")]
    public float rotateDistanceMultiplier = 5f;
    public float shiftDistanceMultiplier = 5f;

    [Header("Current Input Vectors")]
    [SerializeField]
    Vector3 currentShiftInputVector = new Vector3(0,0,0);
    [SerializeField] 
    Vector3 currentTorqueInputVector = new Vector3(0, 0, 0);
    [Header("Current Velocities")]
    [SerializeField]
    Vector3 currentVelocity = new Vector3(0, 0, 0);
    [SerializeField]
    Vector3 currentAngularVelocity = new Vector3(0, 0, 0);
    [Header("Current Pass Filter Output")]
    [SerializeField]
    Vector3 currentFilterForceOutput = new Vector3(0, 0, 0);
    [SerializeField]
    Vector3 currentFilterTorqueOutput = new Vector3(0, 0, 0);

    [Header("Hands to Spheres Distances")]
    [SerializeField]
    Vector3 rHandToSphereDistance;
    [SerializeField]
    Vector3 lHandToSphereDistance;

    [Header("Hands and control spheres GameObjects")]
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject ShiftSphere;
    public GameObject RotateSphere;

    private Vector3 lHandPos;
    private Vector3 rHandPos;
    private Vector3 shiftSpherePos;
    private Vector3 rotateSpherePos;

    [Header("Movement Style")]
    public string currentMovementStyle = "Free";
    public TextMesh infoText;

    bool resetAllVelocities = false;


    //Method to use when in view out of spacecraft - it enables visual particles from spacecraft's engines
    public void Movement(EnginesController enginesController)
    {
        
        Movement();
        enginesController.SetEngines(currentFilterForceOutput, currentFilterTorqueOutput);
    }

    public void Movement()
    {
        GetVectorsFromInput();
        filter.Iterate(currentShiftInputVector, currentTorqueInputVector);
        UpdateMovementStyle();
        UpdateControllersPosition();
        
    }

    public void Init()
    {
        filter.Init();
    }

    public void RigidbodyMovement(Rigidbody rb)
    {

        AddCurrentVectors(rb);

    }

    private void AddCurrentVectors(Rigidbody rb)
    {
        rb.AddRelativeForce(filter.GetForceToAdd()- rb.gameObject.transform.InverseTransformDirection(rb.velocity), ForceMode.VelocityChange);
        rb.AddRelativeTorque(filter.GetTorqueToAdd()- rb.gameObject.transform.InverseTransformDirection(rb.angularVelocity), ForceMode.VelocityChange);
       
        if (resetAllVelocities)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            resetAllVelocities = false;
        }
        currentFilterForceOutput = filter.GetForceToAdd();
        currentFilterTorqueOutput = filter.GetTorqueToAdd();
            
        currentVelocity = rb.velocity;
        currentAngularVelocity = rb.angularVelocity;

    }

    private void GetVectorsFromInput()
    {
        switch (currentMovementStyle)
        {
            case "Free":
                FreeShiftInput();
                FreeRotateInput();
                break;
            case "Stable":
                StableShiftInput();
                StableRotateInput();
                break;
        }
    }

    private void FreeShiftInput()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            currentShiftInputVector = CalculateShiftInputVector();
        }
            
    }
    private void StableShiftInput()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            currentShiftInputVector = CalculateShiftInputVector();

        }
        else currentShiftInputVector = Vector3.zero;
    }

    private void FreeRotateInput()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            currentTorqueInputVector = CalculateRotateInputVector();
        }
            
    }

    private void StableRotateInput()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            currentTorqueInputVector = CalculateRotateInputVector();
        }
        else currentTorqueInputVector = Vector3.zero;

    }

    private Vector3 CalculateShiftInputVector()
    {
        return rHandToSphereDistance*shiftDistanceMultiplier;
    }

    private Vector3 CalculateRotateInputVector()
    {
        return new Vector3(
                lHandToSphereDistance.z,
                lHandToSphereDistance.x,
                -lHandToSphereDistance.y)*rotateDistanceMultiplier;
    }

    private void SetInfoText(string text)
    {
        infoText.text = text;
    }

    private void UpdateControllersPosition()
    {
        rHandPos = rightHand.transform.localPosition;
        lHandPos = leftHand.transform.localPosition;
        shiftSpherePos = ShiftSphere.transform.localPosition;
        rotateSpherePos = RotateSphere.transform.localPosition;

        rHandToSphereDistance = new Vector3(
            rHandPos.x - shiftSpherePos.x,
            rHandPos.y - shiftSpherePos.y,
            rHandPos.z - shiftSpherePos.z);
        lHandToSphereDistance = new Vector3(
            lHandPos.x - rotateSpherePos.x,
            lHandPos.y - rotateSpherePos.y,
            lHandPos.z - rotateSpherePos.z);
    }

    private void UpdateMovementStyle()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            if (currentMovementStyle.Equals("Free"))
            {
                currentMovementStyle = ("Stable");
                SetInfoText("Stable");
            }
            else
            {
                currentMovementStyle = ("Free");
                SetInfoText("Free");
            }
        }
    }

    public void ResetMovementController()
    {
        currentShiftInputVector = Vector3.zero;
        currentTorqueInputVector = Vector3.zero;
        currentAngularVelocity = Vector3.zero;
        currentVelocity = Vector3.zero;
        resetAllVelocities = true;
        filter.Reset();
        filter.Init();
    }

}