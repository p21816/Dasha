//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Message
{
    public int Id { get; set; }
    public int SenderBankId { get; set; }
    public int RecieverBankId { get; set; }

    public virtual ResultMessage ResultMessage1 { get; set; }
}