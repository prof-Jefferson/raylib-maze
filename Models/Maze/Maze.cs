using System;
using Raylib_cs;

/// <summary>
/// Representa o labirinto como uma grade de células e armazena as dimensões e a pilha de backtracking.
/// Esta classe é responsável apenas pela estrutura e visualização geral do labirinto.
/// </summary>
public class Maze
{
    /// <summary>
    /// Número total de colunas do labirinto.
    /// </summary>
    public int Cols { get; }

    /// <summary>
    /// Número total de linhas do labirinto.
    /// </summary>
    public int Rows { get; }

    /// <summary>
    /// Matriz 2D contendo todas as células do labirinto.
    /// </summary>
    public Cell[,] Grid { get; }

    /// <summary>
    /// Pilha usada para armazenar o caminho de células visitadas durante a geração do labirinto (algoritmo DFS).
    /// </summary>
    public Stack<Cell> Stack { get; } = new();

    /// <summary>
    /// Inicializa uma nova instância do labirinto com dimensões específicas.
    /// </summary>
    /// <param name="cols">Número de colunas.</param>
    /// <param name="rows">Número de linhas.</param>
    public Maze(int cols, int rows)
    {
        Cols = cols;
        Rows = rows;
        Grid = new Cell[Cols, Rows];

        // Cria e inicializa todas as células da grade
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                Grid[x, y] = new Cell(x, y);
            }
        }
    }

    /// <summary>
    /// Desenha todas as células do labirinto chamando o método Draw de cada célula.
    /// </summary>
    /// <param name="cellSize">Tamanho de cada célula em pixels.</param>
    public void Draw(int cellSize)
    {
        foreach (var cell in Grid)
        {
            cell.Draw(cellSize, Color.SkyBlue); // SKYBLUE indica que a célula foi visitada
        }
    }
}
