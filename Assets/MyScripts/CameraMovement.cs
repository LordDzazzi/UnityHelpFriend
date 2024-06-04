using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform leftBorder; // ����������
    public Transform upBorder;
    public Transform downBorder;
    public Transform rightBorder;
    public Transform player;
    private Vector3 point;
    public Vector3 offset;
    public float smoothTime;
    void Folowing() //����� �������������
    {
        Vector3 pointPosition = Vector3.Lerp(transform.position, player.position, smoothTime * Time.fixedDeltaTime);
        transform.position = pointPosition + offset;

    }
    void Start() //����� �����
    {

    }
    private void FixedUpdate() //����� ����. ������
    {
        Folowing();
        Limit();
    }
    void Limit() //����� �����(����� ��� ������)
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder.position.x, rightBorder.position.x),
            Mathf.Clamp(transform.position.y, downBorder.position.y, upBorder.position.y),
            offset.z
            );
    }
}
