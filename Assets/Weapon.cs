using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MO_HORROR
{
    public class Weapon : MonoBehaviour
    {
        new CapsuleCollider collider;
        public float damage = 1.0f;

        private void OnValidate()
        {
            collider = transform.GetOrAddComponent<CapsuleCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // we only care about colliding with real stuff
            if (other.isTrigger) return;
            Horror_Enemy enemy = other.gameObject.GetComponent<Horror_Enemy>();
            if (enemy != null)
            {
                enemy.GetHurt(damage);
            }
        }
    }
}
