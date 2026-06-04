namespace Mvvm.Models
{
    public class StepModel
    {
        public string Title { get; set; }
        public string ViewName { get; set; }
        public string BeforeStepText { get; set; }
        public string NextStepText { get; set; }
        public StepModel(
            string ViewName,
            string NextStepText = "Siguiente",
            string BeforeStepText = "Retornar"
        )
        {
            this.ViewName = ViewName;
            this.BeforeStepText = BeforeStepText;
            this.NextStepText = NextStepText;
        }
        public bool Validate()
        {
            return true;
        }
    }
}