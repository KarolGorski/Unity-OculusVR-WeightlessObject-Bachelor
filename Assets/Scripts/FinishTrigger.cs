using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public IFinishTrigger listener;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER");
        listener.StageFinished();
    }

}
