using GraphicGeneratorForAutocad_Core.Entities;

namespace GraphicGeneratorForAutocad_Model.CalculateAnomalyService
{
    public class CalculateElectricAnomalyClass
    {
        /// <summary>
        /// Расчитывает аномалию потенциала электрического поля над источником тока
        /// </summary>
        public static AnomalyDescription CalculateElectricAnomalyForPoint(double DistanceFromZero, double DistanceFromXAxis, double OccurrenceDepth, double ObservationRoute_Y, double ObservationRoute_h, double ResistanceValue, double ElectricStrength)
        {
            // Инициализация объекта с описанием и значениями аномалии
            AnomalyDescription Answer = new AnomalyDescription()
            {
                Description = "Аномалия потенциала электрического поля над источником тока",
                ValuesList = new List<AnomalyValues>()
            };
            // Расчёт значений аномалии
            var Vals = new List<AnomalyValue>();
            for (var x = DistanceFromZero - 600; x <= DistanceFromZero + 600; x++)
            {
                var value = (ResistanceValue * ElectricStrength) / (2 * Math.PI)
                    * (1
                    / Math.Sqrt(Math.Pow(x-DistanceFromZero, 2) + (Math.Pow(ObservationRoute_Y - DistanceFromXAxis, 2) + Math.Pow(ObservationRoute_h - OccurrenceDepth, 2))));
                Vals.Add(new AnomalyValue { Coord = x, Value = value });
            }
            // Загрузка данных в целевой объект
            Answer.ValuesList.Add(new AnomalyValues() { Values = Vals });
            return Answer;
        }
    }
}