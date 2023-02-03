using GraphicGeneratorForAutocad_Core.Entities;

namespace GraphicGeneratorForAutocad_Model.CalculateAnomalyService
{
    public class CalculateMagneticAnomalyClass
    {
        /// <summary>
        /// Расчитывает аномалию геомагнитного поля над шаром
        /// </summary>
        public static AnomalyDescription CalculateMagneticAnomalyForSphere(double Depth, double Radius, double DistanceFromZero, double InductionValue, double SusceptibilityValue)
        {
            // Инициализация объекта с описанием и значениями аномалии
            AnomalyDescription Answer = new AnomalyDescription()
            {
                Description = "Аномалия геомагнитного поля для шара",
                ValuesList = new List<AnomalyValues>()
            };
            // Расчёт значений аномалии
            var VerticalValues = new List<AnomalyValue>();
            var HorizontalValues = new List<AnomalyValue>();
            var NormalValues = new List<AnomalyValue>();
            var M = InductionValue * SusceptibilityValue * ((4 * Math.PI * Math.Pow(Radius, 3)) / 3);
            for (var x = DistanceFromZero - 600; x <= DistanceFromZero + 600; x++)
            {
                var vertVal = (M * (2 * Math.Pow(Depth, 2) - Math.Pow(x - DistanceFromZero, 2))) / Math.Pow(Math.Pow(Depth, 2) + Math.Pow(x - DistanceFromZero, 2), 2.5);
                VerticalValues.Add(new AnomalyValue { Coord = x, Value = vertVal});
                var horVal = (3 * M * Depth * x) / Math.Pow(Math.Pow(Depth, 2) + Math.Pow(x - DistanceFromZero, 2), 2.5);
                HorizontalValues.Add(new AnomalyValue { Coord = x, Value = horVal });
                var normVal = Math.Sqrt(Math.Pow(vertVal,2) + Math.Pow(horVal,2));
                NormalValues.Add(new AnomalyValue { Coord = x, Value = normVal });
            }
            // Загрузка данных в целевой объект
            Answer.ValuesList.Add(new AnomalyValues() { Values = VerticalValues });
            Answer.ValuesList.Add(new AnomalyValues() { Values = HorizontalValues });
            Answer.ValuesList.Add(new AnomalyValues() { Values = NormalValues });
            return Answer;
        }

        /// <summary>
        /// Расчитывает аномалию геомагнитного поля над шаром
        /// </summary>
        public static AnomalyDescription CalculateMagneticAnomalyForLedge(double Depth, double FormationCapacity, double DistanceFromZero, double InductionValue, double SusceptibilityValue)
        {
            // Инициализация объекта с описанием и значениями аномалии
            AnomalyDescription Answer = new AnomalyDescription()
            {
                Description = "Аномалия геомагнитного поля для вертикального пласта",
                ValuesList = new List<AnomalyValues>()
            };
            // Расчёт значений аномалии
            var VerticalValues = new List<AnomalyValue>();
            var HorizontalValues = new List<AnomalyValue>();
            var NormalValues = new List<AnomalyValue>();
            var J = InductionValue * SusceptibilityValue;
            var b = FormationCapacity / 2;
            for (var x = DistanceFromZero - 600; x <= DistanceFromZero + 600; x++)
            {
                var vertVal = 2 * J * Math.Atan( Math.Abs( (2*b* Depth)/(Math.Pow(Depth,2) + Math.Pow(x-DistanceFromZero,2) - Math.Pow(b,2) ) ) );
                VerticalValues.Add(new AnomalyValue { Coord = x, Value = vertVal });
                var horVal = J * Math.Log( (Math.Pow(Depth,2) + Math.Pow(x-DistanceFromZero - b,2))/(Math.Pow(Depth, 2) + Math.Pow(x - DistanceFromZero + b, 2)) );
                HorizontalValues.Add(new AnomalyValue { Coord = x, Value = horVal });
                var normVal = Math.Sqrt(Math.Pow(vertVal, 2) + Math.Pow(horVal, 2));
                NormalValues.Add(new AnomalyValue { Coord = x, Value = normVal });
            }
            // Загрузка данных в целевой объект
            Answer.ValuesList.Add(new AnomalyValues() { Values = VerticalValues });
            Answer.ValuesList.Add(new AnomalyValues() { Values = HorizontalValues });
            Answer.ValuesList.Add(new AnomalyValues() { Values = NormalValues });
            return Answer;
        }
    }
}