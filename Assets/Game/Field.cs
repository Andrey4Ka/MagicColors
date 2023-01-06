using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Field : MonoBehaviour
{
    public event Action OnWin;

    [SerializeField] private Image _gradient;
    [SerializeField] private RectTransform _cellsParent;
    [SerializeField] private Camera _camera;

    [Space]
    [SerializeField] private Cell _cellPrefab;

    private IndexPosition _size;
    private Cell[,] _cellsMatrix;
    private Color[,] _trueColors;
    private Vector2 _cellSize;

    private List<Cell> _activeCells = new List<Cell>();

    public IEnumerator InitField(Level level)
    {
        _size = new IndexPosition(level.Interactables.GridSize.x, level.Interactables.GridSize.y);
        _cellSize = _cellsParent.rect.size / new Vector2(_size.X, _size.Y);
        _gradient.sprite = level.Gradient;
        _trueColors = new Color[_size.X, _size.Y];
        _cellsMatrix = new Cell[_size.X, _size.Y];
        for (int i = 0; i < _size.X; i++)
        {
            for (int j = 0; j < _size.Y; j++)
            {
                var cell = Instantiate(_cellPrefab, _cellsParent);
                cell.SetSize(_cellSize);
                cell.DragAndDrop.OnDrop += () => PutCell(cell);
                cell.DragAndDrop.OnBeginDrag += ResetActiveCells;
                var index = new IndexPosition(i, j);
                cell.transform.position = GetPosition(index);
                cell.IndexPosition = index;
                _cellsMatrix[i, j] = cell;
                cell.TakeColor(level.Gradient);
                _trueColors[i, j] = cell.Color;
                cell.Interactable = level.Interactables.GetCell(i, j);
            }
        }

        yield return null;
        ShuffleCells();
    }

    public void ToggleErrorHint(bool active)
    {
        foreach (var cell in _cellsMatrix)
        {
            if (!cell.Interactable)
            {
                continue;
            }

            cell.ToogleError(active && !CheckTrue(cell));
        }
    }

    private void ShuffleCells()
    {
        var interactabelsCells = new List<Cell>();
        foreach (var cell in _cellsMatrix)
        {
            if (cell.Interactable)
            {
                interactabelsCells.Add(TakeFromMatrix(cell.IndexPosition));
            }
        }

        var count = interactabelsCells.Count;
        while (count > 1)
        {
            int i = Random.Range(0, count);
            count--;
            (interactabelsCells[count], interactabelsCells[i]) = (interactabelsCells[i], interactabelsCells[count]);
        }

        var numerator = interactabelsCells.GetEnumerator();
        for (int i = 0; i < _size.X; i++)
        {
            for (int j = 0; j < _size.Y; j++)
            {
                if (_cellsMatrix[i, j] == null)
                {
                    numerator.MoveNext();
                    _cellsMatrix[i, j] = numerator.Current;
                    SetCellInIndex(_cellsMatrix[i, j], new IndexPosition(i, j));
                }
            }
        }
    }

    private void PutCell(Cell cell)
    {
        _activeCells.Add(cell);
        var index = GetIndex(cell.Position);
        if (!AvailableIndex(index))
        {
            cell.GoTo(GetPosition(cell.IndexPosition));
            return;
        }

        var dest = TakeFromMatrix(index);
        if (dest && !dest.Interactable)
        {
            SetCellInIndex(dest, dest.IndexPosition);
            cell.GoTo(GetPosition(cell.IndexPosition));
            return;
        }

        TakeFromMatrix(cell.IndexPosition);
        if (dest)
        {
            SetCellInIndex(dest, cell.IndexPosition);
            dest.SetLayer(CellLayer.Dest);
            _activeCells.Add(dest);
        }

        SetCellInIndex(cell, index);
        CheckWin();
    }

    private void SetCellInIndex(Cell cell, IndexPosition index)
    {
        cell.GoTo(GetPosition(index));
        cell.IndexPosition = index;
        _cellsMatrix[cell.IndexPosition.X, cell.IndexPosition.Y] = cell;
        Debug.Log($"{cell.IndexPosition.X} - {cell.IndexPosition.Y}");
    }

    private Cell TakeFromMatrix(IndexPosition index)
    {
        var cell = _cellsMatrix[index.X, index.Y];
        _cellsMatrix[index.X, index.Y] = null;
        return cell;
    }

    private IndexPosition GetIndex(Vector2 position)
    {
        position -= _cellSize / 2;
        return new IndexPosition(Mathf.RoundToInt(position.x / _cellSize.x), Mathf.RoundToInt(position.y / _cellSize.x));
    }

    private Vector2 GetPosition(IndexPosition index)
    {
        var anchoredPos = new Vector2(_cellSize.x * index.X, _cellSize.y * index.Y);
        anchoredPos += _cellSize / 2;
        var pos = (Vector2)_cellsParent.TransformPoint(anchoredPos);
        return pos;
    }

    private bool AvailableIndex(IndexPosition index)
    {
        return index.X >= 0 &&
            index.Y >= 0 &&
            index.X < _size.X &&
            index.Y < _size.Y;
    }

    private void ResetActiveCells()
    {
        foreach (var cell in _activeCells)
        {
            cell.SetLayer(CellLayer.Default);
        }
        _activeCells.Clear();
    }

    private void CheckWin()
    {
        foreach (var cell in _cellsMatrix)
        {
            if (!CheckTrue(cell))
            {
                return;
            }
        }

        OnWin?.Invoke();
    }

    private bool CheckTrue(Cell cell)
    {
        return cell.Color == _trueColors[cell.IndexPosition.X, cell.IndexPosition.Y];
    }
}