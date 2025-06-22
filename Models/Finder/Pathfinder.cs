using System;
using System.Collections.Generic;
using Raylib_cs;

/// <summary>
/// Classe responsável por executar o algoritmo de pathfinding A* (A-Star)
/// sobre um labirinto gerado. Fornece visualização do progresso e caminho encontrado.
/// </summary>
public class Pathfinder
{
    private Maze maze;
    private Cell startCell;
    private Cell endCell;

    private List<Cell> openSet = new();
    private HashSet<Cell> closedSet = new();
    private Dictionary<Cell, Cell> cameFrom = new();

    private Dictionary<Cell, float> gScore = new();
    private Dictionary<Cell, float> fScore = new();

    private bool finished = false;
    private List<Cell> path = new();

    /// <summary>
    /// Inicializa o algoritmo A* com o labirinto e os pontos de início e fim.
    /// </summary>
    /// <param name="maze">Labirinto onde a busca será realizada.</param>
    public Pathfinder(Maze maze)
    {
        this.maze = maze;
        this.startCell = maze.Grid[0, 0];
        this.endCell = maze.Grid[maze.Cols - 1, maze.Rows - 1];

        openSet.Add(startCell);
        gScore[startCell] = 0;
        fScore[startCell] = Heuristic(startCell, endCell);
    }

    /// <summary>
    /// Executa um passo do algoritmo A*, permitindo visualização em tempo real.
    /// </summary>
    public void Step()
    {
        if (finished || openSet.Count == 0) return;

        // Encontra o nó com menor fScore na lista aberta
        Cell current = openSet[0];
        foreach (var cell in openSet)
        {
            if (fScore.TryGetValue(cell, out float score) &&
                fScore.TryGetValue(current, out float currentScore) &&
                score < currentScore)
            {
                current = cell;
            }
        }

        // Se alcançou o destino, reconstrói o caminho
        if (current == endCell)
        {
            finished = true;
            ReconstructPath(current);
            return;
        }

        openSet.Remove(current);
        closedSet.Add(current);

        foreach (var neighbor in GetNeighbors(current))
        {
            if (closedSet.Contains(neighbor)) continue;

            float tentativeG = gScore.ContainsKey(current) ? gScore[current] + 1 : float.MaxValue;

            if (!openSet.Contains(neighbor))
                openSet.Add(neighbor);
            else if (tentativeG >= gScore.GetValueOrDefault(neighbor, float.MaxValue))
                continue;

            cameFrom[neighbor] = current;
            gScore[neighbor] = tentativeG;
            fScore[neighbor] = tentativeG + Heuristic(neighbor, endCell);
        }
    }

    /// <summary>
    /// Retorna os vizinhos válidos conectados pela ausência de parede.
    /// </summary>
    private List<Cell> GetNeighbors(Cell cell)
    {
        var neighbors = new List<Cell>();
        int x = cell.X;
        int y = cell.Y;

        // Cima
        if (!cell.Walls[0] && y > 0) neighbors.Add(maze.Grid[x, y - 1]);
        // Baixo
        if (!cell.Walls[1] && y < maze.Rows - 1) neighbors.Add(maze.Grid[x, y + 1]);
        // Direita
        if (!cell.Walls[2] && x < maze.Cols - 1) neighbors.Add(maze.Grid[x + 1, y]);
        // Esquerda
        if (!cell.Walls[3] && x > 0) neighbors.Add(maze.Grid[x - 1, y]);

        return neighbors;
    }

    /// <summary>
    /// Estima a distância de uma célula até a meta (distância Manhattan).
    /// </summary>
    private float Heuristic(Cell a, Cell b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    /// <summary>
    /// Reconstrói o caminho final percorrido com base nos nós visitados.
    /// </summary>
    private void ReconstructPath(Cell current)
    {
        path.Clear();
        while (cameFrom.ContainsKey(current))
        {
            path.Add(current);
            current = cameFrom[current];
        }
        path.Add(startCell);
        path.Reverse();
    }

    /// <summary>
    /// Desenha a visualização do algoritmo (abertos, fechados e caminho).
    /// </summary>
    public void Draw(int cellSize)
    {
        foreach (var cell in closedSet)
            Raylib.DrawRectangle(cell.X * cellSize, cell.Y * cellSize, cellSize, cellSize, Color.Red);

        foreach (var cell in openSet)
            Raylib.DrawRectangle(cell.X * cellSize, cell.Y * cellSize, cellSize, cellSize, Color.Green);

        foreach (var cell in path)
            Raylib.DrawRectangle(cell.X * cellSize, cell.Y * cellSize, cellSize, cellSize, Color.Gold);
    }

    /// <summary>
    /// Informa se o algoritmo terminou a busca.
    /// </summary>
    public bool IsFinished() => finished;
}
