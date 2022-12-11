namespace Hw8.Calculator
{
    public interface IParser
    {
        void ParseCalcArguments(string[] arr, out double val1, out Operation opr, out double val2);
        Operation ParseOperation(string opera);
    }
}
