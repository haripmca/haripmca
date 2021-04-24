using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities.Untility
{
    public enum ActionType
    {
        ReligionInsert, ReligionUpdate, ReligionDelete, ReligionSelect, AddOccupation, UpdateOccupation, DeleteOccupation, SelectOccupation,
        AddOccup,UpdateOccup,DeleteOccup,SelectOccup, AddMarital, UpdateMarital, DeleteMarital, AddLocationCountry, UpdateLocationCountry, DeleteLocationCountry,
        Add,Update,Delete
    }
    public enum RecordStatus
    {
        Active,InActive,Disable,Delete
    }
    public enum TableName
    {
        AnnualIncomeCurrency, Caste, Disability, Dosham, Education, EmployeementIn, FamilyStatus, FamilyType, FamilyValues,
        Height, LocationCountry, Marital, Occupation, OccupationSpecification, Religion
    }
}
