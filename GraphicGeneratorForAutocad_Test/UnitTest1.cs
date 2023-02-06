using GraphicGeneratorForAutocad_Core.Entities;
using GraphicGeneratorForAutocad_Model.CalculateAnomalyService;
using GraphicGeneratorForAutocad_Model.MakeCommandChainService;

namespace GraphicGeneratorForAutocad_Test
{
    // Ввиду большого количества данных на выходе из методов, данный класс используется исключительно для быстрого доступа к написанным методам для их дальнейшей отладки
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var Ds = CalculateElectricAnomalyClass.CalculateElectricAnomalyForPoint(200, 0, -100, 0, 200, 2000, 2);
            Assert.AreEqual(CommandsMakerForAnomalies.MakeCommandsForAnomalies(0,0, Ds),1);
        }
    }
}