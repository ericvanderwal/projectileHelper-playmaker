// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Given a start position, gravity and initial speed, what direction should we fire the projectile to hit a target position?")]
    public class ComputeDirectionToHitTargetWithSpeed : FsmStateAction
    {

	    public FsmVector3 startPosition;
	    public FsmVector3 targetPosition;
	    public FsmFloat gravityNegative;
	    public FsmFloat speed;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmVector3 direction1;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmVector3 direction2;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmBool canReach;
	    
	    public FsmBool everyFrame;
	    
	    private Vector3 _direction1;
	    private Vector3 _direction2;
	    
	    
	    public override void Reset()
	    {
		    
		    startPosition = null;
		    targetPosition = null;
		    direction1 = null;
		    direction2 = null;
		    gravityNegative = null;
		    speed = null;
		    canReach = false;
		    everyFrame = false;

	    }



	    public override void OnEnter()
	    {

		    
		    if (!everyFrame.Value)
		    {
			    doCalculations();
			    Finish();
		    }
		    
		    
	    }
	    
	    
	    public override void OnUpdate()
	    {
		    if (everyFrame.Value)
		    {
			    doCalculations();
		    }
	    }
	    
	   
	    void doCalculations()
	    
	    {
	    	
		    canReach.Value = ProjectileHelper.ComputeDirectionToHitTargetWithSpeed(startPosition.Value, targetPosition.Value, gravityNegative.Value, speed.Value, out _direction1, out _direction2); 
		    direction1.Value = _direction1;
		    direction2.Value = _direction2;

        }

    }
}
