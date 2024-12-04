
using Trainworks.BuildersV2;
using Trainworks.Constants;

namespace MonsterTrainModdingTemplate.StatusEffects
{
    class eateat
    {
        public static void BuildAndRegister()
        {
            // Register the status effect with StatusEffectManager


          


            new StatusEffectDataBuilder
            {
                // Status Effect Subclass to use to run the effect.
                StatusEffectStateType = typeof(StatusEffectAmbushState),
                StatusID = VanillaStatusEffectIDs.Buffet,
                Name = "eateat",
                Description = "eateat",
                DisplayCategory = StatusEffectData.DisplayCategory.Positive,
                // Determines when to test to trigger the status effect.
                TriggerStage = StatusEffectData.TriggerStage.OnAmbush,
                RemoveAtEndOfTurn = true,
                // Free image from flaticon. Attribution <a href="https://www.flaticon.com/free-icons/weakness" title="weakness icons">Weakness icons created by Freepik - Flaticon</a>
                // This should be a black and white image sized 24x24.
                IconPath = "assets/status_weakness.png",
                ParamInt = 1,
            }.Build();
        }
    }
}
