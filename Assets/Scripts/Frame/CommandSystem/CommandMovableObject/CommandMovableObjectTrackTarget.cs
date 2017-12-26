﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class CommandMovableObjectTrackTarget : Command
{
	public MovableObject mObject;
	public TrackDoneCallback mDoneCallback;
	public float mSpeed;
	public override void init()
	{
		base.init();
		mSpeed = 0.0f;
		mDoneCallback = null;
		mObject = null;
	}
	public override void execute()
	{
		MovableObject obj = mReceiver as MovableObject;
		MovableObjectComponentTrackTarget component = obj.getFirstComponent<MovableObjectComponentTrackTarget>();
		if (component != null)
		{
			component.setSpeed(mSpeed);
			component.setActive(true);
			component.setMoveDoneTrack(mObject, mDoneCallback);
		}
	}
	public override string showDebugInfo()
	{
		return this.GetType().ToString() + ": object name : " + mObject.getName() + ", speed value : " + mSpeed;
	}
}