using System;
using Unity.VisualScripting;
using UnityEngine;

namespace GenericStateSystem.ActionStates
{
    public class PatrolState : GenericState
    {
        private GameObject[] _patrolPoints;
        private Quaternion _lookRotation;
        private float _rotationSpeed = 5f;
        GameObject closestPoint = null;
        private int patrolIndex = 0;

        public PatrolState(BaseCharacter _c, GenericStateMachine _s) : base(_c, _s)
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
            float closest = Single.MaxValue;
            closestPoint = _patrolPoints[patrolIndex % _patrolPoints.Length];


            if (closestPoint != null)
            {
                Debug.Log($"Goto at patrol point {closestPoint.name}");
                patrolIndex++;
            }
        }

        public override void UpdateState()
        {
            if (closestPoint != null)
            {
                // go here
                //find the vector pointing from our position to the target
                Vector3 _direction = (closestPoint.transform.position - _character.transform.position).normalized;

                //create the rotation we need to be in to look at the target
                //_character.transform.rotation = Quaternion.LookRotation(_direction);
                _lookRotation = Quaternion.LookRotation(_direction);
                var eulerY = _lookRotation.eulerAngles.y;
                var euler = new Vector3(0, eulerY, 0);
                _character.transform.rotation = Quaternion.Slerp(_character.transform.rotation, Quaternion.Euler(euler),
                    Time.deltaTime * _rotationSpeed);
                _character.anim.SetFloat("Speed", 0.6f);
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
        
            RaycastHit hit;
            Debug.DrawRay(p1,
                _character.transform.TransformDirection(Vector3.forward) * 6f, Color.red);
            if (Physics.SphereCast(p1, 1.5f, _character.transform.forward, out hit, 10, _character.whatToChase))
            {
                
                if (hit.distance < 4f)
                {
                    Debug.Log($"Player in range {hit.distance}");
                    var chase = new ChaseState(_character, _character.stateMachine);
                    _character.stateMachine.MakeTransition(chase);
                }
            }

        }
    

        public override void EndState()
        {
        }
    }
}