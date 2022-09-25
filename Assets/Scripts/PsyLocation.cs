using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PsyLocation : MonoBehaviour
{
    public Text ProText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LocationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LocationCoroutine()
    {
        Input.location.Start();
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            ProText.text = Input.location.status.ToString() 
                +Input.location.lastData.latitude.ToString()
                + "," + Input.location.lastData.longitude.ToString();
        }
    }

}
