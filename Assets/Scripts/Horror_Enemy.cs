using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MO_HORROR
{
    public class Horror_Enemy : Horror_Actor 
    {
        public float moveSpeed;
        public float turnSpeed;
        public float health = 5.0f;
        public bool activeAtStart = false;
        public float attackDistance = 1.0f;

        public float hurtCooldown = 0.5f;

        public bool active;

        private Horror_Player player;

        private new void Start()
        {
            base.Start();
            if (activeAtStart)
                active = true;
            animator.speed = 0.5f;
            player = GameManager.Instance.player;
        }
        new void OnValidate()
        {
            base.OnValidate();
        }

        // Update is called once per frame
        new void FixedUpdate()
        {
            base.FixedUpdate();
            if (active)
            {
                transform.LookAt(player.transform);
                //transform.Translate(transform.forward * moveSpeed * GameManager.Instance.GameplayDeltaTime);
                transform.position += transform.forward * moveSpeed * GameManager.Instance.GameplayDeltaTime;
                Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red);
                animator.SetFloat("speed", moveSpeed);
                animator.SetFloat("rotateAmount", turnSpeed);

                CheckForAttack();
            }

            if (hurtCooldown > 0)
            {
                hurtCooldown -= Time.deltaTime;
            }
        }

        private void CheckForAttack()
        {
            if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
            {
                // if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == "")
                animator.SetTrigger("startAttack");

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == GameManager.Instance.player.gameObject)
            {
                active = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == GameManager.Instance.player.gameObject)
            {
                // active = false;
            }
        }

        public void GetHurt(float damage)
        {
            if (hurtCooldown <= 0)
            {
                animator.SetTrigger("getHurt");
                health -= damage;
                Debug.Log(damage + " damage, " + health + " hp remaining");
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}