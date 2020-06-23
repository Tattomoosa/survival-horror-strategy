using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MO_COLLIDER_ZONE_VIS
{
    [CustomEditor(typeof(ColliderZone))]
    public class ColliderZoneEditor : Editor
    {
        private void OnSceneGUI()
        {
            Debug.Log("In OnSceneGUI");
        }
    }
}
