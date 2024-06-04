using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform leftBorder; // переменные
    public Transform upBorder;
    public Transform downBorder;
    public Transform rightBorder;
    public Transform player;
    private Vector3 point;
    public Vector3 offset;
    public float smoothTime;
    void Folowing() //метод приследования
    {
        Vector3 pointPosition = Vector3.Lerp(transform.position, player.position, smoothTime * Time.fixedDeltaTime);
        transform.position = pointPosition + offset;

    }
    void Start() //метод старт
    {

    }
    private void FixedUpdate() //метод фикс. апдейт
    {
        Folowing();
        Limit();
    }
    void Limit() //метод лимит(лимит для камеры)
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder.position.x, rightBorder.position.x),
            Mathf.Clamp(transform.position.y, downBorder.position.y, upBorder.position.y),
            offset.z
            );
    }
}
