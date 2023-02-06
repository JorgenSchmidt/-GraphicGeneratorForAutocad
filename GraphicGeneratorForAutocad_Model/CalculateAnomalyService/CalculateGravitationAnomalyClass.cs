using GraphicGeneratorForAutocad_Core.Entities;

namespace GraphicGeneratorForAutocad_Model.CalculateAnomalyService
{
    public class CalculateGravitationAnomalyClass
    {
        /// <summary>
        /// Рассчитывает гравитационную аномалию над шаром 
        /// </summary>
        public static AnomalyDescription CalculateAnomalyForSphere(double Depth, double Radius, double DistanceFromZero, double DensitiesDifference)
        {
            // Инициализация объекта с описанием и значениями аномалии
            AnomalyDescription Answer = new AnomalyDescription()
            {//Ед. изм: x - X, м., y - Z,H,T, нТл.
                Description = "Гравитационная аномалия для шара. Ед. изм: x - X, м., y - σ, г/см3.",
                ValuesList = new List<AnomalyValues>()
            };
            // Расчёт значений аномалии
            var Vals = new List<AnomalyValue>();
            for (var x = DistanceFromZero - 600; x <= DistanceFromZero + 600; x = x + 50)
            {
                var value = 0.00667 * DensitiesDifference 
                    * (4 * Math.PI * Math.Pow(Radius, 3)) / 3 
                    * (Depth / Math.Sqrt(Math.Pow(Math.Pow(x - DistanceFromZero, 2) + Math.Pow(Depth, 2), 3)) );
                Vals.Add(new AnomalyValue { Coord = x, Value = Math.Round(value, CalculateServiceConstants.RoundValue) });
            }
            // Загрузка данных в целевой объект
            Answer.ValuesList.Add( new AnomalyValues() { Values = Vals } );
            return Answer;
        }

        /// <summary>
        /// Рассчитывает гравитационную аномалию над уступом 
        /// </summary>
        public static AnomalyDescription CalculateAnomalyForLedge(double DepthLower, double DepthHigher, double DistanceFromZero, double DensitiesDifference)
        {
            // Инициализация объекта с описанием и значениями аномалии
            AnomalyDescription Answer = new AnomalyDescription()
            {
                Description = "Гравитационная аномалия для уступа.  Ед. изм: x - X, м., y - σ, г/см3.",
                ValuesList = new List<AnomalyValues>()
            };
            // Расчёт значений аномалии
            var Vals = new List<AnomalyValue>();
            for (var x = DistanceFromZero - 600; x <= DistanceFromZero + 600; x = x + 50)
            {
                var value = 0.00667 * DensitiesDifference * (
                        Math.PI * (DepthLower - DepthHigher)
                        + 2*DepthLower * Math.Atan((x-DistanceFromZero)/DepthLower)
                        - 2*DepthHigher * Math.Atan((x-DistanceFromZero)/DepthHigher)
                        + (x-DistanceFromZero) * Math.Log(
                                (Math.Pow(x - DistanceFromZero,2) + Math.Pow(DepthLower,2))
                                /
                                (Math.Pow(x - DistanceFromZero, 2) + Math.Pow(DepthHigher, 2))
                            )
                    );
                Vals.Add(new AnomalyValue { Coord = x, Value = Math.Round(value, CalculateServiceConstants.RoundValue) });
            }
            // Загрузка данных в целевой объект
            Answer.ValuesList.Add(new AnomalyValues() { Values = Vals });
            return Answer;
        }
    }
}