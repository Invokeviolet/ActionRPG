using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas TITLECANVAS;
    [SerializeField] Canvas GENERALCANVAS;
    //[SerializeField] Canvas INGAMECANVAS;
    [SerializeField] Canvas STORECANVAS;
    //[SerializeField] Canvas ACTIONCANVAS;
    //[SerializeField] Canvas BOSSCANVAS;
    [SerializeField] Canvas GAMECLEARCANVAS;
    [SerializeField] Canvas GAMEOVERCANVAS;
    [SerializeField] Canvas YOUWINCANVAS;
    [SerializeField] Canvas YOULOSECANVAS;

    [SerializeField] TextMeshProUGUI PlayerInfo;
    [SerializeField] TextMeshProUGUI MapInfo;
    [SerializeField] TextMeshProUGUI MonsterInfo;
    [SerializeField] public TextMeshProUGUI HaveAPotion;
    [SerializeField] public TextMeshProUGUI HaveAGold;
    [SerializeField] Button ReturnButton; // 나중에 삭제
    [SerializeField] Button BuyButton;
    [SerializeField] Button StartButton;


    // 싱글톤
    #region 싱글톤

    private static UIManager Instance = null;
    public static UIManager INSTANCE
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<UIManager>();
            }
            DontDestroyOnLoad(Instance.gameObject);
            return Instance;
        }
    }
    #endregion

    Action action;
    Action ingame;
    
    private void Awake()
    {
        action += BUYPOTION;
        BuyButton.onClick.AddListener(delegate () { action(); });

        ingame += LOADINGAMESCENE;
        ReturnButton.onClick.AddListener(delegate () { ingame(); });

        TITLECANVAS.gameObject.SetActive(false);
        GENERALCANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(false);
        GAMECLEARCANVAS.gameObject.SetActive(false);
        GAMEOVERCANVAS.gameObject.SetActive(false);
        YOUWINCANVAS.gameObject.SetActive(false);
        YOULOSECANVAS.gameObject.SetActive(false);

    }
    
    public void Start()
    {
        TITLESCENE();
    }

    //
    // SCENE UI
    #region SCENE UI

    public void TITLESCENE()
    {
        /* PlayerInfo.gameObject.SetActive(false);
         MapInfo.gameObject.SetActive(false);
         MonsterInfo.gameObject.SetActive(false);
         ReturnButton.gameObject.SetActive(false);*/

        TITLECANVAS.gameObject.SetActive(true);//        
        GENERALCANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(false);
        GAMECLEARCANVAS.gameObject.SetActive(false);
        GAMEOVERCANVAS.gameObject.SetActive(false);
        YOUWINCANVAS.gameObject.SetActive(false);
        YOULOSECANVAS.gameObject.SetActive(false);
    }
    public void GENERALSCENE()
    {
        /*PlayerInfo.gameObject.SetActive(true);
        MapInfo.gameObject.SetActive(true);
        MonsterInfo.gameObject.SetActive(true);
        ReturnButton.gameObject.SetActive(true);*/

        GENERALCANVAS.gameObject.SetActive(true);
        MonsterInfo.gameObject.SetActive(false);
        TITLECANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(false);
        GAMECLEARCANVAS.gameObject.SetActive(false);
        GAMEOVERCANVAS.gameObject.SetActive(false);
        YOUWINCANVAS.gameObject.SetActive(false);
        YOULOSECANVAS.gameObject.SetActive(false);
    }
    public void ACTIONSCENE()
    {
        GENERALCANVAS.gameObject.SetActive(true);
        MonsterInfo.gameObject.SetActive(true);
        TITLECANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(false);
        GAMECLEARCANVAS.gameObject.SetActive(false);
        GAMEOVERCANVAS.gameObject.SetActive(false);
        YOUWINCANVAS.gameObject.SetActive(false);
        YOULOSECANVAS.gameObject.SetActive(false);
    }

    public void STORESCENE()
    {
        GENERALCANVAS.gameObject.SetActive(false);
        TITLECANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(true);//        
        GAMECLEARCANVAS.gameObject.SetActive(false);
        GAMEOVERCANVAS.gameObject.SetActive(false);
        YOUWINCANVAS.gameObject.SetActive(false);
        YOULOSECANVAS.gameObject.SetActive(false);
    }

    public void GAMECLEARSCENE()
    {
        GENERALCANVAS.gameObject.SetActive(false);
        TITLECANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(false);
        GAMECLEARCANVAS.gameObject.SetActive(true);//        
        GAMEOVERCANVAS.gameObject.SetActive(false);
        YOUWINCANVAS.gameObject.SetActive(false);
        YOULOSECANVAS.gameObject.SetActive(false);
    }
    public void GAMEOVERSCENE()
    {
        GENERALCANVAS.gameObject.SetActive(false);
        TITLECANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(false);
        GAMECLEARCANVAS.gameObject.SetActive(false);
        GAMEOVERCANVAS.gameObject.SetActive(true);//        
        YOUWINCANVAS.gameObject.SetActive(false);
        YOULOSECANVAS.gameObject.SetActive(false);
    }
    public void YOUWINSCENE()
    {
        GENERALCANVAS.gameObject.SetActive(false);
        TITLECANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(false);
        GAMECLEARCANVAS.gameObject.SetActive(false);
        GAMEOVERCANVAS.gameObject.SetActive(false);
        YOUWINCANVAS.gameObject.SetActive(true);//        
        YOULOSECANVAS.gameObject.SetActive(false);
    }
    public void YOULOSESCENE()
    {
        GENERALCANVAS.gameObject.SetActive(false);
        TITLECANVAS.gameObject.SetActive(false);
        STORECANVAS.gameObject.SetActive(false);
        GAMECLEARCANVAS.gameObject.SetActive(false);
        GAMEOVERCANVAS.gameObject.SetActive(false);
        YOUWINCANVAS.gameObject.SetActive(false);
        YOULOSECANVAS.gameObject.SetActive(true);//
    }

    #endregion

    //
    // GET INFO
    #region GET INFO
    public void GETPLAYERINFO(string playerinfo) // 플레이어와 충돌해서 얻은 정보 출력
    {
        //PlayerInfo = GENERALCANVAS.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //PlayerInfo.text = GameManager.INSTANCE.GetPlayer().GETMYINFO().ToString();
        PlayerInfo.text = playerinfo.ToString();
    }
    public void GETMAPINFO(MAPINFO mapinfo) // 플레이어와 충돌해서 얻은 정보 출력
    {
        //MapInfo = GENERALCANVAS.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        MapInfo.text = "MAPINFO " + mapinfo.ToString();
    }
    public void GETMOBINFO(MOBINFO mobinfo) // 플레이어와 충돌해서 얻은 정보 출력
    {
        //MonsterInfo = GENERALCANVAS.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        MonsterInfo.text = "LV " + mobinfo.ToString() + "\nHP " + Monster.INSTANCE.GetHP();
    }
    #endregion

    //
    // Button UI
    #region Button UI
    public void BUYPOTION()
    {
        if (Player.INSTANCE.Unavailable == true) // 골드가 없을 때 물약구매 막기
        {
            Player.INSTANCE.SetPotion(0);
            Player.INSTANCE.SetGold(0);
        }
        else if (Player.INSTANCE.Unavailable == false)
        {
            Player.INSTANCE.SetPotion(1);
            Player.INSTANCE.SetGold(10);
        }

        HaveAGold.text = "GOLD " + Player.INSTANCE.GetGold().ToString();
        HaveAPotion.text = "POTION " + Player.INSTANCE.GetPotion().ToString();
    }
    void LOADINGAMESCENE()
    {
        ChangeSceneManager.INSTANCE.INGAMESCENE();
    }

    #endregion
}
