using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    private Vector2 _destination;
    [SerializeField] private float _moveSpeed = 10;

    private List<Vector2> _points = new List<Vector2>();
    private int _indexOfPoint = 0;

    private bool _shouldMove = false;
    private bool _isReachedPoint;
    void Start()
    {
        _points.Add(transform.position);
    }

   
    void Update()
    {
        if (_shouldMove)
        {
            transform.DOMove((Vector3)_points[_indexOfPoint], _moveSpeed).SetEase(Ease.Linear);
               // OnComplete(() => transform.DOMove((Vector3)_points[_indexOfPoint], _moveSpeed));
            
            _shouldMove = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Добавили в массив точку
            _points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            _indexOfPoint++;

            //_destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Vector2.Distance(transform.position, _points[_indexOfPoint]) <= .5f)
        {
            _shouldMove = false;
        }

        if (Vector2.Distance(transform.position, _points[_indexOfPoint]) > 1f)
        {
            _shouldMove = true;
        }
        
    }

    private void IsReachedPoint()
    {
        _isReachedPoint = true;
    }
}
