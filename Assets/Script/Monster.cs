using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // �̱���
    #region �̱���

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
    // ��ǥ �޾ƿ���
    public Vector3 pos { get; set; }
    // ���� �޾ƿ���
    public Color prefabCol { get; set; }  
    // ���� �޾ƿ���
    public string monster { get; set; }
    
    // �� ���� 
    public MOBINFO MOBINFO { get { return mobInfo; } set { mobInfo = value; } }

    // ü��
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
    // ���� ���� ���� : �÷��̾ �����ϸ� 1���� ���� ������ ��ŭ ����
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

    // ���ݹ����� ���� ��������ŭ HP ����
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

    // ���� ����
    // �÷��̾� ���� ���� �ȿ� �ִ� ��� ���Ϳ��� ���� ����

    // ����
    public void Init(Vector3 pos, MOBINFO info)
    {
        // ť�긶�� ������ ���� ���
        this.pos = pos;
        this.mobInfo = info;

        // �� ������Ʈ�� Meterial�� �����ͼ� ���� ����
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
