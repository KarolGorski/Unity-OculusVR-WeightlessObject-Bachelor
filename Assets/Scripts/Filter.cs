using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : MonoBehaviour {
    
    public int queueItemsQuantity;
    private Queue<Vector3> forceFilterQueue;
    private Queue<Vector3> torqueFilterQueue;


    public void Init()
    {
        forceFilterQueue = new Queue<Vector3>();
        torqueFilterQueue = new Queue<Vector3>();
        for (int i = 0; i < queueItemsQuantity; i++)
        {
            forceFilterQueue.Enqueue(new Vector3(0, 0, 0));
            torqueFilterQueue.Enqueue(new Vector3(0, 0, 0));
        }
    }

    public void Reset()
    {
        forceFilterQueue.Clear();
        torqueFilterQueue.Clear();
    }

    public void Iterate(Vector3 currentForce, Vector3 currentTorque)
    { 
            forceFilterQueue.Dequeue();
            forceFilterQueue.Enqueue(currentForce);
            torqueFilterQueue.Dequeue();
            torqueFilterQueue.Enqueue(currentTorque);
    }

    public Vector3 GetForceToAdd()
    {
        Vector3 meanVector = new Vector3(0, 0, 0);
        foreach (Vector3 v in forceFilterQueue)
            meanVector += v;
        return meanVector / queueItemsQuantity;
    }

    public Vector3 GetTorqueToAdd()
    {
        Vector3 meanVector = new Vector3(0, 0, 0);
        foreach (Vector3 v in torqueFilterQueue)
            meanVector += v;
        return meanVector / queueItemsQuantity;
    }
}
