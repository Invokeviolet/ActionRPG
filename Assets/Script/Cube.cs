using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cube : MonoBehaviour
{
    MAPINFO myInfo;
    // ��ǥ �޾ƿ���
    public Vector3 MAPPOSITION { get; set; }
    // ���� �޾ƿ���
    public Color MAPCOLOR { get; set; }
    // �̸� �޾ƿ���
    public string MAPNAME { get; set; }
    // �� �޾ƿ���
    public int MAPNUM { get; set; }
    // ���� �޾ƿ���
    public string MONSTER { get; set; }
    // �� ���� 
    public MAPINFO MAPINFO { get { return myInfo; } set { myInfo = value; } }


    // ����
    public void Init(Vector3 pos, MAPINFO info)
    {

        // ť�긶�� ������ ���� ���
        this.MAPPOSITION = pos;
        this.myInfo = info;

        // �� ������Ʈ�� Meterial�� �����ͼ� ���� ����
        Material myM = GetComponent<MeshRenderer>().material;

        if (info == MAPINFO.FOREST) //0
        {
            MAPCOLOR = Color.green;
            MAPNAME = "��";
            MAPNUM = 0;
            this.gameObject.tag = "Forest";
        }
        if (info == MAPINFO.SWAMP) //1
        {
            MAPCOLOR = Color.blue;
            MAPNAME = "��";
            MAPNUM = 1;
            this.gameObject.tag = "Swamp";
        }
        if (info == MAPINFO.GROUND) //2
        {
            MAPCOLOR = Color.yellow;
            MAPNAME = "����";
            MAPNUM = 2;
            this.gameObject.tag = "Ground";
        }
        if (info == MAPINFO.SHOP) //3
        {
            MAPCOLOR = Color.black;
            MAPNAME = "����";
            MAPNUM = 3;
            this.gameObject.tag = "Store";
            // ������ �� ���� ����
        }
        if (info == MAPINFO.START) //4
        {
            MAPCOLOR = Color.white;
            MAPNAME = "���";
            MAPNUM = 4;
            this.gameObject.tag = "Start";
        }
        if (info == MAPINFO.END) //5
        {
            MAPCOLOR = Color.white;
            MAPNAME = "����";
            MAPNUM = 5;
            this.gameObject.tag = "End";
        }

        myM.color = MAPCOLOR;
    }



}
