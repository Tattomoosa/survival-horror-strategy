using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MO_COLLIDER_ZONE_VIS
{
    public class ColliderZoneVisualizer : MonoBehaviour
    {
        public ColliderZone[] colliderZones;

        private void OnValidate()
        {
            Init();
        }

        private void Init()
        {
            BoxCollider[] boxColliders = gameObject.GetComponentsInChildren<BoxCollider>();

            int count = boxColliders.Length;
            colliderZones = new ColliderZone[count];
            for (int i=0;i<count;i++)
            {
                colliderZones[i] = ScriptableObject.CreateInstance<ColliderZone>();
                colliderZones[i].Init(boxColliders[i], Color.red);
            }

        }

        [ExecuteInEditMode]
        private void OnDrawGizmos()
        {
            if (colliderZones.Length > 0 && Selection.activeGameObject == gameObject)
                foreach (ColliderZone cz in colliderZones)
                {
                    cz.Draw();
                }
        }
    }
}
