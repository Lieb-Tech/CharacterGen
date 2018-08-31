using System.Diagnostics;
using System.Windows;

namespace CharacterGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                OutputCode("A", configA, "A");
                OutputCode("C", configC, "C");
                OutputCode("H", configH, "H");
                OutputCode("E", configE, "E");
                OutputCode("L", configL, "L");
                OutputCode("M", configM, "M");
                OutputCode("R", configR, "R");
                OutputCode("N", configN, "N");
                OutputCode("O", configO ,"O");
                OutputCode("T", configT, "T");

                OutputCode("COMMA", configComma, ",");                
                OutputCode("SPACE", configSpace, " ");
                OutputCode("PLUS", configPlus, "+");
                /*
                OutputCode("B", configB);
                OutputCode("D", configD);
                OutputCode("F", configF);
                OutputCode("G", configG);
                OutputCode("I", configI);
                */
            };
        }

        // generate the data for the struct in Arduino project
        void OutputCode(string character, int[,] matrix, string val)
        {
            var data = convertToLong(matrix);
            txtInfo.Text += $@"
char{character}.pixelData = {data};
char{character}.width = {matrix.GetLength(1)};
char{character}.val = '{val}';
";
        }

        // take the 2d array, and return it represented as a long 
        long convertToLong(int[,] a)
        {                        
            long val = 0;
            for (int r = 0; r < a.GetLength(0); r++)
            {
                for (int c = 0; c < a.GetLength(1); c++)
                {
                    if (a[r,c] == 1)
                    {
                        var shift = (r * a.GetLength(1)) + c;
                        Debug.WriteLine(shift);
                        val += 1 << shift;
                    }
                }
            }
            return val;
        }

        // pixel map for characaters
        #region Character definitions
        int[,] configPlus = new int[6, 4]
        {
            {0, 0, 0, 0 },
            {0, 1, 0, 0 },
            {1, 1, 1, 0 },
            {0, 1, 0, 0 },
            {0, 0, 0, 0 },
            {0, 0, 0, 0 },
        };

        int[,] configSpace = new int[6, 1]
        {
            { 0, },
            { 0, },
            { 0, },
            { 0, },
            { 0, },
            { 0, },
        };

        int[,] configComma = new int[6,2]
        {
            {0, 0 },
            {0, 0 },
            {0, 0 },
            {0, 0 },
            {1, 0 },
            {1, 0 }
        };

        int[,] configM = new int[6, 5]
        {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0 }
        };

        int[,] configN = new int[6, 5]
        {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0 },
        };

        int[,] configR = new int[6, 5]
        {
            { 1, 1, 1, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 1, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
        };

        int[,] configA = new int[6, 5] 
        {
            { 0, 1, 1, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
        };

        int[,] configB = new int[6, 5]
        {
            {1, 1, 1, 0, 0 },
            {1, 0, 0, 1, 0 },
            {1, 1, 1, 0, 0 },
            {1, 0, 0, 1, 0 },
            {1, 1, 1, 0, 0 },
            {0, 0, 0, 0, 0 },
        };

        int[,] configC = new int[6, 5]
        {
            {0, 1, 1, 1, 0 },
            {1, 0, 0, 0, 0 },
            {1, 0, 0, 0, 0 },
            {1, 0, 0, 0, 0 },
            {0, 1, 1, 1, 0 },
            {0, 0, 0, 0, 0 },
        };

        int[,] configE = new int[6, 5]
        {
            {1, 1, 1, 1, 0 },
            {1, 0, 0, 0, 0 },
            {1, 1, 1, 0, 0 },
            {1, 0, 0, 0, 0 },
            {1, 1, 1, 1, 0 },
            {0, 0, 0, 0, 0 },
        };

        int[,] configH = new int[6, 5]
        {
            {1, 0, 0, 1, 0 },
            {1, 0, 0, 1, 0 },
            {1, 1, 1, 1, 0 },
            {1, 0, 0, 1, 0 },
            {1, 0, 0, 1, 0 },
            {0, 0, 0, 0, 0 },
        };

        int[,] configL = new int[6, 4]
        {
            {1, 0, 0, 0 },
            {1, 0, 0, 0 },
            {1, 0, 0, 0 },
            {1, 0, 0, 0 },
            {1, 1, 1, 0 },
            {0, 0, 0, 0 },
        };

        int[,] configT = new int[6, 4]
        {
            {1, 1, 1, 0 },
            {0, 1, 0, 0 },
            {0, 1, 0, 0 },
            {0, 1, 0, 0 },
            {0, 1, 0, 0 },
            {0, 0, 0, 0 },
        };

        int[,] configO = new int[6, 5]
        {
            {0, 1, 1, 0, 0 },
            {1, 0, 0, 1, 0 },
            {1, 0, 0, 1, 0 },
            {1, 0, 0, 1, 0 },
            {0, 1, 1, 0, 0 },
            {0, 0, 0, 0, 0 },
        };
        #endregion  
    }
}
