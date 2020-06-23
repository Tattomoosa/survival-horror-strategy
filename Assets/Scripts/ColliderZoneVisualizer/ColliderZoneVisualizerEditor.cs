using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MO_COLLIDER_ZONE_VIS
{
    [CustomEditor(typeof(ColliderZoneVisualizer))]
    public class ColliderZoneVisualizerEditor : Editor
    {
        ColliderZoneVisualizer targetColliderZoneVisualizer;
    }
}
