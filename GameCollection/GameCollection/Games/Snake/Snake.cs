namespace GameCollection.Games.Snake;

public class Snake
{
    private int width;
    private int height;
    private SnakeTile[,] map;
    private SnakeDirection? direction;
    private Queue<(int X, int Y)> snake;
    private bool closeRequested;
    
    public Snake(int width, int height)
    {
        this.width = width;
        this.height = height;
        map = new SnakeTile[width, height];
        snake = new Queue<(int X, int Y)>();
        closeRequested = false;
    }

    public void PositionSnake()
    {
        snake.Enqueue((width / 2, height / 2));
        map[width / 2, height / 2] = SnakeTile.Snake;
    }

    public (int, int) PositionFood()
    {
        List<(int X, int Y)> possibleCoordinates = new List<(int X, int Y)>();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (map[i, j] == SnakeTile.Open)
                {
                    possibleCoordinates.Add((i, j));
                }
            }
        }
        int index = new Random().Next(possibleCoordinates.Count);
        (int X, int Y) = possibleCoordinates[index];
        map[X, Y] = SnakeTile.Food;
        return (X, Y);
    }

    public bool CheckWindowResize()
    {
        if (Console.WindowWidth != width || Console.WindowHeight != height)
        {
            return true;
        }

        return false;
    }

    public bool CheckCollision(int X, int Y)
    {
        /*if (map[X, Y] == SnakeTile.Snake)
        {
            Console.Clear();
            new SnakeView().GameOver(snake.Count - 1);
            return true;
        }*/

        if (X < 0 || X >= width || Y < 0 || Y >= height)
        {
            return true;
        }

        return false;
    }

    public void RenderSnakeMovement(int X, int Y)
    {
        if (CheckCollision(X, Y))
        {
            return;
        }

        snake.Enqueue((X, Y));

        if (map[X, Y] == SnakeTile.Food)
        {
            (int foodX, int foodY) = PositionFood();
            map[foodX, foodY] = SnakeTile.Food;
            new SnakeView().RenderFood(foodX, foodY);
        }
        else
        {
            (int x, int y) = snake.Dequeue();
            map[x, y] = SnakeTile.Open;
            new SnakeView().ClearCell(x, y);
        }

        map[X, Y] = SnakeTile.Snake;
    }

    public bool GameOver()
    {
        return closeRequested;
    }

    public int GetHeight()
    {
        return height;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetX()
    {
        int X = snake.Peek().X;
        return X;
    }
    
    public int GetY()
    {
        int Y = snake.Peek().Y;
        return Y;
    }

    public int GetSnakeLength()
    {
        return snake.Count - 1;
    }
}
