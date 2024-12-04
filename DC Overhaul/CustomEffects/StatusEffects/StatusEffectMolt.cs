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
    public class MoltData
    {
        public static StatusEffectData data;

       
        public static void BuildAndRegister()
        {

            data = new StatusEffectDataBuilder()
            {
                StatusEffectStateType = typeof(StatusEffectMoltState),
                StatusID = StatusEffectMoltState.StatusId,
                Name = "Molt",
                Description = "This Unit is in the process of Evolution",
                IconPath = "assets/status_weakness.png",
                TriggerStage = StatusEffectData.TriggerStage.OnPostCombatPoison,
                DisplayCategory = StatusEffectData.DisplayCategory.Persistent,
                IsStackable = true,
                ShowStackCount = true,
                RemoveStackAtEndOfTurn = true,               

            }.Build();

 
        }

       }
}