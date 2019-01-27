using System;
using System.Runtime.Remoting.Messaging;
using UnityEngine;


public class DynamicObject : MonoBehaviour
{
	// Whether the object can be dragged around and picked up
	public bool draggable = false;
	public AudioSource audioSource;
	public AudioClip inspectionAudio;
	
	// Sprite rendering stuff
	private SpriteRenderer _renderer;
	// The item that is in the front has the highest sorting order so we need to keep track
	public static int maxSortingOrder = 2;
	
	// Mouse stuff for dragging
	private bool _mouseDown = false;
	private Vector3 _startMousePos;
	private Vector3 _startPos;
	public Vector3 StartPos
	{
		get { return _startPos; }
	}

	// For dragging the object to other objects or into the inventory
	private bool isOverlapping = false;
	private GameObject overlappingObject = null;
	private bool overlapsInventory = false;
	private bool isInInventory = false;
	public bool IsInInventory
	{
		get { return isInInventory; }
	}

	private static Inventory _inventory;
	
	// Handlers for various actions with this object
	private ActionHandler _actionHandler;
	private CombineHandler _combineHandler;
	private DragHandler _dragHandler;
	private TakeToInventoryHandler _takeHandler;
	private bool _haveActionHandler = false;
	private bool _haveCombineHandler = false;
	private bool _haveDragHandler = false;
	private bool _haveTakeHandler = false;
	

	void Start ()
	{
		// Find handlers if designer added any scripts to the object
		_actionHandler = GetComponent<ActionHandler>();
		if (_actionHandler != null)
		{
			_haveActionHandler = true;
		}
		
		_combineHandler = GetComponent<CombineHandler>();
		if (_combineHandler != null)
		{
			_haveCombineHandler = true;
		}
		
		_dragHandler = GetComponent<DragHandler>();
		if (_dragHandler != null)
		{
			_haveDragHandler = true;
		}
		
		_takeHandler = GetComponent<TakeToInventoryHandler>();
		if (_takeHandler != null)
		{
			_haveTakeHandler = true;
		}

		_renderer = GetComponent<SpriteRenderer>();
		_inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_mouseDown && draggable && !_inventory.IsOpen)
		{
			var currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var diff = currentPos - _startMousePos;
			var pos = _startPos + diff;
			transform.position = pos;
			if (_haveDragHandler) _dragHandler.HandleDrag();
			GameMasterScript.instance.CurrentHeldItem = this;
		}
	}

	public void SpawnDragging()
	{
		_mouseDown = true;
		_renderer = GetComponent<SpriteRenderer>();
		if (_renderer != null)
		{
			_renderer.sortingOrder = ++maxSortingOrder;
		}
	}

	private void OnMouseDown()
	{
		if (_inventory != null && _inventory.IsOpen) return;
		
		if (Input.GetMouseButtonDown(0))
		{
			_mouseDown = true;
			_startPos = transform.position;
			_startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (draggable && _renderer != null) _renderer.sortingOrder = ++maxSortingOrder;
		}
	}
	
	private void OnMouseOver () {
		if (_inventory != null && _inventory.IsOpen) return;
		
		if (Input.GetMouseButtonDown(1))
		{
			audioSource.clip = inspectionAudio;
			audioSource.Play();
		}
	}

	public void OnMouseUp()
	{
		if (_inventory != null && _inventory.IsOpen) return;
		_mouseDown = false;
		
		if (_startPos == transform.position)
		{
			if (_haveActionHandler) _actionHandler.HandleAction();
		}
		
	}

	public void Release()
	{
		if (_inventory != null && _inventory.IsOpen) return;
		
		_mouseDown = false;
		if (!(_startPos == transform.position)) {
			if (isOverlapping)
			{
				if (_haveCombineHandler) _combineHandler.HandleCombination(overlappingObject);
			}
			if (overlapsInventory)
			{
				PutIntoInventory();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (_inventory != null && _inventory.IsOpen) return;
		
		print(other.name);
		if (other.name == "InventoryIcon")
		{
			overlapsInventory = true;
		}
		else
		{
			isOverlapping = true;
			overlappingObject = other.gameObject;
			print(overlappingObject.name);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (_inventory.IsOpen) return;
		
		if (other.name == "InventoryIcon")
		{
			overlapsInventory = false;
		}
		else
		{
			print(other.name);
			isOverlapping = false;
			overlappingObject = null;
		}
	}


	private void PutIntoInventory()
	{
		if (_haveTakeHandler)
		{
			_takeHandler.HandleTake();
		}
		_inventory.PutItem(gameObject);
		
		gameObject.SetActive(false);
	}
}
