using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    private List<string> OrginalWords= new List<string>()
    {
       "dog","abdicate","easiness","galactico","xmas","labour","dettabayo","oakland","unity","potato","cat"
        
    };
    private List<string> WorkingWords= new List<string>();

    private void Awake()
    {
        WordSetup();

    }

    private void WordSetup()
    {
        WorkingWords.AddRange(OrginalWords);
        Mix(WorkingWords);
        ConvertToLower(WorkingWords);
    }

    private void Mix(List<string>list)
    {
        for(int i=0; i<list.Count; i++)
        {
            int random = Random.Range(i,list.Count);
            string temporary=list[i];
            list[i]=list[random];
            list[random]=temporary;
        }
    }
    private void ConvertToLower(List<string>list)
    {
        for(int i=0; i<list.Count; i++)
        {
        list[i]=list[i].ToLower();
        }
    }
    public string GetWord() 
    {
        string newword=string.Empty;
        if(WorkingWords.Count!=0)
        {
            newword=WorkingWords.Last();
            WorkingWords.Remove(newword);
            return newword;
        }
        else
        {
            WordSetup();
            newword=WorkingWords.Last();
             WorkingWords.Remove(newword);
             return newword;
        }
        
        
    }

   
}
