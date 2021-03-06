﻿using UnityEngine;
using System.Collections;

public class CommandCharacterNotifyReady : Command
{
	public bool mReady;
	public override void init()
	{
		base.init();
		mReady = false;
	}
	public override void execute()
	{
		Character character = (mReceiver) as Character;
		CharacterData data = character.getCharacterData();
		if(data.mReady == mReady)
		{
			return;
		}
		data.mReady = mReady;
		// 通知布局
		mScriptAllCharacterInfo.notifyCharacterReady(character, mReady);
		// 如果是自己的准备状态改变
		if(character.getType() == CHARACTER_TYPE.CT_MYSELF)
		{
			mScriptMahjongFrame.notifyReady(mReady);
		}
	}
}