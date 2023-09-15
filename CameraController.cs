using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Android;

public class CameraController : MonoBehaviour
{
    public static CameraController Camera;
    [SerializeField] private float offSetX = 6, offSetY = 3;
    [SerializeField] private Joystick joystick;
    [SerializeField] [Range(1f,50f)] private float speed;
    public float Speed { get { return speed * Time.deltaTime; } }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Awake()
    {
        transform.position = new Vector3(Matrix.matrix.MapProperties.ExtentionX * 0.5f, Matrix.matrix.MapProperties.ExtentionY * 0.5f, -10f);
    }

    public void Move() 
    {
        Vector3 direction = new Vector3(joystick.Horizontal, joystick.Vertical, 0f) * Speed;
        transform.position += direction;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, offSetX, Matrix.matrix.MapProperties.ExtentionX - offSetX * 2f),
            Mathf.Clamp(transform.position.y, offSetY, Matrix.matrix.MapProperties.ExtentionY - offSetY), -10f);
    }



}
