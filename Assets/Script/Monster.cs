using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // 싱글톤
    #region 싱글톤

    private static Monster Instance = null;
    public static Monster INSTANCE
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<Monster>();
            }
            return Instance;
        }
    }
    #endregion


    public int MONSTERCURHP=0;
    //public int MONSTERMAXHP=100;

    bool IsDie { get; set; }

    MOBINFO mobInfo;
    // 좌표 받아오기
    public Vector3 pos { get; set; }
    // 색상 받아오기
    public Color prefabCol { get; set; }  
    // 몬스터 받아오기
    public string monster { get; set; }
    
    // 맵 정보 
    public MOBINFO MOBINFO { get { return mobInfo; } set { mobInfo = value; } }

    // 체력
    public int GetHP()
    {
        return MONSTERCURHP;
    }
    public void SetHP(int hp)
    {
        this.MONSTERCURHP = hp;
    }

    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AttackPlayer();
        }
    }
    // 몬스터 공격 조건 : 플레이어가 공격하면 1초후 랜덤 데미지 만큼 공격
    public void AttackPlayer()
    {
        int rndDamage = Random.Range(0, 10);
        GameManager.INSTANCE.GetPlayer().SetHP(rndDamage);
    }

    /*IEnumerator AttackPlayer()
    {
        int rndDamage = Random.Range(0, 10);
        GameManager.INSTANCE.GetPlayer().SetHP(rndDamage);
        yield return new WaitForSeconds(1f);
    }*/

    // 공격받으면 들어온 데미지만큼 HP 감소
    public void HitMonster(int damage)
    {
        MONSTERCURHP -= damage;
        if (MONSTERCURHP <= 0)
        {
            DeadMonster();
        }
    }
    public void DeadMonster()
    {
        Destroy(this.gameObject);
    }

    // 대전 게임
    // 플레이어 공격 범위 안에 있는 모든 몬스터에게 공격 가능

    // 생성
    public void Init(Vector3 pos, MOBINFO info)
    {
        // 큐브마다 랜덤한 몬스터 출력
        this.pos = pos;
        this.mobInfo = info;

        // 내 컴포넌트의 Meterial을 가져와서 색상 변경
        Material myM = GetComponent<MeshRenderer>().material;

        if (info == MOBINFO.EASY) //0
        {
            prefabCol = Color.cyan;
            name = "0";
            SetHP(50);
        }
        if (info == MOBINFO.NORMAL) //1
        {
            prefabCol = Color.blue;
            name = "1";
            SetHP(100);
        }
        if (info == MOBINFO.HARD) //2
        {
            prefabCol = Color.magenta;
            name = "2";
            SetHP(180);
        }
        if (info == MOBINFO.BOSS) //3
        {
            prefabCol = Color.black;
            name = "3";
            SetHP(300);
        }

        myM.color = prefabCol;
    }
}
