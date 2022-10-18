using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(menuName = "MyScObject/Create ItemDataBase", fileName = "ItemDataBase")]
public class ItemDataBase : ScriptableObject
{

	[SerializeField]
	private List<Item> itemLists = new List<Item>();

	//�@�A�C�e�����X�g��Ԃ�
	public List<Item> GetItemLists()
	{
		return itemLists;
	}
}