using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public interface ISpeedController
    {
        /// <summary>
        /// Get default speed
        /// </summary>
        /// <returns>Default speed</returns>
        float GetSpeed();
        /// <summary>
        /// Set default speed
        /// </summary>
        /// <param name="s">Default speed</param>
        void SetSpeed(float s);
        /// <summary>
        /// Scale the speed by scale
        /// </summary>
        /// <param name="scale">Scale</param>
        void SetSpeedScale(float scale);
        /// <summary>
        /// Restore the speed before scaling
        /// </summary>
        void RestoreSpeedScale();
    }
}

