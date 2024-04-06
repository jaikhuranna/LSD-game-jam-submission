using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
   // integers used to counter the number of clicks 
   public int playagainCounter, mainmenuCounter, Counter;
   // Game objects used to set them Active 
   public GameObject playagainGameObj, mainmenuGameObj, gameoverObj, letterObj;
   //You lost text 
   [SerializeField] private TMP_Text YLtext;

   private void Start()
   { 
   }

   public void playagainButton()
   {
      //adding counter when you press play again button
      playagainCounter++;
      // check if the counter is equal to play again counter
      if (playagainCounter == Counter)
      {
         playagainGameObj.SetActive(false);
      }
      // using switch case to change the position of the button UI
      switch (playagainCounter)
      {
         case 1:
            playagainGameObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-211,-21);
            break;
         case 2:
            playagainGameObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(238,62);
            break;
         case 3:
            playagainGameObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(292,-133);
            break;
      }

   }
   
   public void mainmenuButton()
   {
      //adding counter when you press play again button
      mainmenuCounter++;
      // check if the counter is equal to main menu counter
      if (mainmenuCounter == Counter)
      {
         mainmenuGameObj.SetActive(false);
      }
      // using switch case to change the position of the button UI
      switch (mainmenuCounter)
      {
         case 1:
            mainmenuGameObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-282,-86);
            break;
         case 2:
            mainmenuGameObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-160,97);
            break;
         case 3:
            mainmenuGameObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(284,-92);
            break;
      }
   }

   private void Update()
   {
      //check if both the counters are equal to main menu counter and play again counter
      if (mainmenuCounter == Counter && playagainCounter == Counter)
      {
         gameoverObj.SetActive(false);
         letterObj.SetActive(true);
      }

      switch (mainmenuCounter+playagainCounter)
      {
         case 1:
            YLtext.text = "You Lost";
            YLtext.rectTransform.anchoredPosition = new Vector2(-280, -167);
            break;
         case 2:
            YLtext.text = "Yeu Lost";
            YLtext.rectTransform.anchoredPosition = new Vector2(283, 142);
            break;
         case 3:
            YLtext.text = "Yeur Lost";
            YLtext.rectTransform.anchoredPosition = new Vector2(-237, 40);
            break;
         case 4:
            YLtext.text = "Yeur Loat";
            YLtext.rectTransform.anchoredPosition = new Vector2(3, -117);
            break;
         case 5:
            YLtext.text = "Deur L";
            YLtext.rectTransform.anchoredPosition = new Vector2(-225, -127);
            break;
         case 6:
            YLtext.text = "Dear Alan";
            YLtext.rectTransform.anchoredPosition = new Vector2(-297, 195);
            break;
         
      }
   }
}
