using Csla.Rules;

namespace AspNetCSLAExamples.Business
{
  public class InfoText : BusinessRule
  {
    public string Text { get; set; }
    public InfoText(Csla.Core.IPropertyInfo primaryProperty, string text)
      : base(primaryProperty)
    {
      Text = text;
    }

    protected override void Execute(IRuleContext context)
    {
      context.AddInformationResult(Text);
    }
  }
}
