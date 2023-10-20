using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
    public static WindowsController controller;
    [SerializeField] [Range(0, 0)] private int _chooseWindows;
    /// <summary>
    /// 0 => Loading windows;
    /// </summary>
    [SerializeField] private GameObject[] _windows;
    private void Awake()
    {
        controller = this;
    }
    public void OpenCloseWindows(bool open) 
    {
        if (open) 
        {
            _windows[_chooseWindows].SetActive(open); 
        }
        else 
        {
            _windows[_chooseWindows].SetActive(open);
        }
    }
}
