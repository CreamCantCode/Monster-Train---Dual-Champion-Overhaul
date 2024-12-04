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
    public class StatusEffectMoltState : StatusEffectState
    {
        
         public const string StatusId = "molt";
        //public static List<CardState> cardsTriggeredOn = new List<CardState>() { };

       public override bool TestTrigger(
             InputTriggerParams inputTriggerParams,
            OutputTriggerParams outputTriggerParams)
               {
                return false;
                } 
       
        
       public override void OnStacksRemoved(CharacterState character, int numStacksRemoved)
  {
    if (character.GetStatusEffectStacks(StatusId) > 0)
      return;
      character.GetCombatManager().QueueTrigger(character, Evolve.Trigger);
    
  }
}


                   

    }
