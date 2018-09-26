using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginesController : MonoBehaviour {


    public List<GameObject> forwardEngines;
    public List<GameObject> backwardEngines;
    public List<GameObject> leftEngines;
    public List<GameObject> rightEngines;
    public List<GameObject> upEngines;
    public List<GameObject> downEngines;
    public List<GameObject> leftBarrelEngines;
    public List<GameObject> rightBarrelEngines;
    public List<GameObject> leftRotateEngines;
    public List<GameObject> rightRotateEngines;
    public List<GameObject> upRotateEngines;
    public List<GameObject> downRotateEngines;

    public bool forward_flag=false;
    public bool backward_flag = false;
    public bool left_flag = false;
    public bool right_flag = false;
    public bool up_flag = false;
    public bool down_flag = false;
    public bool leftBarrel_flag = false;
    public bool rightBarrel_flag = false;
    public bool leftRotate_flag = false;
    public bool rightRotate_flag = false;
    public bool upRotate_flag = false;
    public bool downRotate_flag = false;


    public void SetEngines(Vector3 actualShift, Vector3 actualRotate)
    {
        //shifts
        if (actualShift.z > 0)
            forward_flag = true;
        else
            forward_flag = false;

        if (actualShift.z < 0)
            backward_flag = true;
        else
            backward_flag = false;

        if (actualShift.x > 0)
            right_flag = true;
        else
            right_flag = false;

        if (actualShift.x < 0)
            left_flag = true;
        else
            left_flag = false;

        if (actualShift.y > 0)
            up_flag = true;
        else
            up_flag = false;

        if (actualShift.y < 0)
            down_flag = true;
        else
            down_flag = false;

        //rotates
        if (actualRotate.z > 0)
            downRotate_flag = true;
        else
            downRotate_flag = false;

        if (actualRotate.z < 0)
            upRotate_flag = true;
        else
            upRotate_flag = false;

        if (actualRotate.x > 0)
            rightBarrel_flag = true;
        else
            rightBarrel_flag = false;

        if (actualRotate.x < 0)
            leftBarrel_flag = true;
        else
            leftBarrel_flag = false;

        if (actualRotate.y > 0)
            rightRotate_flag = true;
        else
            rightRotate_flag = false;

        if (actualRotate.y < 0)
            leftRotate_flag= true;
        else
            leftRotate_flag = false;

        TurnEngines();
    }

    public void TurnEngines()
    {
        ListObjectsMaintainer(forwardEngines, forward_flag);
        ListObjectsMaintainer(backwardEngines, backward_flag);
        ListObjectsMaintainer(leftEngines, left_flag);
        ListObjectsMaintainer(rightEngines, right_flag);
        ListObjectsMaintainer(upEngines, up_flag);
        ListObjectsMaintainer(downEngines, down_flag);
        ListObjectsMaintainer(leftBarrelEngines, leftBarrel_flag);
        ListObjectsMaintainer(rightBarrelEngines, rightBarrel_flag);
        ListObjectsMaintainer(leftRotateEngines, leftRotate_flag);
        ListObjectsMaintainer(rightRotateEngines, rightRotate_flag);
        ListObjectsMaintainer(upRotateEngines, upRotate_flag);
        ListObjectsMaintainer(downRotateEngines, downRotate_flag);
    }

    public void ListObjectsMaintainer( List<GameObject> list, bool enabled)
    {
        foreach ( GameObject g in list )
        {
            g.SetActive(enabled);
           // Debug.Log("Setting: " + g.name + " to: " + enabled);
        }
    }


}
