namespace GraphicGeneratorForAutocad_Core.Entities
{
    public class AppOutput
    {
        private string? CommandChain;
        private string? GraphicParameters;
        private string? AxisSignatureParameters;

        public void ReadParameters (string commandChain, string graphicParameters, string axisSignatureParameters)
        {
            CommandChain = commandChain;
            GraphicParameters = graphicParameters;
            AxisSignatureParameters = axisSignatureParameters;
        }

        public string GetCommandChain () { return CommandChain; }
        public string GetGraphicParameters() { return GraphicParameters; }
        public string GetAxisSignatureParameters() { return AxisSignatureParameters; }
    }
}