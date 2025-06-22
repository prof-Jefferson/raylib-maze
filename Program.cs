using Raylib_cs;

/// <summary>
/// Classe principal do programa, responsável por inicializar a janela,
/// configurar o jogo e executar o loop principal que desenha o labirinto.
/// </summary>
class Program
{
    // Tamanho de cada célula em pixels
    const int CellSize = 20;

    // Número de colunas e linhas do labirinto
    const int Cols = 30;
    const int Rows = 20;

    /// <summary>
    /// Ponto de entrada do programa.
    /// Inicializa a janela, cria o labirinto e executa o loop de renderização.
    /// </summary>
    static void Main()
    {
        // Inicializa a janela com base nas dimensões do labirinto
        Raylib.InitWindow(Cols * CellSize, Rows * CellSize, "Labirinto Procedural com DFS");
        Raylib.SetTargetFPS(60); // Define taxa de atualização para 60 FPS

        // Cria o labirinto e o gerador de labirinto
        var maze = new Maze(Cols, Rows);
        var generator = new MazeGenerator(maze);

        // Loop principal do jogo
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Gera um passo do labirinto e desenha
            generator.GenerateStepwise();
            maze.Draw(CellSize);

            Raylib.EndDrawing();
        }

        // Encerra a janela ao sair
        Raylib.CloseWindow();
    }
}
