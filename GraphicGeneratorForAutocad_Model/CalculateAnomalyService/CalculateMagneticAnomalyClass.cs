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
                Description = "Аномалия геомагнитного поля для шара. Ед. изм: x - X, м., y - Z,H,T, нТл.",
                ValuesList = new List<AnomalyValues>()
            };
            // Расчёт значений аномалии
            var VerticalValues = new List<AnomalyValue>();
            var HorizontalValues = new List<AnomalyValue>();
            var NormalValues = new List<AnomalyValue>();
            double M = (InductionValue * SusceptibilityValue * 4 * Math.PI * Math.Pow(Radius, 3)/3);
            for (var x = DistanceFromZero - 600; x <= DistanceFromZero + 600; x = x + 50)
            {
                var vertVal = (M * (2 * Math.Pow(Depth, 2) - Math.Pow(x - DistanceFromZero, 2))) / Math.Pow(Math.Pow(Depth, 2) + Math.Pow(x - DistanceFromZero, 2), 2.5);
                VerticalValues.Add(new AnomalyValue { Coord = x, Value = Math.Round(vertVal, CalculateServiceConstants.RoundValue) });
                var horVal = (3 * M * Depth * (x - DistanceFromZero)) / Math.Pow(Math.Pow(Depth, 2) + Math.Pow(x - DistanceFromZero, 2), 2.5);
                HorizontalValues.Add(new AnomalyValue { Coord = x, Value = Math.Round(horVal, CalculateServiceConstants.RoundValue) });
                var normVal = Math.Sqrt(Math.Pow(vertVal,2) + Math.Pow(horVal,2));
                NormalValues.Add(new AnomalyValue { Coord = x, Value = Math.Round(normVal, CalculateServiceConstants.RoundValue) });
            }
            // Загрузка данных в целевой объект
            Answer.ValuesList.Add(new AnomalyValues() { Values = VerticalValues });
            Answer.ValuesList.Add(new AnomalyValues() { Values = HorizontalValues });
            Answer.ValuesList.Add(new AnomalyValues() { Values = NormalValues });
            return Answer;
        }

        /// <summary>
        /// Расчитывает аномалию геомагнитного поля над вертикальным пластом бесконечного простирания
        /// </summary>
        public static AnomalyDescription CalculateMagneticAnomalyForLedge(double Depth, double FormationCapacity, double DistanceFromZero, double InductionValue, double SusceptibilityValue)
        {
            // Инициализация объекта с описанием и значениями аномалии
            AnomalyDescription Answer = new AnomalyDescription()
            {
                Description = "Аномалия геомагнитного поля для вертикального пласта. Ед. изм: x - X, м., y - Z,H,T, нТл.",
                ValuesList = new List<AnomalyValues>()
            };
            // Расчёт значений аномалии
            var VerticalValues = new List<AnomalyValue>();
            var HorizontalValues = new List<AnomalyValue>();
            var NormalValues = new List<AnomalyValue>();
            var J = InductionValue * SusceptibilityValue;
            var b = FormationCapacity / 2;
            for (var x = DistanceFromZero - 600; x <= DistanceFromZero + 600; x = x + 50)
            {
                var vertVal = 2 * J * Math.Atan( Math.Abs( (2*b* Depth)/(Math.Pow(Depth,2) + Math.Pow(x-DistanceFromZero,2) - Math.Pow(b,2) ) ) );
                VerticalValues.Add(new AnomalyValue { Coord = x, Value = Math.Round(vertVal, CalculateServiceConstants.RoundValue) });
                var horVal = J * Math.Log( (Math.Pow(Depth,2) + Math.Pow(x-DistanceFromZero - b,2))/(Math.Pow(Depth, 2) + Math.Pow(x - DistanceFromZero + b, 2)) );
                HorizontalValues.Add(new AnomalyValue { Coord = x, Value = Math.Round(horVal, CalculateServiceConstants.RoundValue) });
                var normVal = Math.Sqrt(Math.Pow(vertVal, 2) + Math.Pow(horVal, 2));
                NormalValues.Add(new AnomalyValue { Coord = x, Value = Math.Round(normVal, CalculateServiceConstants.RoundValue) });
            }
            // Загрузка данных в целевой объект
            Answer.ValuesList.Add(new AnomalyValues() { Values = VerticalValues });
            Answer.ValuesList.Add(new AnomalyValues() { Values = HorizontalValues });
            Answer.ValuesList.Add(new AnomalyValues() { Values = NormalValues });
            return Answer;
        }
    }
}