using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoaderGif : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Start()
    {
        
        StartCoroutine(LoadPoints());
    }
    public void addPoint() 
    {
        _text.text += ".";
    }
    public void DeletePoints() 
    {
        _text.text = "";
    }
    private IEnumerator LoadPoints()
    {
        do
        {
            DeletePoints();
            int iterations = 0;
            while (!God.god.IsNextStepReady && iterations < 3)
            {
                Debug.Log(iterations);
                addPoint();
                iterations++;
                yield return new WaitForSecondsRealtime(60f * Time.deltaTime);

            }
            DeletePoints();
        } while (God.god.IsNextStepReady == false) ;



    }
    private bool Filter3(int a) 
    { 
        if (a % 3 == 0) 
        {
            return true;
        } 
        else return false;
    }
    
}
