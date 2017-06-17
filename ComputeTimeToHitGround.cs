// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Given a start position, initial velocity (with direction) and gravity, how much time is needed to reach the ground (at a specified height level).")]
    public class ComputeTimeToHitGround : FsmStateAction
    {

	    public FsmVector3 startPosition;
	    public FsmVector3 velocity;
	    public FsmFloat groundLevel;
	    public FsmFloat gravityNegative;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmFloat timeToHit;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmBool returnHit;
	    
	    public FsmBool everyFrame;
	    
	    private float _timeToHit;
	    
	    public override void Reset()
	    {
		    
		    startPosition = null;
		    velocity = null;
		    groundLevel = null;
		    gravityNegative = null;
		    timeToHit = null;
		    returnHit = false;
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
		    returnHit.Value = ProjectileHelper.ComputeTimeToHitGround(startPosition.Value, velocity.Value, groundLevel.Value, gravityNegative.Value, out _timeToHit);
		    timeToHit.Value = _timeToHit;
		    
        }

    }
}
