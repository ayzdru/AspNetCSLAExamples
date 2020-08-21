using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AspNetCSLAExamples.Core.Entities;
using AspNetCSLAExamples.Core.Interfaces;
using Csla;
using Csla.Rules;

namespace AspNetCSLAExamples.Business
{
  [Serializable]
  public class PersonEdit : BusinessBase<PersonEdit>
  {
    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(nameof(Id));
    public int Id
    {
      get { return GetProperty(IdProperty); }
      set { SetProperty(IdProperty, value); }
    }

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
    [Required]
    public string Name
    {
      get { return GetProperty(NameProperty); }
      set { SetProperty(NameProperty, value); }
    }
    public static readonly PropertyInfo<int> NameLengthProperty = RegisterProperty<int>(nameof(NameLength));
    public int NameLength
    {
        get => GetProperty(NameLengthProperty);
        set => SetProperty(NameLengthProperty, value);
    }
        protected override void AddBusinessRules()
    {
      base.AddBusinessRules();
      BusinessRules.AddRule(new InfoText(NameProperty, "Person name (required)"));
      BusinessRules.AddRule(new CheckCase(NameProperty));
      BusinessRules.AddRule(new NoZAllowed(NameProperty));
    }

    [Create, RunLocal]
    private void Create()
    {
      Id = -1;
      BusinessRules.CheckRules();
    }

    [Fetch]
    private void Fetch(int id, [Inject]IPersonRepository dal)
    {
      var data = dal.Get(id);
      using (BypassPropertyChecks)
        Csla.Data.DataMapper.Map(data, this);
      BusinessRules.CheckRules();
    }

    [Insert]
    private void Insert([Inject]IPersonRepository dal)
    {
      using (BypassPropertyChecks)
      {
        var data = new Person
        {
          Name = Name
        };
        var result = dal.Insert(data);
        Id = result.Id;
      }
    }

    [Update]
    private void Update([Inject]IPersonRepository dal)
    {
      using (BypassPropertyChecks)
      {
        var data = new Person
        {
          Id = Id,
          Name = Name
        };
        dal.Update(data);
      }
    }

    [DeleteSelf]
    private void DeleteSelf([Inject]IPersonRepository dal)
    {
      Delete(ReadProperty(IdProperty), dal);
    }

    [Delete]
    private void Delete(int id, [Inject]IPersonRepository dal)
    {
      dal.Delete(id);
    }

  }
}
