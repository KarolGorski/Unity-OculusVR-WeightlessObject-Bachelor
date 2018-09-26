using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, IFinishTrigger {

    public int nextScene;
    public FinishTrigger fTrigger;

    public void Init()
    {
        fTrigger.listener = this;
    }
    private void SetNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void StageFinished()
    {
        SetNextScene();
    }
}
