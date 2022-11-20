using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typer : MonoBehaviour
{
    public Animator slide;
   public TMP_Text wordoutput=null;
   public WordBank wordBank=null;

   private string remainingword =string.Empty;

   private string currentword =string.Empty;
   public int wordcount=-1;
   public GameManager gameManager;

   public static Typer typer;
   void Awake()
   {
    typer=this;
   }
   private void Start()
    {
        SetCurrentWord();
        

        
    }
   

    public void SetCurrentWord()
    {
        wordcount++;
        checkwin();
        
        currentword=wordBank.GetWord();
        
       
        
        SetRemainingWord(currentword);
        
    }
    private void SetRemainingWord(string newstring)
    {
        remainingword = newstring;
        wordoutput.text = remainingword;
    }
    
    private void Update()
    {
        
        if(GameManager.instance.GameState)
        {
        CheckInput();
        }
        
    }

    private void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keyPressed=Input.inputString;
            if(keyPressed.Length==1)
            {
            EnterLetter(keyPressed);
            }
        }
    }
    private void EnterLetter(string typedLetter)
    {
        if(IscorrectLetter(typedLetter))
        {
            RemoveLetter();
            if(IsWordComplete())
            {
                 
            SetCurrentWord();
            reset();
           
            }
        }
        

    }
    private bool IscorrectLetter(string letter)
    {
        return remainingword.IndexOf(letter)==0;
    }
    private void RemoveLetter()
    {
        string newstring=remainingword.Remove(0,1);
        SetRemainingWord(newstring);
    }
    private bool IsWordComplete()
    {
        
        return remainingword.Length == 0;
       
        

    }

    private void reset()
    {
         slide.SetBool("isreset",true);
         StartCoroutine(resettime());
        

    }
    IEnumerator resettime()
    {
        yield return new WaitForSeconds(.06f);
         slide.SetBool("isreset",false);

    }
    void checkwin()
    {
        if(wordcount==10)
        {
            GameManager.instance.win();
            SetCurrentWord();
            wordcount=0;

    }
        
    }
    }
    

