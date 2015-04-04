//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataTransferObject
{
    using System;using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;using Newtonsoft.Json;
    using System.Collections.Generic;
    
    [DataContract()]
    public partial class EmployeeDto : UIPaging
    {
        [Key()] 
        [Required] 
        [DataMember] 
        public int EmployeeID  {get; set; }
     
        [Required] 
     
        [StringLength(15)]
        [DataMember] 
        public string NationalIDNumber  {get; set; }
     
        [Required] 
        [DataMember] 
        public int ContactID  {get; set; }
     
        [Required] 
     
        [StringLength(256)]
        [DataMember] 
        public string LoginID  {get; set; }
        [DataMember] 
        public Nullable<int> ManagerID  {get; set; }
     
        [Required] 
     
        [StringLength(50)]
        [DataMember] 
        public string Title  {get; set; }
     
        [Required] 
        [DataMember] 
        public System.DateTime BirthDate  {get; set; }
     
        [Required] 
     
        [StringLength(1)]
        [DataMember] 
        public string MaritalStatus  {get; set; }
     
        [Required] 
     
        [StringLength(1)]
        [DataMember] 
        public string Gender  {get; set; }
     
        [Required] 
        [DataMember] 
        public System.DateTime HireDate  {get; set; }
     
        [Required] 
        [DataMember] 
        public bool SalariedFlag  {get; set; }
     
        [Required] 
        [DataMember] 
        public short VacationHours  {get; set; }
     
        [Required] 
        [DataMember] 
        public short SickLeaveHours  {get; set; }
     
        [Required] 
        [DataMember] 
        public bool CurrentFlag  {get; set; }
     
        [Required] 
        [DataMember] 
        public System.Guid rowguid  {get; set; }
     
        [Required] 
        [DataMember] 
        public System.DateTime ModifiedDate  {get; set; }
    
        //[DataMember] 
        //[JsonProperty("Contacts")]
        //public virtual Contact Contacts { get; set; }
        //[DataMember] 
        //[JsonProperty("Employee1s")]
        //public virtual EmployeeDto [] Employee1s { get; set; }
        //[DataMember] 
        //[JsonProperty("Employee2s")]
        //public virtual Employee Employee2s { get; set; }
        //[DataMember] 
        //[JsonProperty("EmployeePayHistoriess")]
        //public virtual EmployeePayHistoryDto [] EmployeePayHistoriess { get; set; }
    
         public override string ToString()
         {
             return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
         }
    }
}