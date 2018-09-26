using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    public List<GameObject> particles;
    public void playParticle(string name, Vector3 position)
    {
        foreach (GameObject p in particles)
        {
            if(p.name.Equals(name))
            {
                StartCoroutine(SpawnAndDestroyParticle(p, position));
            }
        }

    }

    IEnumerator SpawnAndDestroyParticle(GameObject toInst, Vector3 position)
    {
        GameObject inst = Instantiate(toInst, position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        Destroy(inst);

    }
}
