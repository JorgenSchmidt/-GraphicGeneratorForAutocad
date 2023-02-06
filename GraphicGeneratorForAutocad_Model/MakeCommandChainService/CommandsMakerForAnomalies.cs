using GraphicGeneratorForAutocad_Core.Entities;

namespace GraphicGeneratorForAutocad_Model.MakeCommandChainService
{
    public class CommandsMakerForAnomalies
    {
        /// <summary>
        /// Составляет цепочку команд для отрисовки аномалий
        /// </summary>
        /// <returns>Объект типа AppOutput содержащий информацию о графике и цепочку команд для его отрисовки.</returns>
        public static AppOutput MakeCommandsForAnomalies(double Coord_X, double Coord_Y, AnomalyDescription Description)
        {
            // Инициализация необходимых переменных
            AppOutput Answer = new();
            string chain = "";
            string graphicParameters = Description.Description;
            string axisSignatureParameters = "";
            double x_Max = Double.MinValue;
            double y_Max = Double.MinValue;
            double x_Min = Double.MaxValue;
            double y_Min = Double.MaxValue;

            // Определение максимального/минимального значений для по каждой из осей
            foreach (var currentList in Description.ValuesList)
            {
                // Инициализация переменных с максимальным и минимальным значениями на графике 
                double x_max = currentList.Values.Max(x => x.Coord);
                double y_max = currentList.Values.Max(x => x.Value);
                double x_min = currentList.Values.Min(x => x.Coord);
                double y_min = currentList.Values.Min(x => x.Value);
                if (x_Max < x_max) x_Max = x_max;
                if (y_Max < y_max) y_Max = y_max;
                if (x_Min > x_min) x_Min = x_min;
                if (y_Min > y_min) y_Min = y_min;
            }

            // Составление списка команд для отрисовки координатной плоскости графика
            double ElementCorretionKoefficient = Math.Abs(x_Max) + Math.Abs(x_Min) > Math.Abs(y_Max) + Math.Abs(y_Min) 
                ? (Math.Abs(x_Max) + Math.Abs(x_Min))/25 : (Math.Abs(y_Max) + Math.Abs(y_Min)/25);
            double CorrectionKoefficient = (Math.Abs(x_Max) + Math.Abs(x_Min)) / (Math.Abs(y_Max) + Math.Abs(y_Min));
            chain += "_line " 
                + (Coord_X).ToString().Replace(",",".")                     + "," + (Coord_Y).ToString().Replace(",", ".") + " " 
                + (x_Max + Coord_X + 1.2*ElementCorretionKoefficient).ToString().Replace(",", ".")       + "," + (Coord_Y).ToString().Replace(",", ".") + " "
                + (Coord_X).ToString().Replace(",", ".")                    + "," + (Coord_Y).ToString().Replace(",", ".") + " "
                + (x_Min + Coord_X).ToString().Replace(",", ".")            + "," + (Coord_Y).ToString().Replace(",", ".") + " "
                + (Coord_X).ToString().Replace(",", ".")                    + "," + (Coord_Y).ToString().Replace(",", ".") + " "
                + (Coord_X).ToString().Replace(",", ".") 		            + "," + (y_Max * CorrectionKoefficient + Coord_Y + 1.2 * ElementCorretionKoefficient).ToString().Replace(",", ".") + " "
                + (Coord_X).ToString().Replace(",", ".")                    + "," + (Coord_Y).ToString().Replace(",", ".") + " "
		        + (Coord_X).ToString().Replace(",", ".")                    + "," + (y_Min * CorrectionKoefficient + Coord_Y).ToString().Replace(",", ".") + "     \n";

            // Составление списка команд для отрисовки стрелок направления графика
            chain += "_line "
                + (Coord_X).ToString().Replace(",", ".")                + "," + (y_Max * CorrectionKoefficient + Coord_Y + 1.2 * ElementCorretionKoefficient).ToString().Replace(",", ".")
                + " @" + (0.7*ElementCorretionKoefficient).ToString().Replace(",", ".") + "<225 @" + ElementCorretionKoefficient.ToString().Replace(",", ".") + "<0 _c _c     _line "
                + (Coord_X + x_Max + 1.2 * ElementCorretionKoefficient).ToString().Replace(",", ".")   + ","  + (Coord_Y).ToString().Replace(",", ".")
                + " @" + (0.7*ElementCorretionKoefficient).ToString().Replace(",", ".") +  "<135 @" + ElementCorretionKoefficient.ToString().Replace(",", ".") + "<270 _c _c     \n";
            chain += "_c     ";

            // Составление списка команд для отрисовки делений графика по оси х
            for (var i = x_Min; i <= x_Max - 0.5 * ElementCorretionKoefficient; i += (Math.Abs(x_Max) + Math.Abs(x_Min)) / 12)
            {
                chain += "_line "
                    + (i + Coord_X).ToString().Replace(",", ".") + "," + Coord_Y.ToString().Replace(",",".") 
                    + " @" + (0.45*ElementCorretionKoefficient).ToString().Replace(",", ".") + "<90 @" + (0.9 * ElementCorretionKoefficient).ToString().Replace(",", ".") + "<270 _c _c ";
            }
            chain += " _c _c     \n";

            // Составление параметров для оси Х
            axisSignatureParameters += "Ось Х идёт от " + x_Min + " до " + (x_Max - 0.5 * ElementCorretionKoefficient).ToString() + " с шагом " + ((Math.Abs(x_Max) + Math.Abs(x_Min)) / 12).ToString() + "; ";

            // Составление списка команд для отрисовки делений графика по оси y
            for(var i = y_Min; i < y_Max; i+= (Math.Abs(y_Max) + Math.Abs(y_Min)) / 12 )
            {
                chain += "_line "
                    + Coord_X.ToString().Replace(",", ".") + "," + (Math.Round(i * CorrectionKoefficient + Coord_Y,1)).ToString().Replace(",", ".")
                    + " @" + (0.45 * ElementCorretionKoefficient).ToString().Replace(",", ".") + "<180 @" + (0.9 * ElementCorretionKoefficient).ToString().Replace(",", ".") + "<0 _c _c ";
            }
            chain += " _c _c     \n";

            // Составление параметров для оси Y
            axisSignatureParameters += "Ось Y идёт от " + y_Min + " до " + y_Max.ToString() + " с шагом " + ((Math.Abs(y_Max) + Math.Abs(y_Min)) / 12).ToString() + ". ";

            // Составление списка команд для отрисовки аномалии на графике
            foreach (var currentList in Description.ValuesList)
            {
                chain += "_spline ";
                foreach (var currentValue in currentList.Values)
                {
                    chain += (currentValue.Coord + Coord_X).ToString().Replace(",", ".") + "," + (Math.Round(currentValue.Value * CorrectionKoefficient + Coord_Y,0)).ToString().Replace(",", ".") + " ";
                }
                chain += "   _c \n";
            }

            Answer.ReadParameters(chain,graphicParameters,axisSignatureParameters);
            return Answer;
        }
    }
}