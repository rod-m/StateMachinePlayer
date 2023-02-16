using System;
using Unity.VisualScripting;
using UnityEngine;

namespace GenericStateSystem.ActionStates
{
    public class PatrolState : NPCGenericState
    {
        private GameObject[] _patrolPoints;
        private Quaternion _lookRotation;
        //private float _rotationSpeed = 5f;
        GameObject closestPoint = null;
        private int patrolIndex = 0;
        
        public PatrolState(BaseCharacter _c, StateMachine _s) : base(_c, _s)
        {
            
        }

        public override void BeginState()
        {
            FindNearestPatrolPoint();
        }

        void FindNearestPatrolPoint()
        {
            // where am I going
            _patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
           // float closest = Single.MaxValue;
            closestPoint = _patrolPoints[patrolIndex % _patrolPoints.Length];


            if (closestPoint != null)
            {
                _character.currentTarget = closestPoint.transform;
                Debug.Log($"Goto at patrol point {closestPoint.name}");
                patrolIndex++;
            }
        }

        public override void UpdateState()
        {
            if (closestPoint != null)
            {
                _character.FaceCurrentTarget(0);
                _character.anim.SetFloat("Speed", _character.patrolSpeed);
                if (Vector3.Distance(_character.transform.position, closestPoint.transform.position) < 0.5f)
                {
                    //arrived
                    Debug.Log($"Arrived at patrol point {closestPoint.name}");
                    FindNearestPatrolPoint();
                }
            }
        }

        public override void UpdatePhysicsState()
        {
        }

        public override void TransitionState()
        {
            Vector3 p1 = _character.transform.position + Vector3.up;
        float targetDistance = Single.MaxValue;
        ;
            RaycastHit hit;
            Debug.DrawRay(p1,
                _character.transform.TransformDirection(Vector3.forward) * 6f, Color.green);
            Debug.DrawRay(p1,
                _character.transform.TransformDirection(Vector3.back) * 6f, Color.green);
            if (Physics.SphereCast(p1, 1.5f, _character.transform.forward, out hit, 10, _character.whatToChase))
            {
                targetDistance = hit.distance;
            }
            // back
            if (Physics.SphereCast(p1, 1.5f, _character.transform.forward * -1, out hit, 10, _character.whatToChase))
            {
                targetDistance = hit.distance;
            }
            if (targetDistance < 4f)
            {
                Debug.Log($"Player in range {hit.distance}");
                _character.currentTarget = hit.transform;
                var chase = new ChaseState(_character, _character.stateMachine);
                _character.stateMachine.MakeTransition(chase);
            }
        }
    

        public override void EndState()
        {
        }
    }
}