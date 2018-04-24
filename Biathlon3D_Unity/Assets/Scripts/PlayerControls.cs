using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	private GameObject player; //Переменная объекта персонажа с которым будем работать. 

	public static int speed = 6; //Скорость перемещения персонажа. Запись public static обозначает что мы сможем обращаться к этой переменной из любого скрипта 
	public static int _speed; //постоянная скорость перемещения персонажа 
	public int rotation = 250; //Скорость пповорота персонажа 
	public static float x = 0.0f; //угол поворота персонажа по оси x 
	private Animator animator;

	// Use this for initialization
	void Start () {
		_speed = speed; //Задаем постоянное стандартное значение скорости персонажа 
		player = (GameObject)this.gameObject; //Задаем что наш персонаж это объект на котором расположен скрипт
		animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)) //Если нажать W 
		{
			player.transform.position += player.transform.forward * speed * Time.deltaTime; //Перемещаем персонажа в перед, с заданой скорость. Time.deltaTime ставится для плавного перемещения персонажа, если этого не будет он будет двигаться рывками 
		} 
		if(Input.GetKey(KeyCode.S)) 
		{ 
			player.transform.position -= player.transform.forward * speed * Time.deltaTime; //Перемещаем назад 
		}
		if(Input.GetKey (KeyCode.A)) 
		{ 
			player.transform.position -= player.transform.right * speed * Time.deltaTime; //перемещаем в лево 
		}
		if(Input.GetKey (KeyCode.D)) 
		{ 
			player.transform.position += player.transform.right * speed * Time.deltaTime; //перемещаем в право 
		}
	}
}
