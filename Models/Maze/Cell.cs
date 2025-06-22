using Raylib_cs;
using System;

/// <summary>
/// Representa uma célula individual do labirinto, contendo informações
/// sobre suas paredes e se já foi visitada durante a geração.
/// </summary>
public class Cell
{
    /// <summary>
    /// Coordenada horizontal (coluna) da célula na grade.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Coordenada vertical (linha) da célula na grade.
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Vetor de booleanos representando as paredes da célula.
    /// Índices: 0 = Norte, 1 = Sul, 2 = Leste, 3 = Oeste.
    /// </summary>
    public bool[] Walls = { true, true, true, true };

    /// <summary>
    /// Indica se a célula já foi visitada durante a geração do labirinto.
    /// </summary>
    public bool Visited = false;

    /// <summary>
    /// Cria uma nova célula com coordenadas (x, y) e paredes ativas.
    /// </summary>
    /// <param name="x">Posição horizontal na grade.</param>
    /// <param name="y">Posição vertical na grade.</param>
    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Desenha a célula na tela, incluindo suas paredes e preenchimento se visitada.
    /// </summary>
    /// <param name="size">Tamanho do lado da célula em pixels.</param>
    /// <param name="fillColor">Cor de preenchimento caso a célula tenha sido visitada.</param>
    public void Draw(int size, Color fillColor)
    {
        int px = X * size;
        int py = Y * size;

        // Preenche a célula se já tiver sido visitada
        if (Visited)
            Raylib.DrawRectangle(px, py, size, size, fillColor);

        // Desenha as paredes (linhas pretas)
        if (Walls[0]) Raylib.DrawLine(px, py, px + size, py, Color.Black);                  // Norte
        if (Walls[1]) Raylib.DrawLine(px, py + size, px + size, py + size, Color.Black);    // Sul
        if (Walls[2]) Raylib.DrawLine(px + size, py, px + size, py + size, Color.Black);    // Leste
        if (Walls[3]) Raylib.DrawLine(px, py, px, py + size, Color.Black);                  // Oeste
    }
}