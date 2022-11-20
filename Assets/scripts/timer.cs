using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
public float matchtimer=20f;
public float currentmatchtimer;
public TMP_Text timerText;







 void Awake() 
 {

   SetupTimer();
 }


void Start()
{
  
}

void  SetupTimer()
{
   if (matchtimer>0)
   {
      currentmatchtimer=matchtimer;      
   }
   UpdateMatchTimer();
}
void Update()
{
   if(GameManager.instance.GameState)
   {
   if(currentmatchtimer>0)
   {
      currentmatchtimer-=Time.deltaTime;
      
      UpdateMatchTimer();
   }
   if(currentmatchtimer<=0)
   {
      currentmatchtimer=0;
      checkloose();
      
   }
   }
   else
   {
      ResetTimer();
   }
   
}
 void UpdateMatchTimer()
 {
   var displayTime=System.TimeSpan.FromSeconds(currentmatchtimer);
   timerText.text=displayTime.Seconds.ToString("00");
   

 }
 void checkloose()
    {
        
        
            GameManager.instance.loose();
            GameManager.instance.GameState=false;
            ResetTimer();
            Typer.typer.SetCurrentWord();
            
            
    }
    void ResetTimer()
    {
      SetupTimer();


    }
   
}
