using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour, IObjectToCollect {

    public List<QuestCollectible> objectsToCollect;
    public GameObject theWall;
    public GameObject takenParticle;

    public void Init()
    {
        foreach (QuestCollectible c in objectsToCollect)
            c.listener = this;
    }

    public void CheckIfQuestComplete()
    {
        foreach(QuestCollectible o in objectsToCollect)
        {
            if (o.gameObject.activeInHierarchy) return;
        }
        StartCoroutine(MoveTheWall());
    }

    public void DeactiveMe(GameObject takenObject)
    {
        GameObject sratata = Instantiate(takenParticle, takenObject.transform.position, Quaternion.identity);
        takenObject.SetActive(false); 
        CheckIfQuestComplete();
    }

    
    IEnumerator MoveTheWall()
    {
        theWall.SetActive(false);
        Vector3 originPos = theWall.transform.position;
        //+3z -6,5x
        for(float i=0;i<=1.5f;i+=Time.deltaTime)
        {
            theWall.transform.position = Vector3.Lerp(originPos, originPos + new Vector3(0f, 0f, 3f), i/1.5f);
            yield return null;
        }
        originPos = theWall.transform.position;
        for (float i = 0; i <= 1.5f; i += Time.deltaTime)
        {
            theWall.transform.position = Vector3.Lerp(originPos, originPos + new Vector3(-6.5f, 0f, 0f), i / 1.5f);
            yield return null;
        }

        
    }
}
