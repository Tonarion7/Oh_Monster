using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public Transform[] points;
    //���� �������� �Ҵ��� ����\
    public GameObject monsterPrefab;

    public GameObject slime;
    public GameObject turtle;
    //���͸� �߻���ų �ֱ�
    public float createTime = 3f;
    //������ �ִ� �߻� ����
    public int maxMonster = 3;
    //���� ���� ���� ����
    public bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        //Hierarchy View�� Spawn Point�� ã�� ������ �ִ� ��� Transform ������Ʈ�� ã�ƿ�
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            //���� ���� �ڷ�ƾ �Լ� ȣ��
            StartCoroutine(this.CreateMonster());
        }
    }

    IEnumerator CreateMonster()
    {
        //���� ���� �ñ��� ���� ����
        while (!isGameOver)
        {
            //���� ������ ���� ���� ����
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("monster").Length;

            if (monsterCount < maxMonster)
            {
                //������ ���� �ֱ� �ð���ŭ ���
                yield return new WaitForSeconds(createTime);

                //�ұ�Ģ���� ��ġ ����
                int idx = Random.Range(1, points.Length);
                //�ұ�Ģ���� ���� ���� ����
                int kind = Random.Range(1, 3);
                if(kind == 1)
                {
                    monsterPrefab = slime;
                }
                else
                {
                    monsterPrefab = turtle;
                }
                //������ ���� ����
                Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}
