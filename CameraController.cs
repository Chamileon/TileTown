using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Camera;
    [SerializeField] float offSetX = 6, offSetY = 3;

    // Update is called once per frame
    void Update()
    {
        
    }
#if UNITY_ANDROID
    public void Move() 
    {
        
    }
#endif
}
