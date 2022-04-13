using System.Text.Json;
using System.Net.Http;

namespace jogoVelha_api_
{
    public partial class Form1 : Form
    {
        const string baseURL = "http://localhost:9000/";
        string moveURL = "";
        string[][]? currentBoard;
        int moveLine = 0;
        int moveColumn = 0;
        int aux = 0;

        public Form1()
        {
            InitializeComponent();
            reloadInit();
        }

        private void setGame(string[][] board)
        {
            try
            {
                ps00.Text = board[0][0];
                ps01.Text = board[0][1];
                ps02.Text = board[0][2];

                ps10.Text = board[1][0];
                ps11.Text = board[1][1];
                ps12.Text = board[1][2];

                ps20.Text = board[2][0];
                ps21.Text = board[2][1];
                ps22.Text = board[2][2];

                currentBoard = board;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void reloadInit()
        {
            try
            {
                var connection = (new HttpClient()).GetAsync(baseURL + "api/jogo");
                var stringBoard = connection.Result.Content.ReadAsStringAsync().Result;
                string[][] board = JsonSerializer.Deserialize<string[][]>(stringBoard)!;
                setGame(board);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private int[]? analysisHorizont()
        {
            int cont = 0;
            int position = -1;

            for(int i =0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if (cont == 2 && position != -1)
                    {
                        return new int[2] { i, position };
                    }

                    if (currentBoard![i][j] != "")
                    {
                        if (currentBoard![i][j] != option.Text)
                        {
                            cont++;
                        }
                    }
                    else
                    {
                        position = j;
                    }
                    
                }
                cont = 0;
                position = -1;
            }
            return null;
        }

        private int[]? analysisVertic()
        {
            int cont = 0;
            int position = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cont == 2 && position != -1)
                    {
                        return new int[2] {j,position};
                    }

                    if (currentBoard![j][i] != "")
                    {
                        if (currentBoard![j][i] != option.Text)
                        {
                            cont++;
                        }
                    }
                    else
                    {
                        position = i;
                    }

                }
                cont = 0;
                position = -1;
            }
            return null;
        }

        private int[]? analysisDiag()
        {
            int cont = 0;
            int position = -1;

            for(int i = 0; i<3; i++)
            {
                if (currentBoard![i][i] != "")
                {
                    if (currentBoard![i][i] != option.Text)
                    {
                        cont++;
                    }
                }
                else
                {
                    position = i;
                }
                if(cont == 2 && position != -1) {
                    return new int[2] { position, position };
                }
            }

            int column = 2;
            cont = 0;
            int positionL = -1;
            int positionC = -1;

            for (int line = 0; line<3; line++)
            {
                if(currentBoard![line][column] != "")
                {
                    if(currentBoard![line][column] != option.Text)
                    {
                        cont++;
                    }
                }
                else {
                    positionL = line;
                    positionC = column;
                }
                if(cont == 2 && positionC != -1 && positionL != -1)
                {
                    return new int[2] { positionL, positionC };
                }
                column--;   
            }
            return null;
        }

        private bool defense()
        {
            var analysis = analysisHorizont()   != null ? analysisHorizont()
                            : analysisVertic()  != null ? analysisVertic()
                            : analysisDiag()    != null ? analysisDiag() : null;

            if (analysis != null)
            {
                int moveLine = analysis[0];
                int moveColumn = analysis[1];
            }
            return true;
        }
        private bool attack()
        {
            int verifica = 0;
            for(int i=0; i<=2; i++)
            {
                for(int j =0; j<=2; j++)
                {
                    if(currentBoard[i][j] != "")
                    {
                        verifica++;
                    }
                }
            }
            if(verifica == 0)                   //significa que é a primeira jogada, tab vazio
            {
                currentBoard[2][0] = select.Text;
            }
            else if(verifica == 1)
            {
                if (currentBoard[1][1] != select.Text && currentBoard[1][1] != "")
                {
                    currentBoard[0][0] = select.Text;
                }
                else if((currentBoard[0][1] != select.Text && currentBoard[0][1] != "")) || (currentBoard[1][0] !=select.Text && currentBoard)
            }

       



            
        }


        private void newPlay()
        {
            if (defense())
            {
                return ;
            }
            else
            {

            }
        }

        private void analyzeBoard (){
            reloadInit();

            if (select.Text != "Select") {
                // Exemplo de test

                currentBoard![moveLine][moveColumn] = select.Text;
                setGame(currentBoard);

                newPlay();

                moveURL = baseURL 
                    + "api/jogo?marcador=" + select.Text 
                    + "&linha=" + moveLine 
                    + "&coluna=" + moveColumn;
                aux = 2;
            }
            else
            {
                MessageBox.Show("Selecione uma forma (X ou O)");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void approve_Click(object sender, EventArgs e)
        {
                if (aux == 2)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    var response = client.GetAsync(moveURL).Result;

                    var stringBoard = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        string[][] board = JsonSerializer.Deserialize<string[][]>(stringBoard)!;
                        setGame(board);

                        MessageBox.Show("Jogada Realizada");
                    }catch(Exception ex)
                    {
                        MessageBox.Show(stringBoard);
                    }
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("A jogada não foi Análisada até o momento (Faça uma análise e tente novamente)!");
            }
            aux = 1;
        }

        private void analyze_Click(object sender, EventArgs e)
        {
            aux = 2;
            analyzeBoard();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            aux = 1;
            reloadInit();
        }
    }
}