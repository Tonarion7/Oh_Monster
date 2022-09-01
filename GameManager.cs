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
    //몬스터 프리팹을 할당할 변수\
    public GameObject monsterPrefab;

    public GameObject slime;
    public GameObject turtle;
    //몬스터를 발생시킬 주기
    public float createTime = 3f;
    //몬스터의 최대 발생 개수
    public int maxMonster = 3;
    //게임 종료 여부 변수
    public bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        //Hierarchy View의 Spawn Point를 찾아 하위에 있는 모든 Transform 컴포넌트를 찾아옴
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            //몬스터 생성 코루틴 함수 호출
            StartCoroutine(this.CreateMonster());
        }
    }

    IEnumerator CreateMonster()
    {
        //게임 종료 시까지 무한 루프
        while (!isGameOver)
        {
            //현재 생성된 몬스터 개수 산출
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("monster").Length;

            if (monsterCount < maxMonster)
            {
                //몬스터의 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(createTime);

                //불규칙적인 위치 산출
                int idx = Random.Range(1, points.Length);
                //불규칙적인 몬스터 종류 산출
                int kind = Random.Range(1, 3);
                if(kind == 1)
                {
                    monsterPrefab = slime;
                }
                else
                {
                    monsterPrefab = turtle;
                }
                //몬스터의 동적 생성
                Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}
