using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject StartMenuHandler;

    public GameObject GameUI;

    public GameObject EndMenuHandler;

    public GameObject WinHandler;

    public SpriteRenderer spriterenderer;


    public static UIManager uIManager;

    public Sprite Win;

    public Sprite DefaultImage;

    public GameObject NarrationPanel;   
     void Awake() 
     {

        uIManager=this;
    }

    void Start()
    {
        CloseMenus();
       StartMenuHandler.SetActive(true);

    }
    public void CloseMenus()
    {
        GameUI.SetActive(false);
        StartMenuHandler.SetActive(false);
        EndMenuHandler.SetActive(false);
        WinHandler.SetActive(false);
        NarrationPanel.SetActive(false);
        
    }
    public void StartGame()
    {
        
        StartMenuHandler.SetActive(false);
        GameUI.SetActive(true);
        GameManager.instance.GameState=true;
    }

    public void EndGame()
    {
        GameUI.SetActive(false);
        EndMenuHandler.SetActive(true);
        GameManager.instance.GameState=false;

    }
    public void RestartGame()
    {
        EndMenuHandler.SetActive(false);
        StartMenuHandler.SetActive(true);
        
    }

    public void WinGame()
    {
        CloseMenus();
        WinHandler.SetActive(true);
        spriterenderer.sprite=Win;
        GameManager.instance.GameState=false;
    }

    public void menu()
    {
        CloseMenus();
        StartMenuHandler.SetActive(true);
        spriterenderer.sprite=DefaultImage;
        GameManager.instance.GameState=false;
        GameManager.instance.WinFX.SetActive(false);
    }      
    
    }
    

