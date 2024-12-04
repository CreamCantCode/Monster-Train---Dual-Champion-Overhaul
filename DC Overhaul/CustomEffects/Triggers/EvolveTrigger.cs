using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Trainworks.ConstantsV2;
using Trainworks.BuildersV2;
using Trainworks.Managers;
using static StatusEffectState;
using Trainworks.Enums.MTTriggers;





namespace CustomEffects
{
    public class Evolve
    {
        
  
      public static CharacterTriggerData.Trigger Trigger;
       
      public const string TriggerID = "Evolve_Trigger";

      public static CharacterTriggerData Data;

        public static void Build()
        {    Data = new CharacterTriggerDataBuilder()
            {
                TriggerID = TriggerID,
                Trigger = Trigger,
                AdditionalTextOnTrigger = "ball trigger"

            }.Build();  

        }
       public static void OnStacksRemoved(CharacterState character, int numStacksRemoved)
  {
    if (character.GetStatusEffectStacks(StatusEffectMoltState.StatusId) < 1)
      return;character.GetCombatManager().QueueAndRunTrigger(character, Trigger);
    
  }
}


                   

    }
