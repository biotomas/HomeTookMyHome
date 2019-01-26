using UnityEngine;


public class DynamicObject : MonoBehaviour
{
	public static int maxSortingOrder = 2;
	
	private bool _mouseDown = false;
	private Vector3 _startMousePos;
	private Vector3 _startPos;
	public Vector3 StartPos
	{
		get { return _startPos; }
	}


	private bool isOverlapping = false;
	private GameObject overlappingObject = null;
	private bool overlapsInventory = false;

	private bool isInInventory = false;

	public bool IsInInventory
	{
		get { return isInInventory; }
	}

	private ObjectHandler _handler;

	public bool draggable = false;
	
	// Use this for initialization
	void Start ()
	{
		_handler = GetComponent<ObjectHandler>();
		if (_handler == null)
		{
			_handler = gameObject.AddComponent<GenericObjectHandler>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_mouseDown && draggable)
		{
			var currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var diff = currentPos - _startMousePos;
			var pos = _startPos + diff;
			transform.position = pos;
			GetComponent<SpriteRenderer>().sortingOrder = ++maxSortingOrder;
			_handler.HandleDrag();
		}
	}

	private void OnMouseDown()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_mouseDown = true;
			_startPos = transform.position;
			_startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
	
	private void OnMouseOver () {
		if (Input.GetMouseButtonDown(1)) {
			_handler.HandleInvestigate();
		}
	}

	public void OnMouseUp()
	{
		_mouseDown = false;
		if (_startPos == transform.position)
		{
			// clicked = true;
			_handler.HandleAction();
		} else {
			if (isOverlapping)
			{
				_handler.HandleTrigger(overlappingObject);
			}
			if (overlapsInventory)
			{
				print("object is now in inventory");
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Inventory")
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
		if (other.name == "Inventory")
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
}
