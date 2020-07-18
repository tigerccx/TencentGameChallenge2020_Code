using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework.Util
{
    public class Utility
    {
        public static bool IsOrIsSubClassOf(object oSrc, System.Type tComp)
        {
            System.Type tSrc = oSrc.GetType();
            if (tSrc == tComp || tSrc.IsSubclassOf(tComp))
                return true;
            else
                return false;
        }
    }
}

