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

	//　アイテムの種類
	[SerializeField]
	private KindOfItem kindofitem;
	//　アイテムのアイコン
	[SerializeField]
	private Sprite icon;
	//　アイテムの名前
	[SerializeField]
	private string itemname;
	//　アイテムの情報
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