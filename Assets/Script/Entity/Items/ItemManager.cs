//参考サイト https://gametukurikata.com/program/scriptableobjectitemdatabase
//参考サイト https://www.ame-name.com/archives/6619

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

	//　アイテムデータベース
	[SerializeField]
	private ItemDataBase itemDataBase;
	//　アイテム数管理
	private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();

	// Use this for initialization
	void Start()
	{

		for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
		{
			//　アイテム数を適当に設定
			numOfItem.Add(itemDataBase.GetItemLists()[i], i);
			//　確認の為データ出力
			Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ": " + itemDataBase.GetItemLists()[i].GetInfo());
		}

		Debug.Log(GetItem("item01").GetInfo());
		Debug.Log(numOfItem[GetItem("item03")]);
	}

	//　名前でアイテムを取得
	public Item GetItem(string searchName)
	{
		return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}
}
