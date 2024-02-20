namespace FinalProgramacion2023.Entidades
{
    public class Cuadrilatero
    {
        public int LadoA { get; set; }
        public int LadoB { get; set; }
        private Color colorRelleno;

        public Color ColorRelleno
        {
            get { return colorRelleno; }
            set { colorRelleno = value; }
        }
        private Borde tipoDeBorde;

        public Borde TipoDeBorde
        {
            get { return tipoDeBorde; }
            set { tipoDeBorde = value; }
        }
        public Cuadrilatero()
        {
        }

        public Cuadrilatero(int ladoA, int ladoB, Color color, Borde borde)
        {
            LadoA = ladoA;
            LadoB = ladoB;
            ColorRelleno = color;
            TipoDeBorde = borde;
        }
        public double GetLadoA() => LadoA;
        public void SetLadoA(int medida)
        {
            if (medida > 0)
            {
                LadoA = medida;
            }
        }
        public double GetLadoB() => LadoB;
        public void SetLadoB(int medida)
        {
            if (medida > 0)
            {
                LadoB = medida;
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        
        public double GetPerimetro() => (2*LadoA)+(2*LadoB);
        public double GetArea() => LadoA*LadoB;
        public string GetCuadrilatero()
        {
            if ((LadoA > 0 && LadoB > 0))
                return "Cuadrilatero";
            else
                return "No es un cuadrilatero";
        }
        public string GetTipoDeCuadrilatero()
        {
            if (LadoA == LadoB)
            {
                return "Cuadrado";
            }
            else if (LadoA <= 0 || LadoB <= 0)
            {
                return "Indeterminado";
            }
            else
            {
                return "Rectángulo";
            }
        }
    }
}
