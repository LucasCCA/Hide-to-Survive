using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaveGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            LeaveGameFunction();
        }
    }

    public void LeaveGameFunction()
    {
        Application.Quit();
    }
}
