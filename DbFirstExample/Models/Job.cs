﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DbFirstExample.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int ItemWorkItemId { get; set; }

    public string ItemDescription { get; set; }

    public int ItemWorkTypeId { get; set; }

    public string ItemWorkTypeName { get; set; }
}