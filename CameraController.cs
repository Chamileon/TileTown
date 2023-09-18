using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Android;



public enum PlusMinus { Plus , Minus}
public class CameraController : MonoBehaviour
{
    public static CameraController cameraController;
    [SerializeField] private float _offSetX = 6, _offSetY = 3;
    [SerializeField] private Joystick _joystick;
    [SerializeField] [Range(1f,50f)] private float _speed;
    [SerializeField] [Range(3f,10f)] private float _zoom = 3;
    public float Speed { get { return _speed * Time.deltaTime; } }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Awake()
    {
        transform.position = new Vector3(Matrix.matrix.MapProperties.ExtentionX * 0.5f, Matrix.matrix.MapProperties.ExtentionY * 0.5f, -10f);
        _zoom = 3f;

        Camera.main.orthographicSize = _zoom;
    }

    public void Move() 
    {
        Vector3 direction = new Vector3(_joystick.Horizontal, _joystick.Vertical, 0f) * Speed;
        transform.position += direction;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _offSetX, Matrix.matrix.MapProperties.ExtentionX - _offSetX * 2f),
            Mathf.Clamp(transform.position.y, _offSetY, Matrix.matrix.MapProperties.ExtentionY - _offSetY), -10f);
    }
    public void Zoom(PlusMinus pm) 
    {
        switch (pm) 
        {
            case PlusMinus.Minus:
                _zoom += 1f;
                break;
            case PlusMinus.Plus:
                _zoom -= 1f;
                break;
        }
        _zoom = Mathf.Clamp(_zoom, 3f, 10f);
        Camera.main.orthographicSize = _zoom;


    }
    public void ZoomPlus() 
    {
        Zoom(PlusMinus.Plus);
    }
    public void ZoomMinus() 
    {
        Zoom(PlusMinus.Minus);
    }



}
