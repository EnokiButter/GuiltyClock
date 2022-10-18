using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(menuName = "MyScObject/Create Item", fileName = "Item")]
public class Item : ScriptableObject
{

	public enum KindOfItem
	{
		Weapon,
		UseItem,
		matter,
		spoils
	}

	//�@�A�C�e���̎��
	[SerializeField]
	private KindOfItem kindofitem;
	//�@�A�C�e���̃A�C�R��
	[SerializeField]
	private Sprite icon;
	//�@�A�C�e���̖��O
	[SerializeField]
	private string itemname;
	//�@�A�C�e���̏��
	[SerializeField]
	private string info;

	public KindOfItem GetKindOfItem()
	{
		return kindofitem;
	}

	public Sprite GetIcon()
	{
		return icon;
	}

	public string GetItemName()
	{
		return itemname;
	}

	public string GetInfo()
	{
		return info;
	}
}