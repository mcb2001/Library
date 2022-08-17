// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Design",
    "CA1032:Implement standard exception constructors",
    Justification = "By design",
    Scope = "namespaceanddescendants",
    Target = "~N:Oc6.Library")]

[assembly: SuppressMessage(
    "Performance",
    "CA1819:Properties should not return arrays",
    Justification = "By design",
    Scope = "namespaceanddescendants",
    Target = "~N:Oc6.Library")]

[assembly: SuppressMessage(
    "Naming",
    "CA1707:Identifiers should not contain underscores",
    Justification = "By definition",
    Scope = "type",
    Target = "~T:Oc6.Library.Localization.CultureCode")]
