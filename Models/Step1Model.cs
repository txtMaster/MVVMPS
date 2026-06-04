namespace Mvvm.Models
{
    public class Step1Model : StepModel
    {
        public Step1Model(
            string ViewName,
            string NextStepText = "Siguiente",
            string BeforeStepText = "Retornar"
        ): base(ViewName,NextStepText,BeforeStepText)
        {
            this.ViewName = ViewName;
            this.BeforeStepText = BeforeStepText;
            this.NextStepText = NextStepText;
        }
    }
}