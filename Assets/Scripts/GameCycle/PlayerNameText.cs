using System;
using TMPro;
using UnityEngine;

public class PlayerNameText : MonoBehaviour
{
   private void Start()
   {
      var tmpro = GetComponent<TextMeshProUGUI>();
      ReplacePlayerName(tmpro);
   }

   public static void ReplacePlayerName(TextMeshProUGUI tmpro)
   {
      tmpro.text = tmpro.text.Replace("player", DaysManager.Instance.PlayerName);
   }
}
