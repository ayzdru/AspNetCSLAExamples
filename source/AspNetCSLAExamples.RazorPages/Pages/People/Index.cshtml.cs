using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCSLAExamples.Business;
using Csla;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCSLAExamples.RazorPages.Pages.People
{
  public class IndexPageModel : PageModel
  {

    public PersonList PersonList { get; set; }

    public async Task OnGet()
    {
      PersonList = await DataPortal.FetchAsync<PersonList>();
    }
  }
}