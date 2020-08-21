using System.Threading.Tasks;
using AspNetCSLAExamples.Business;
using Csla;
using Csla.AspNetCore.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCSLAExamples.RazorPages.Pages.People
{
  public class EditModel : PageModel<PersonEdit>
  {
    public async Task OnGet(int id)
    {
      if (id == -1)
        Item = await DataPortal.CreateAsync<PersonEdit>();
      else
        Item = await DataPortal.FetchAsync<PersonEdit>(id);
    }

    public async Task<ActionResult> OnPost()
    {
      return await SaveAsync((Item.Id > -1));
    }
  }
}