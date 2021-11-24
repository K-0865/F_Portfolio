using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class DataTable_pre : ScriptableObject
{
	public List<CharacterTable> Character; // Replace 'EntityType' to an actual type that is serializable.
}
