using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectible : MonoBehaviour {


    public IObjectToCollect listener;

    private void OnTriggerEnter(Collider other)
    {
        listener.DeactiveMe(this.gameObject);
    }
}
