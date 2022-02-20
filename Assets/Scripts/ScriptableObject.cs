using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
///	�v���C���[�@�f�[�^
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
///	�ԁ@�f�[�^
/// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
[CreateAssetMenu(menuName = "MyScriptable/CreateCarData")]
public class CarData : ScriptableObject
{
	[Tooltip("�Ԃ��L���ł���l�̐�")]
	public int killNum = 5;
}