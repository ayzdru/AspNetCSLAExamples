using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspNetCSLAExamples.Core.Interfaces;
using Csla;

namespace AspNetCSLAExamples.Business
{
  [Serializable]
  public class PersonList : ReadOnlyListBase<PersonList, PersonInfo>
  {
    [Create, RunLocal]
    private void Create() { }

    [Fetch]
    private void Fetch([Inject]IPersonRepository dal)
    {
      IsReadOnly = false;
      var data = dal.Get().Select(d => DataPortal.FetchChild<PersonInfo>(d));
      AddRange(data);
      IsReadOnly = true;
    }
  }
}
