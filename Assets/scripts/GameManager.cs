using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance;
    public GameObject Explosion;
    public GameObject EAudio;
    public bool GameState;

    public GameObject WinFX;

    public GameObject WinAudio;

    public GameObject GameAudio;
    
    void Awake()
 
     {
     instance=this;
     }       
    void Start()
    {
        UIManager.uIManager.NarrationPanel.SetActive(true);
        StartCoroutine
          (NarrationDelay());
        

         
    }
    IEnumerator NarrationDelay()
    {
      yield return new WaitForSeconds(2f);
      //UIManager.uIManager.NarrationPanel.SetActive(false);
      UIManager.uIManager.CloseMenus();
      UIManager.uIManager.StartMenuHandler.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       if(GameState)
       {
        PlayGameAudio();
       }
       else
       {
        MuteAudio();
       }
    
       
    }
    public void win()
    {
      Debug.Log("win");
      UIManager.uIManager.WinGame();
      WinFX.SetActive(true);
      GameObject WinAudioinstance= Instantiate(WinAudio,new Vector3(0,0,0),Quaternion.identity);
      GameState=false;
      Destroy(WinAudioinstance,2f);
      



    }
    public void loose()
    {
      Debug.Log("loose");
      Instantiate(Explosion,new Vector3(0,0,0),Quaternion.identity);
      GameObject EAudioinstance=Instantiate(EAudio,new Vector3(0,0,0),Quaternion.identity);
      UIManager.uIManager.EndGame();
       Destroy(EAudioinstance,2f);

    }

    void PlayGameAudio()
    {
      GameAudio.SetActive(true);

    }
    void MuteAudio()
    {
      GameAudio.SetActive(false);
    }
    
    
}
