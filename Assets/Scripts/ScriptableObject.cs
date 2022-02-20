using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
///	プレイヤー　データ
/// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
[CreateAssetMenu(menuName = "MyScriptable/CreatePlayerData")]
public class PlayerData : ScriptableObject
{
	public float speed;
	public float slideSpeed;
	public float sideLimLeft;
	public float sideLimRight;
}

///+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
///	車　データ
/// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
[CreateAssetMenu(menuName = "MyScriptable/CreateCarData")]
public class CarData : ScriptableObject
{
	[Tooltip("車がキルできる人の数")]
	public int killNum = 5;
}