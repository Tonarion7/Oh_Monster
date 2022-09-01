using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class camera : MonoBehaviour

{

    //������ ���

    public Transform target;

    //ī�޶���� �Ÿ�

    public float dist = 4f;



    //ī�޶� ȸ�� �ӵ�

    public float xSpeed = 220.0f;

    public float ySpeed = 100.0f;



    //ī�޶� �ʱ� ��ġ

    private float x = 0.0f;

    private float y = 20f;



    //y�� ���� (�� �Ʒ� ����)

    public float yMinLimit = -20f;

    public float yMaxLimit = 80f;



    //�ޱ��� �ּ�,�ִ� ����

    float ClampAngle(float angle, float min, float max)

    {

        if (angle < -360)

            angle += 360;

        if (angle > 360)

            angle -= 360;

        return Mathf.Clamp(angle, min, max);

    }

    void Start()

    {

        //Cursor.lockState = CursorLockMode.Locked; //Ŀ�� ����

        Vector3 angles = transform.eulerAngles;



        x = angles.y;

        y = angles.x;

    }



    void Update()

    {

        //ī�޶� ȸ���ӵ� ���

        x += Input.GetAxis("Mouse X") * xSpeed * 0.015f;

        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.015f;



        //�ޱ۰� ���ϱ�(y�� ����)

        y = ClampAngle(y, yMinLimit, yMaxLimit);



        //ī�޶� ��ġ ��ȭ ���

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        Vector3 position = rotation * new Vector3(0, 0.9f, -dist) + target.position + new Vector3(0.0f, 0, 0.0f);



        transform.rotation = rotation;

        target.rotation = Quaternion.Euler(0, x, 0);

        transform.position = position;

    }

}