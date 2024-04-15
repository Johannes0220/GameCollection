using System;
using System.Collections.Generic;

namespace GameCollection.Games._2048;

public class Game2048
{
    private int?[,] board;
    private int score;

    public Game2048()
    {
        board = new int?[4, 4];
        score = 0;
    }

    public int?[,] GetBoard() => board;

    public int GetScore() => score;

    public bool IsGameOver()
    {
        return !TryUpdate((int?[,])board.Clone(), ref score, Game2048Direction.Up) &&
               !TryUpdate((int?[,])board.Clone(), ref score, Game2048Direction.Down) &&
               !TryUpdate((int?[,])board.Clone(), ref score, Game2048Direction.Left) &&
               !TryUpdate((int?[,])board.Clone(), ref score, Game2048Direction.Right);
    }

    public bool TryMove(Game2048Direction direction)
    {
        return (TryUpdate(board, ref score, direction));
    }

    public void GenerateNewTile()
    {
        var emptyTiles = GetEmptyTiles();
        if (emptyTiles.Count > 0)
        {
            var randomIndex = new Random().Next(emptyTiles.Count);
            var (x, y) = emptyTiles[randomIndex];
            board[x, y] = new Random().Next(10) < 9 ? 2 : 4;
        }
    }

    private List<(int, int)> GetEmptyTiles()
    {
        var emptyTiles = new List<(int, int)>();
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == null)
                {
                    emptyTiles.Add((i, j));
                }
            }
        }
        return emptyTiles;
    }

    private bool TryUpdate(int?[,] board, ref int score, Game2048Direction direction)
    {
        bool update = false;
        bool[,] locked = new bool[board.GetLength(0), board.GetLength(1)];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                var (tempi, tempj) = Map(i, j, direction);

                if (board[tempi, tempj] is null)
                    continue;

                int adji = tempi, adjj = tempj;

                while (true)
                {
                    var (nexti, nextj) = Adjacent(adji, adjj, direction);

                    if (nexti < 0 || nexti >= board.GetLength(0) ||
                        nextj < 0 || nextj >= board.GetLength(1))
                        break;

                    if (board[nexti, nextj] is null)
                    {
                        board[nexti, nextj] = board[adji, adjj];
                        board[adji, adjj] = null;
                        adji = nexti;
                        adjj = nextj;
                        update = true;
                    }
                    else if (board[nexti, nextj] == board[adji, adjj] && !locked[nexti, nextj])
                    {
                        board[nexti, nextj] += board[adji, adjj];
                        score += board[nexti, nextj]!.Value;
                        board[adji, adjj] = null;
                        locked[nexti, nextj] = true;
                        update = true;
                        break;
                    }
                    else
                        break;
                }
            }
        }
        return update;
    }

    private (int, int) Adjacent(int x, int y, Game2048Direction direction)
    {
        return direction switch
        {
            Game2048Direction.Up => (x + 1, y),
            Game2048Direction.Down => (x - 1, y),
            Game2048Direction.Left => (x, y - 1),
            Game2048Direction.Right => (x, y + 1),
            _ => throw new NotImplementedException(),
        };
    }

    private (int, int) Map(int x, int y, Game2048Direction direction)
    {
        return direction switch
        {
            Game2048Direction.Up => (board.GetLength(0) - x - 1, y),
            Game2048Direction.Down => (x, y),
            Game2048Direction.Left => (x, y),
            Game2048Direction.Right => (x, board.GetLength(1) - y - 1),
            _ => throw new NotImplementedException(),
        };
    }
}
