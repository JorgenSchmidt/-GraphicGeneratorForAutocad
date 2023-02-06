using GraphicGeneratorForAutocad_Core.Entities;
using GraphicGeneratorForAutocad_Model.CalculateAnomalyService;
using GraphicGeneratorForAutocad_Model.MakeCommandChainService;

namespace GraphicGeneratorForAutocad_Test
{
    // ����� �������� ���������� ������ �� ������ �� �������, ������ ����� ������������ ������������� ��� �������� ������� � ���������� ������� ��� �� ���������� �������
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AnomalyDescription description = CalculateMagneticAnomalyClass.CalculateMagneticAnomalyForSphere(60,40,0,54000,0.005);
            Assert.AreEqual(CommandsMakerForAnomalies.MakeCommandsForAnomalies(15,25,description),1);
        }
    }
}