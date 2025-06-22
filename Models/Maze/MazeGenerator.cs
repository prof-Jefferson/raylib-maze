using System;
using System.Collections.Generic;

/// <summary>
/// Responsável por gerar o labirinto usando o algoritmo de backtracking com busca em profundidade (DFS).
/// Controla o progresso passo a passo da geração e manipula as paredes das células.
/// </summary>
public class MazeGenerator
{
    /// <summary>
    /// Referência ao labirinto que será gerado.
    /// </summary>
    private Maze maze;

    /// <summary>
    /// Gerador de números aleatórios para escolha de direções e vizinhos.
    /// </summary>
    private Random rand = new();

    /// <summary>
    /// Inicializa o gerador com um labirinto específico.
    /// </summary>
    /// <param name="maze">Instância do labirinto a ser gerada.</param>
    public MazeGenerator(Maze maze)
    {
        this.maze = maze;
    }

    /// <summary>
    /// Executa um único passo da geração do labirinto.
    /// Pode ser chamado a cada frame para animar a criação em tempo real.
    /// </summary>
    public void GenerateStepwise()
    {
        // Início da geração
        if (maze.Stack.Count == 0)
        {
            maze.Grid[0, 0].Visited = true;
            maze.Stack.Push(maze.Grid[0, 0]);
            return;
        }

        // Obtém a célula atual no topo da pilha
        var current = maze.Stack.Peek();

        // Tenta encontrar um vizinho ainda não visitado
        var neighbor = GetUnvisitedNeighbor(current);

        if (neighbor != null)
        {
            neighbor.Visited = true;
            RemoveWalls(current, neighbor);
            maze.Stack.Push(neighbor);
        }
        else
        {
            // Volta no caminho se não houver vizinhos disponíveis
            maze.Stack.Pop();
        }
    }

    /// <summary>
    /// Retorna um vizinho não visitado da célula atual, ou null se não houver.
    /// </summary>
    /// <param name="cell">Célula de referência.</param>
    /// <returns>Vizinho não visitado ou null.</returns>
    private Cell? GetUnvisitedNeighbor(Cell cell)
    {
        var neighbors = new List<Cell>();

        // Direções: cima, baixo, direita, esquerda
        (int dx, int dy)[] directions = { (0, -1), (0, 1), (1, 0), (-1, 0) };

        foreach (var (dx, dy) in directions)
        {
            int nx = cell.X + dx;
            int ny = cell.Y + dy;

            if (nx >= 0 && ny >= 0 && nx < maze.Cols && ny < maze.Rows)
            {
                var neighbor = maze.Grid[nx, ny];
                if (!neighbor.Visited)
                {
                    neighbors.Add(neighbor);
                }
            }
        }

        if (neighbors.Count == 0)
            return null;

        return neighbors[rand.Next(neighbors.Count)];
    }

    /// <summary>
    /// Remove as paredes entre duas células adjacentes.
    /// </summary>
    /// <param name="a">Célula atual.</param>
    /// <param name="b">Célula vizinha.</param>
    private void RemoveWalls(Cell a, Cell b)
    {
        int dx = b.X - a.X;
        int dy = b.Y - a.Y;

        if (dx == 1) { a.Walls[2] = false; b.Walls[3] = false; } // Leste
        if (dx == -1) { a.Walls[3] = false; b.Walls[2] = false; } // Oeste
        if (dy == 1) { a.Walls[1] = false; b.Walls[0] = false; } // Sul
        if (dy == -1) { a.Walls[0] = false; b.Walls[1] = false; } // Norte
    }
}
