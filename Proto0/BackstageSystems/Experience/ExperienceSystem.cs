using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFramework;
using System;

namespace Proto0
{
    public class ExperienceSystem : MonoSingleton<ExperienceSystem>
    {
        //!!!TEST!!!
        public TestUI ui;

        public event Action<float, float> eventOnExpChanged;  // Action<expTotal, expDiff>
        public event Action<float, float> eventOnExpReached;  // Action<expTotal, expReached>

        public List<float> experienceStages;
        private int stageCur;
        private bool isTopStage = false;
        private int StageCur 
        { 
            get => stageCur; 
            set { stageCur = value; if (stageCur == experienceStages.Count - 1) isTopStage = true; } 
        }

        private float experience;
        public float Experience 
        { 
            get => experience; 
            private set 
            { 
                float expDiff = value - experience;  
                experience = value; 
                eventOnExpChanged?.Invoke(experience, expDiff);
                if (!isTopStage)
                {
                    if (experience > experienceStages[stageCur + 1])
                    {
                        StageCur += 1;
                        eventOnExpReached?.Invoke(experience, experienceStages[StageCur]);
                    }
                }
            } 
        }

        // Start is called before the first frame update
        void Start()
        {
            //!!!TEST!!!
            eventOnExpChanged += ui.ShowExperience;
            eventOnExpReached += ui.ShowExperienceStage;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AccumulateExperience(float exp)
        {
            Experience = exp + Experience;
        }
    }

}
