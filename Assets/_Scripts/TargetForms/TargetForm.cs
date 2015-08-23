using UnityEngine;
using System.Collections;

public class TargetForm : MonoBehaviour {

	public float speed = 500;

	private Vector3 startPos;
	private PlayerController target;
	private float timer = 0;
	private float wobbleTimer = 0;
	public float positionRange;
	public float scalerRange;

    private bool isInRange = false;
    private bool isCorrect = false;

    private float baseScaleX = 0;
    private float baseScaleY = 0;

    void Start(){
		target = (PlayerController)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController");
		startPos = transform.position;

		positionRange = 0.2f;
		scalerRange = 5.0f;
	}

	void Update(){
		Vector2 dir = new Vector2 (target.transform.position.x - transform.position.x,target.transform.position.y - transform.position.y);
		float realSpeed = (((transform.position.magnitude / startPos.magnitude) +  0.35f) * speed) * Time.deltaTime;
		dir.Normalize ();
		//transform.position = new Vector3(transform.position.x + dir.x * realSpeed,transform.position.y + dir.y * realSpeed, 0.015f);
		transform.position = new Vector3(transform.position.x + dir.x * 10* Time.deltaTime ,transform.position.y + dir.y * 10* Time.deltaTime, 0.015f);

		if (InRange()) {
			OnPosition();
		}
	}

	private bool InRange()
	{
		Vector3 minRange = new Vector3 (target.transform.position.x - positionRange, target.transform.position.y - positionRange, 0);
		Vector3 maxRange = new Vector3 (target.transform.position.x + positionRange, target.transform.position.y + positionRange, 0);
		if (this.transform.position.x > minRange.x && this.transform.position.y > minRange.y && 
		    this.transform.position.x < maxRange.x && this.transform.position.y < maxRange.y) {
				return true;
		}
		return false;
	}

	private void OnPosition()
	{
		if (!isInRange)
		{
            isInRange = true;
            transform.position = target.transform.position;
            baseScaleX = transform.localScale.x;
            baseScaleY = transform.localScale.y;
        }
		else
		{
			//check shape constantly until true
			CheckShape();
        }
		
		if (isCorrect)
		{
			wobbleTimer += Time.deltaTime;
			float _wobble = 1 - Mathf.Sin(Time.time * (wobbleTimer * 3f)) * 0.2f;
			
			transform.localScale = new Vector3(_wobble * baseScaleX, _wobble * baseScaleY, 1f);
		}
        
        
    }
	
	public void CheckShape()
	{
		timer += Time.deltaTime;
		if (timer >= 3f)
        {
			if(InScaleRange())
			{

            }
			else
			{
                print("loss");
            }

			Destroy(this.gameObject);
        }
		if (InScaleRange()) {
			target.GetComponent<PlayerController>().UpdateFaceTexture("blij1");
            isCorrect = true;
            print("yeahhh");
			Destroy(this.gameObject,0.4f);

            // scorepoint()
        } 
		else if (!isCorrect){
			target.GetComponent<PlayerController>().UpdateFaceTexture("sad1");
			//badstuff
		}
		//Destroy(this.gameObject);
	}
	
	private bool InScaleRange()
	{
		Vector3 minScaleRange = new Vector3 (baseScaleX - scalerRange, baseScaleY - scalerRange, 1);
		Vector3 maxScaleRange = new Vector3 (baseScaleX + scalerRange, baseScaleY + scalerRange, 1);

		print (minScaleRange + " maxscale" + maxScaleRange);
        GameObject _playerBody = target.GetComponent<PlayerController>().PlayerBody;
        if (_playerBody.transform.localScale.x > minScaleRange.x && _playerBody.transform.localScale.x < maxScaleRange.x &&
			_playerBody.transform.localScale.y > minScaleRange.y && _playerBody.transform.localScale.y < maxScaleRange.y) {
			return true;
		}
		return false;
	}
}
