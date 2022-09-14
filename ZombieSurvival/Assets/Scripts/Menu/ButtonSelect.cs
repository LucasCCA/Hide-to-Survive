using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField] Button novoJogo;
    // Start is called before the first frame update
    void Start()
    {
        novoJogo.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
