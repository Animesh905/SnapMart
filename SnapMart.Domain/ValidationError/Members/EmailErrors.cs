﻿using SnapMart.Domain.Shared;

namespace SnapMart.Domain.ValidationError.Members;

public static class EmailErrors
{
    public static readonly Error Empty = new("Email.Empty", "Email is Empty");
}
